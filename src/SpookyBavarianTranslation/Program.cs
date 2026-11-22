using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetBundleModifier;
using AssetsTools.NET;
using PlainAndEasyInjector;

namespace SpookyBavaria;

internal static class Program
{
    private const string GameName = "Spooky's Jump Scare Mansion HD Renovation";
    private const string RuntimeFolder = "Bavaria";
    private static readonly string[] RuntimeAudio = { "EyLeuteHörtAuf.ogg", "SoNeScheißeAua.ogg" };

    private static IEnumerable<string> DefaultGameFolders()
    {
        if (OperatingSystem.IsWindows())
        {
            yield return Path.Combine(@"C:\Program Files (x86)\Steam\steamapps\common", GameName);
            yield return Path.Combine(@"C:\Program Files\Steam\steamapps\common", GameName);
        }
        else if (OperatingSystem.IsMacOS())
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            yield return Path.Combine(home, "Library/Application Support/Steam/steamapps/common", GameName);
        }
        else
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            yield return Path.Combine(home, ".local/share/Steam/steamapps/common", GameName);
            yield return Path.Combine(home, ".steam/steam/steamapps/common", GameName);
            yield return Path.Combine(home, ".var/app/com.valvesoftware.Steam/.local/share/Steam/steamapps/common", GameName);
        }
    }

    private static int Main(string[] args)
    {
        int result = Run(args);

        if (args.Length == 0 && !Console.IsInputRedirected)
        {
            Console.WriteLine();
            Console.Write("Press Enter to close.");
            Console.ReadLine();
        }
        return result;
    }

    private static int Run(string[] args)
    {
        string? dataDirArg = null;
        string? classDataArg = null;
        string? classDataCacheArg = null;
        AssetBundleCompressionType? compressionOverride = null;
        var positional = new List<string>();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--data" && i + 1 < args.Length) dataDirArg = args[++i];
            else if (args[i] == "--classdata" && i + 1 < args.Length) classDataArg = args[++i];
            else if (args[i] == "--classdata-cache" && i + 1 < args.Length) classDataCacheArg = args[++i];
            else if (args[i] == "--lz4") compressionOverride = AssetBundleCompressionType.LZ4;
            else if (args[i] == "--lzma") compressionOverride = AssetBundleCompressionType.LZMA;
            else positional.Add(args[i]);
        }

        string command = positional.Count > 0 ? positional[0].ToLowerInvariant() : "apply";
        if (command is "help" or "-h" or "--help" or "/?")
        {
            PrintUsage();
            return 0;
        }

        if (command == "apply")
            PrintHeader();

        string? dataDir = dataDirArg != null
            ? ResolveDataDir(dataDirArg)
            : FindDataDir() ?? AskForDataDir();
        if (dataDir == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Could not find the game's *_Data folder.");
            Console.WriteLine("Run the program again and enter the game folder, or use: --data \"<game folder>\"");
            Console.ResetColor();
            return 2;
        }

        dataDir = Path.GetFullPath(dataDir);
        string gameRoot = Path.GetDirectoryName(dataDir) ?? dataDir;
        string managedDir = Path.Combine(dataDir, "Managed");

        var options = new PatchOptions
        {
            ModBaseDirectory = AppContext.BaseDirectory,
            ClassDataPath = classDataArg,
            ClassDataCacheDirectory = classDataCacheArg,
            AddedAssetsManifestRelativePath = "Bavaria/added_assets.json",
            AddedAssetContainerPrefix = "assets/bavaria",
            BundleCompressionOverride = compressionOverride
        };

        using var patcher = new AssetPatcher(dataDir, options, Console.WriteLine);

        try
        {
            switch (command)
            {
                case "apply":
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Target Game Folder: {gameRoot}");
                        Console.WriteLine($"Game Data Folder:   {dataDir}");
                        Console.WriteLine("-------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine("Make sure the game is closed.\n");
                        var clock = Stopwatch.StartNew();

                        GameAssemblies.LoadFrom(managedDir);
                        BavarianTranslationsFromJSON.Load();

                        Step("--- STEP 1: Patching the game's assets ---");
                        ModPlan plan = BuildModPlan();
                        PatchResult assetResult = patcher.Apply(plan);
                        if (!assetResult.Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Asset patching failed with {assetResult.Errors.Count} error(s). No game files were left partially modified.");
                            foreach (string err in assetResult.Errors)
                                Console.WriteLine("  ERROR: " + err);
                            Console.ResetColor();
                            return 1;
                        }

                        Step("--- STEP 2: Patching the game's code ---");
                        bool codeOk = BavarianMod.Install(managedDir);

                        Step("--- STEP 3: Copying the mod's own files ---");
                        int copied = InstallRuntimeFiles(dataDir);
                        Console.WriteLine($"  {copied} file(s) copied to {Path.Combine(dataDir, RuntimeFolder)}");

                        BavarianTranslationsFromJSON.ReportMissing();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------");
                        if (codeOk)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"All processes completed successfully! {assetResult.OperationsApplied} asset op(s) across {assetResult.FilesModified} file(s) and code patches applied in {clock.Elapsed.TotalSeconds:0.#} s.");
                            Console.ResetColor();
                            return 0;
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Patching the game's code failed (see above).");
                        Console.ResetColor();
                        return 1;
                    }

                case "verify":
                case "verify-types":
                    {
                        GameAssemblies.LoadFrom(managedDir);
                        BavarianTranslationsFromJSON.Load();
                        ModPlan plan = BuildModPlan();
                        IReadOnlyList<string> errors = patcher.Verify(plan);
                        if (errors.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Verified {plan.Operations.Count} patch operation(s) cleanly against {dataDir}.");
                            Console.ResetColor();
                            return 0;
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        foreach (string err in errors)
                            Console.WriteLine("  ERROR: " + err);
                        Console.WriteLine($"{errors.Count} verification failure(s).");
                        Console.ResetColor();
                        return 1;
                    }

                case "revert":
                    {
                        int restored = patcher.Revert();
                        restored += BavarianMod.Uninstall(managedDir);
                        string runtimeDir = Path.Combine(dataDir, RuntimeFolder);
                        if (Directory.Exists(runtimeDir))
                            Directory.Delete(runtimeDir, recursive: true);
                        Console.WriteLine($"Restored {restored} file(s).");
                        return 0;
                    }

                case "get":
                    {
                        if (positional.Count < 3)
                        {
                            PrintUsage();
                            return 2;
                        }
                        string file = positional[1];
                        long pathId = long.Parse(positional[2]);
                        string? field = positional.Count > 3 && !positional[3].StartsWith("--", StringComparison.Ordinal)
                            ? positional[3]
                            : null;
                        int innerIdx = positional.IndexOf("--inner");
                        string? inner = innerIdx >= 0 && innerIdx + 1 < positional.Count ? positional[innerIdx + 1] : null;
                        Console.WriteLine(patcher.InspectField(new AssetAddress(file, pathId, inner), field));
                        return 0;
                    }

                default:
                    PrintUsage();
                    return 2;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + (ex.Message.Length > 0 ? ex.Message : ex.GetType().Name));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(ex.ToString());
            Console.ResetColor();
            return 1;
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ModPlan BuildModPlan() => ModList.BuildPlan();

    private static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===========================================");
        Console.WriteLine("   SJMHD MULTI-FILE PATCHER & INSTALLER");
        Console.WriteLine("===========================================");
        Console.ResetColor();
        Console.WriteLine();
    }

    private static void Step(string title)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(title);
        Console.ResetColor();
    }

    private static int InstallRuntimeFiles(string dataDir)
    {
        string target = Path.Combine(dataDir, RuntimeFolder, "Audio");
        Directory.CreateDirectory(target);
        int copied = 0;
        foreach (string name in RuntimeAudio)
        {
            string source = Path.Combine(AppContext.BaseDirectory, "Audio", name);
            if (!File.Exists(source))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  missing: {source}");
                Console.ResetColor();
                continue;
            }
            File.Copy(source, Path.Combine(target, name), overwrite: true);
            copied++;
        }
        return copied;
    }

    private static string? FindDataDir()
    {
        foreach (string baseDir in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
        {
            string? found = ResolveDataDir(baseDir);
            if (found != null) return found;
        }
        return null;
    }

    private static string? ResolveDataDir(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return null;

        path = path.Trim().Trim('"').TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        if (!Directory.Exists(path)) return null;

        if (Path.GetFileName(path).EndsWith("_Data", StringComparison.OrdinalIgnoreCase)
            || Directory.Exists(Path.Combine(path, "Managed")))
            return path;

        static string? FromApp(string app)
        {
            string data = Path.Combine(app, "Contents", "Resources", "Data");
            return Directory.Exists(Path.Combine(data, "Managed")) ? data : null;
        }

        if (path.EndsWith(".app", StringComparison.OrdinalIgnoreCase)) return FromApp(path);

        string[] dirs = Directory.GetDirectories(path, "*_Data");
        if (dirs.Length == 1) return dirs[0];
        string[] apps = Directory.GetDirectories(path, "*.app");
        return apps.Length == 1 ? FromApp(apps[0]) : null;
    }

    private static string? AskForDataDir()
    {
        string savedFile = Path.Combine(AppContext.BaseDirectory, "gamepath.txt");

        if (File.Exists(savedFile))
        {
            string? remembered = ResolveDataDir(File.ReadAllText(savedFile));
            if (remembered != null) return remembered;
        }

        if (Console.IsInputRedirected) return null;

        Console.WriteLine("The game was not found next to this program.");

        foreach (string candidate in DefaultGameFolders())
        {
            string? found = ResolveDataDir(candidate);
            if (found == null) continue;

            Console.WriteLine("Is the game installed here?");
            Console.WriteLine("  " + candidate);
            Console.Write("[Y/n]: ");
            string answer = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            if (answer is "" or "y" or "yes")
            {
                Remember(savedFile, found);
                return found;
            }
            break;
        }

        while (true)
        {
            Console.Write("Enter the path of the game folder (empty to cancel): ");
            string input = (Console.ReadLine() ?? "").Trim();
            if (input.Length == 0) return null;

            string? found = ResolveDataDir(input);
            if (found != null)
            {
                Remember(savedFile, found);
                return found;
            }
            Console.WriteLine("The game's data folder (*_Data, or *.app on macOS) was not found there. Please try again.");
        }
    }

    private static void Remember(string savedFile, string dataDir)
    {
        try { File.WriteAllText(savedFile, dataDir); }
        catch { }
    }

    private static void PrintUsage()
    {
        Console.WriteLine("SpookyBavarianTranslation");
        Console.WriteLine();
        Console.WriteLine("  SpookyBavarianTranslation                patch the game (apply)");
        Console.WriteLine("  SpookyBavarianTranslation verify         validate all patch operations without writing");
        Console.WriteLine("  SpookyBavarianTranslation revert         restore the original game files");
        Console.WriteLine("  SpookyBavarianTranslation get <file> <pathId> [field] [--inner <name>]");
        Console.WriteLine("                                           inspect a field value inside a game asset");
        Console.WriteLine();
        Console.WriteLine("  --data \"<path>\"            game folder or *_Data folder");
        Console.WriteLine("  --classdata \"<path>\"       explicit path to classdata.tpk");
        Console.WriteLine("  --classdata-cache \"<dir>\"  cache folder for auto-fetched classdata.tpk");
        Console.WriteLine("  --lz4                      write bundles with LZ4 compression (default)");
        Console.WriteLine("  --lzma                     write bundles with LZMA compression");
    }
}
