Bavarian mod for Spooky's Jump Scare Mansion: HD Renovation
===========================================================

Close the game first. Then start the program for your computer:

  Windows (most PCs) ............ SJSMHDBavarianPatcher.exe
  Windows on ARM ................ SJSMHDBavarianPatcher_windows-arm64.exe
  Linux / Steam Deck ............ SJSMHDBavarianPatcher_linux-x64
  Linux on ARM .................. SJSMHDBavarianPatcher_linux-arm64
  Mac with an Intel chip ........ SJSMHDBavarianPatcher_macos-intel
  Mac with Apple chip (M1, M2..)  SJSMHDBavarianPatcher_macos-applesilicon

It finds the game by itself (or asks where it is), patches it, and keeps backups of the original files.
Undo everything:   SJSMHDBavarianPatcher revert   (add _linux-x64 etc. to the name on Linux/macOS)
After a game update, just run the program again.

Linux / macOS, the first time, in a terminal in this folder:
  chmod +x SJSMHDBavarianPatcher_*
  macOS only, if it says the file is damaged or can't be checked:
    xattr -d com.apple.quarantine SJSMHDBavarianPatcher_macos-*
  then start it, e.g.:  ./SJSMHDBavarianPatcher_linux-x64

Improve the translation
-----------------------
BavarianTranslations.json is a normal text file: "English": "Boarisch". Open it with any text editor (save as UTF-8),
change what you like, and run the program again. Every Bavarian is welcome to make it better!
(The game also gets a copy in <game>_Data/Bavaria/. Texts that change while playing are read from there when the game starts.)
