using System.Text;

namespace SpookyBavaria
{
    /// The Bavarian translations: "English text" -> "Bavarian text", from BavarianTranslations.json.
    /// It's a normal file anyone can edit to improve the translations (any text editor, UTF-8):
    ///   - next to the installer (SJSMHDBavarianPatcher): used while patching, for the texts baked into the game files.
    ///     The installer copies it into the game as well.
    ///   - in the game: <game>_Data/Bavaria/BavarianTranslations.json, used by the mod while the game runs
    ///     (the Mod loads it at startup). Edit this one to change texts without running the installer again
    ///     (only texts that are translated while the game runs; the rest needs the installer).
    /// No Newtonsoft / Unity needed: the file is a simple { "key": "value" } list (// comments and trailing commas are fine).
    public static class BavarianTranslationsFromJSON
    {
        public const string FileName = "BavarianTranslations.json";

        static readonly object gate = new object();
        static Dictionary<string, string>? table;
        static readonly HashSet<string> missing = new HashSet<string>();

        /// Where messages go: the console by default. Inside the game the Mod points this at Unity's log.
        public static Action<string> Log { get; set; } = Console.WriteLine;

        /// The file the translations were loaded from ("" if none was found).
        public static string LoadedFrom { get; private set; } = "";

        public static IReadOnlyDictionary<string, string> TranslationTable => Table;

        /// Texts that were asked for but have no translation (so far).
        public static IReadOnlyCollection<string> Missing { get { lock (gate) return missing.ToList(); } }

        static Dictionary<string, string> Table { get { lock (gate) return table ??= LoadTable(null); } }

        /// Loads (or reloads) the translations. Optional: the first Translate() loads them by itself.
        /// path: a specific JSON file; null = look in the usual places (see DefaultLocations).
        public static void Load(string? path = null)
        {
            lock (gate)
            {
                table = LoadTable(path);
                missing.Clear();
            }
        }

        /// The Bavarian text, or the original if there's no translation (that's remembered, see Missing / ReportMissing).
        public static string Translate(string? original)
        {
            if (string.IsNullOrEmpty(original)) return original ?? "";
            if (Table.TryGetValue(original!, out var translated)) return translated;
            bool first;
            lock (gate) first = missing.Add(original!);
            if (first) Log($"[Bavaria] No translation for \"{original}\"");
            return original!;
        }

        /// Prints the texts that had no translation. Call it at the end of patching.
        public static void ReportMissing()
        {
            var list = Missing;
            if (list.Count == 0) return;
            Log($"[Bavaria] {list.Count} text(s) have no translation in {FileName}:");
            foreach (var text in list) Log("  " + text);
        }

        /// Where the file is looked for when no path is given: next to the program (also in a "Bavaria" folder there),
        /// and in the game's data folder (<game>_Data/Bavaria, or on macOS <game>.app/Contents/Resources/Data/Bavaria).
        public static IEnumerable<string> DefaultLocations()
        {
            var baseDir = AppContext.BaseDirectory;
            yield return Path.Combine(baseDir, FileName);
            yield return Path.Combine(baseDir, "Bavaria", FileName);
            if (!Directory.Exists(baseDir)) yield break;
            foreach (var data in Directory.GetDirectories(baseDir, "*_Data"))
                yield return Path.Combine(data, "Bavaria", FileName);
            foreach (var app in Directory.GetDirectories(baseDir, "*.app"))
                yield return Path.Combine(app, "Contents", "Resources", "Data", "Bavaria", FileName);
        }

        static Dictionary<string, string> LoadTable(string? path)
        {
            var candidates = path != null ? new[] { path } : DefaultLocations().ToArray();
            foreach (var file in candidates.Where(File.Exists))
            {
                try
                {
                    var fromFile = SimpleJson.ReadStringDictionary(File.ReadAllText(file, Encoding.UTF8), file);
                    LoadedFrom = file;
                    return fromFile;
                }
                catch (Exception ex)
                {
                    // e.g. a missing comma after editing: say where, and keep going with English instead of crashing
                    Log($"[Bavaria] ERROR: {file} couldn't be read: {ex.Message}");
                }
            }
            LoadedFrom = "";
            Log($"[Bavaria] Warning: {FileName} wasn't found ({string.Join(", ", candidates)}). Texts stay in English.");
            return new Dictionary<string, string>();
        }
    }

    /// Just enough JSON for { "key": "value", ... }: escapes (\n, \", \u00e4, ...), // and /* */ comments, trailing commas.
    static class SimpleJson
    {
        public static Dictionary<string, string> ReadStringDictionary(string json, string source)
        {
            var result = new Dictionary<string, string>();
            int i = 0;
            Skip(json, ref i);
            Expect(json, ref i, '{', source);
            while (true)
            {
                Skip(json, ref i);
                if (Peek(json, i) == '}') { i++; break; }
                var key = ReadString(json, ref i, source);
                Skip(json, ref i);
                Expect(json, ref i, ':', source);
                Skip(json, ref i);
                string? value;
                if (json.Length - i >= 4 && string.CompareOrdinal(json, i, "null", 0, 4) == 0) { value = null; i += 4; }
                else value = ReadString(json, ref i, source);
                if (value != null) result[key] = value;   // a key listed twice: the last one wins
                Skip(json, ref i);
                if (Peek(json, i) == ',') { i++; continue; }
                Skip(json, ref i);
                if (Peek(json, i) == '}') { i++; break; }
                throw Error(json, i, source, "expected ',' or '}' (a missing comma or quote?)");
            }
            return result;
        }

        static char Peek(string s, int i) => i < s.Length ? s[i] : '\0';

        static void Expect(string s, ref int i, char c, string source)
        {
            if (Peek(s, i) != c) throw Error(s, i, source, $"expected '{c}'");
            i++;
        }

        /// Skips whitespace and comments.
        static void Skip(string s, ref int i)
        {
            while (i < s.Length)
            {
                if (char.IsWhiteSpace(s[i]) || s[i] == '\uFEFF') i++;
                else if (s[i] == '/' && Peek(s, i + 1) == '/') { while (i < s.Length && s[i] != '\n') i++; }
                else if (s[i] == '/' && Peek(s, i + 1) == '*')
                {
                    int end = s.IndexOf("*/", i + 2, StringComparison.Ordinal);
                    i = end < 0 ? s.Length : end + 2;
                }
                else break;
            }
        }

        static string ReadString(string s, ref int i, string source)
        {
            Expect(s, ref i, '"', source);
            var sb = new StringBuilder();
            while (true)
            {
                if (i >= s.Length) throw Error(s, i, source, "unterminated string");
                char c = s[i++];
                if (c == '"') return sb.ToString();
                if (c != '\\') { sb.Append(c); continue; }
                if (i >= s.Length) throw Error(s, i, source, "unterminated string");
                char e = s[i++];
                switch (e)
                {
                    case '"': sb.Append('"'); break;
                    case '\\': sb.Append('\\'); break;
                    case '/': sb.Append('/'); break;
                    case 'b': sb.Append('\b'); break;
                    case 'f': sb.Append('\f'); break;
                    case 'n': sb.Append('\n'); break;
                    case 'r': sb.Append('\r'); break;
                    case 't': sb.Append('\t'); break;
                    case 'u':
                        if (i + 4 > s.Length) throw Error(s, i, source, "bad \\u escape");
                        sb.Append((char)Convert.ToInt32(s.Substring(i, 4), 16));
                        i += 4;
                        break;
                    default: throw Error(s, i - 1, source, $"unknown escape \\{e}");
                }
            }
        }

        static FormatException Error(string s, int i, string source, string what)
        {
            int line = 1;
            for (int k = 0; k < i && k < s.Length; k++) if (s[k] == '\n') line++;
            return new FormatException($"{source}, line {line}: {what}.");
        }
    }
}
