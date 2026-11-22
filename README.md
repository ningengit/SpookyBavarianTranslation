# Spooky Bavarian Translation Mod

Bavarian translation mod for *Spooky's Jump Scare Mansion HD Renovation*, built on `AssetBundleModifier`, `AssetBundleModifier.Media`, and `PlainAndEasyInjector` (`EasyModMaker`).

## Repository Structure

- `src/SpookyBavarianTranslation/` — Installer CLI (`Mods.cs`, `Program.cs`, `Audio/`, `Textures/`, `BavarianTranslations.json`).
- `src/SpookyBavarianTranslation.Runtime/` — `netstandard2.1` runtime hook & MonoBehaviour assembly injected into `Managed/` (`Mod.cs`, `BavarianMod.cs`, `RadioRund.cs`, `BavarianTranslationsFromJSON.cs`).
- `sync-types.json` — Configuration for `AssetBundleModifier.Generator sync-types` to generate gitignored `games/Spooky.GameApi/`.

## Building

1. Generate strongly-typed asset handles into `games/Spooky.GameApi/` using `AssetBundleModifier.Generator`:

```powershell
dotnet run --project ..\EasyModMaker\src\AssetBundleModifier.Generator\AssetBundleModifier.Generator.csproj -f net10.0 -- sync-types --game "C:\Path\To\SpookyUnity_Data" --config sync-types.json
```

2. Build via NuGet packages (default) or sibling `EasyModMaker` project references (`-p:UseLocalFramework=true`):

```powershell
dotnet build SpookyBavarianTranslation.slnx -c Release
# or using local framework sources:
dotnet build SpookyBavarianTranslation.slnx -c Debug -p:UseLocalFramework=true
```
