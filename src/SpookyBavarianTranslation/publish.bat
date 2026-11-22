@echo off
setlocal
rem ==========================================================================================
rem  Builds the installer for every platform from this Windows PC.
rem    Windows: x64, ARM64      Linux: x64, ARM64 (Steam Deck = linux-x64)      macOS: Intel, Apple Silicon
rem  Result: bin\Release\net10.0\CombinedPublish
rem ==========================================================================================

set "out=bin\Release\net10.0\CombinedPublish"
if exist "%out%" rmdir /s /q "%out%"
mkdir "%out%"

for %%R in (win-x64 win-arm64 linux-x64 linux-arm64 osx-x64 osx-arm64) do (
    echo.
    echo ===== Publishing %%R ...
    dotnet publish -c Release -r %%R -o "bin\Release\net10.0\%%R\publish" || goto :failed
)

echo.
echo ===== Building SpookyBavarianTranslation.Runtime (for ingame\) ...
dotnet build "%~dp0..\SpookyBavarianTranslation.Runtime\SpookyBavarianTranslation.Runtime.csproj" -c Release -o "bin\Release\net10.0\runtime-out" || goto :failed

echo.
echo ===== Combining everything into %out% ...
copy /y "bin\Release\net10.0\win-x64\publish\SpookyBavarianTranslation.exe"   "%out%\SpookyBavarianTranslation.exe" >nul
copy /y "bin\Release\net10.0\win-arm64\publish\SpookyBavarianTranslation.exe" "%out%\SpookyBavarianTranslation_windows-arm64.exe" >nul
copy /y "bin\Release\net10.0\linux-x64\publish\SpookyBavarianTranslation"     "%out%\SpookyBavarianTranslation_linux-x64" >nul
copy /y "bin\Release\net10.0\linux-arm64\publish\SpookyBavarianTranslation"   "%out%\SpookyBavarianTranslation_linux-arm64" >nul
copy /y "bin\Release\net10.0\osx-x64\publish\SpookyBavarianTranslation"       "%out%\SpookyBavarianTranslation_macos-intel" >nul
copy /y "bin\Release\net10.0\osx-arm64\publish\SpookyBavarianTranslation"     "%out%\SpookyBavarianTranslation_macos-applesilicon" >nul

copy /y "bin\Release\net10.0\win-x64\publish\BavarianTranslations.json" "%out%\" >nul
if exist "bin\Release\net10.0\win-x64\publish\ingame"   xcopy /E /I /Y /Q "bin\Release\net10.0\win-x64\publish\ingame"   "%out%\ingame" >nul
if not exist "%out%\ingame" mkdir "%out%\ingame"
copy /y "bin\Release\net10.0\runtime-out\SpookyBavarianTranslation.Runtime.dll" "%out%\ingame\" >nul
if exist "bin\Release\net10.0\runtime-out\SpookyBavarianTranslation.Runtime.pdb" copy /y "bin\Release\net10.0\runtime-out\SpookyBavarianTranslation.Runtime.pdb" "%out%\ingame\" >nul

if exist "bin\Release\net10.0\win-x64\publish\Textures" xcopy /E /I /Y /Q "bin\Release\net10.0\win-x64\publish\Textures" "%out%\Textures" >nul
if exist "bin\Release\net10.0\win-x64\publish\Audio"    xcopy /E /I /Y /Q "bin\Release\net10.0\win-x64\publish\Audio"    "%out%\Audio" >nul
copy /y "README.txt" "%out%\" >nul

echo.
echo Done: %out%
dir /b "%out%"
goto :eof

:failed
echo.
echo PUBLISH FAILED (see the messages above)
exit /b 1
