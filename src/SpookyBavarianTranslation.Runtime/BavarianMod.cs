using PlainAndEasyInjector;
using Rewired;
using SpookyBavaria;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

/// Everything the Bavarian mod changes in the game's code. Used by SJSMHDBavarianPatcher (Install) and by
/// this project's own Program (for testing).
public static class BavarianMod
{
    public const string DefaultManagedFolder = @"C:\Program Files (x86)\Steam\steamapps\common\Spooky's Jump Scare Mansion HD Renovation\SpookyUnity_Data\Managed";

    private static int ToiletFlushedCounter = 0;

    /// Patches the game in place (Assembly-CSharp.dll, Rewired_Core.dll, ...) and keeps backups of the originals.
    /// managedDir: ...\SpookyUnity_Data\Managed. Returns false (after printing why) if it failed.
    public static bool Install(string managedDir)
    {
        GameAssemblies.LoadFrom(managedDir);   // must come before anything that touches game types
        if (!Patch(managedDir, outputDir: null)) return false;
        InstallTranslations(managedDir);
        return true;
    }

    /// The translations the mod uses while the game runs: <game>_Data/Bavaria/BavarianTranslations.json.
    public static string TranslationsInGame(string managedDir)
        => Path.Combine(Path.GetDirectoryName(Path.GetFullPath(managedDir))!, "Bavaria", BavarianTranslationsFromJSON.FileName);

    /// Copies the translations used for patching (the editable file next to the program) into the game.
    private static void InstallTranslations(string managedDir)
    {
        string source = BavarianTranslationsFromJSON.LoadedFrom;
        string target = TranslationsInGame(managedDir);
        if (source.Length == 0 || !File.Exists(source))
        {
            Console.WriteLine($"[Bavaria] Warning: no {BavarianTranslationsFromJSON.FileName} to copy into the game; texts translated while the game runs stay in English.");
            return;
        }
        Directory.CreateDirectory(Path.GetDirectoryName(target)!);
        if (!string.Equals(Path.GetFullPath(source), Path.GetFullPath(target), StringComparison.OrdinalIgnoreCase))
            File.Copy(source, target, overwrite: true);
        Console.WriteLine($"[Bavaria] translations copied to {target}");
    }

    /// Writes the patched files to outputDir instead of the game (for checking them first).
    public static bool SaveTo(string managedDir, string outputDir)
    {
        GameAssemblies.LoadFrom(managedDir);
        return Patch(managedDir, outputDir);
    }

    /// Puts the original files back and removes the ones the mod added.
    public static int Uninstall(string managedDir)
    {
        int count = Patcher.Uninstall(Path.Combine(managedDir, "Assembly-CSharp.dll"));
        string translations = TranslationsInGame(managedDir);
        if (File.Exists(translations)) { File.Delete(translations); count++; }
        string folder = Path.GetDirectoryName(translations)!;
        if (Directory.Exists(folder) && !Directory.EnumerateFileSystemEntries(folder).Any()) Directory.Delete(folder);
        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]   // its game types may only be loaded after GameAssemblies.LoadFrom
    private static bool Patch(string managedDir, string? outputDir)
    {
        using var patcher = Patcher.Open(Path.Combine(managedDir, "Assembly-CSharp.dll"));
        Define(patcher);
        BavarianTranslationsFromJSON.ReportMissing();
        return outputDir == null ? patcher.Install() : patcher.Save(outputDir) != null;
    }

    private static void Define(Patcher patcher)
    {
        // the Mod (like a BepInEx plugin): created when the game starts, lives across scenes
        patcher.AddMod<Mod>();

        // enum names that the game shows as text (e.g. in the endless mode game over screen)
        patcher.SetEnumNames<PersistenceData.StateLog>(
            BavarianTranslationsFromJSON.Translate("Always"),
            BavarianTranslationsFromJSON.Translate("Sometimes"),
            BavarianTranslationsFromJSON.Translate("Never"));

        // Rewired (the game's input library, in Rewired_Core.dll): a const, and the key names built in its static constructor
        patcher.SetValueInField(typeof(Rewired.Consts), nameof(Rewired.Consts.unknownJoystickName), "kennma ned");

        //Rewired consts
        //"keyboardKeyNames"
        //"unityUnifiedMouseElementIdentifiers"
        //"rawInputUnifiedMouseElementIdentifiers"

        patcher.AddAfterRun<IList<ControllerElementIdentifier>>(typeof(Rewired.Consts), "get_unityUnifiedMouseElementIdentifiers", (instance, elements) => 
        {
            var unityUnifiedMouseElementIdentifiers = elements.ToArray();

            for (int i = 0; i < unityUnifiedMouseElementIdentifiers.Length; i++)
            {
                //names
                var elementName = unityUnifiedMouseElementIdentifiers[i].GetMember<string>(nameof(ControllerElementIdentifier._name));
                unityUnifiedMouseElementIdentifiers[i].SetMember(nameof(ControllerElementIdentifier._name), BavarianTranslationsFromJSON.Translate(elementName));

                //positive names

                var positiveElementName = unityUnifiedMouseElementIdentifiers[i].GetMember<string>(nameof(ControllerElementIdentifier._positiveName));
                unityUnifiedMouseElementIdentifiers[i].SetMember(nameof(ControllerElementIdentifier._positiveName), BavarianTranslationsFromJSON.Translate(positiveElementName));

                //negative names
                var negativeElementName = unityUnifiedMouseElementIdentifiers[i].GetMember<string>(nameof(ControllerElementIdentifier._negativeName));
                unityUnifiedMouseElementIdentifiers[i].SetMember(nameof(ControllerElementIdentifier._negativeName), BavarianTranslationsFromJSON.Translate(negativeElementName));
            }

            return new ReadOnlyCollection<ControllerElementIdentifier>(unityUnifiedMouseElementIdentifiers);
        });

        patcher.AddAfterRun<IList<ControllerElementIdentifier>>(typeof(Rewired.Consts), "get_rawInputUnifiedMouseElementIdentifiers", (instance, elements) =>
        {
            var unityUnifiedMouseElementIdentifiers = elements.ToArray();

            for (int i = 0; i < unityUnifiedMouseElementIdentifiers.Length; i++)
            {
                //names
                var elementName = unityUnifiedMouseElementIdentifiers[i].GetMember<string>(nameof(ControllerElementIdentifier._name));
                unityUnifiedMouseElementIdentifiers[i].SetMember(nameof(ControllerElementIdentifier._name), BavarianTranslationsFromJSON.Translate(elementName));

                //positive names

                var positiveElementName = unityUnifiedMouseElementIdentifiers[i].GetMember<string>(nameof(ControllerElementIdentifier._positiveName));
                unityUnifiedMouseElementIdentifiers[i].SetMember(nameof(ControllerElementIdentifier._positiveName), BavarianTranslationsFromJSON.Translate(positiveElementName));

                //negative names
                var negativeElementName = unityUnifiedMouseElementIdentifiers[i].GetMember<string>(nameof(ControllerElementIdentifier._negativeName));
                unityUnifiedMouseElementIdentifiers[i].SetMember(nameof(ControllerElementIdentifier._negativeName), BavarianTranslationsFromJSON.Translate(negativeElementName));
            }

            return new ReadOnlyCollection<ControllerElementIdentifier>(unityUnifiedMouseElementIdentifiers);
        });

        patcher.AddAfterRun(typeof(Rewired.Consts), ".cctor", (instance) =>
        {
            var keyboardnames = new List<string>(instance.GetMember<IList<string>>(nameof(Rewired.Consts.keyboardKeyNames)));
            Debug.Log(keyboardnames.Capacity);


            for (int i = 0; i < keyboardnames.Count; i++)
            {
                keyboardnames[i] = BavarianTranslationsFromJSON.Translate(keyboardnames[i]);
            }
            instance.SetMember(nameof(Rewired.Consts.keyboardKeyNames), new ReadOnlyCollection<string>(keyboardnames));


            Debug.Log("KOKO");
        });

        patcher.AddAfterRun<DollhouseRandomBrokenDoor>(nameof(DollhouseRandomBrokenDoor.Start), (instance) =>
        {
            instance.SetMember(nameof(DollhouseRandomBrokenDoor.messages), new LocalizedText [ ] { 
                new("QWERTZUIOP", "is hii"), 
                new("QWERTZUIOP", "is zsammgautscht"), 
                new("QWERTZUIOP", "Kaputt"), 
                new("QWERTZUIOP", "Des geht need auf"), 
                new("QWERTZUIOP", "des riahrt se ned"),
                new("QWERTZUIOP", "des sitzt pfundfest"),
                new("QWERTZUIOP", "Naa da gibts koa chance ned"),
                new("QWERTZUIOP", "De Dia is ganz hii"),
                new("QWERTZUIOP", "I glaab is aa ned wichtig"),
                new("QWERTZUIOP", "Muss scho song, des is gescheid hii"),
            });
        });

        patcher.SetStringInMethod<DollhouseKiragenControl>(nameof(DollhouseKiragenControl.KiragenUIFlow), "DOLL SPIRIT INTERFERENCE.\nPLACE OUTSIDE ROOM!", "PUPPENSEELE IS DO.\nBITTE WEGRAMMA!");
        patcher.SetStringInMethod<DollhouseKiragenControl>(nameof(DollhouseKiragenControl.KiragenUIFlow), "NOT ENOUGH RITUAL MATERIALS IN ROOM.", "FIA AN HEXENWERK SAN NED DIE MATERIALIEN DO.");

        patcher.AddAfterRun<DougControl>(nameof(DougControl.Start), (instance) =>
        {
            instance.GetMember<List<string>>(nameof(DougControl.randomNames)).Clear();
            instance.SetMember(nameof(DougControl.randomNames), new List<string>
            {
                "GAMER",
                "BRUDA",
                "SPEZL",
                "KUMPEL",
                "OPFA",
                "WIASCHTL",
                "ODA NED",
                "DOUG",
                "STINKER",
                "ANFÄNGER"
            });
        });

        patcher.SetStringInMethod<DougControl>(nameof(DougControl.DoPrepLevel), "GET READY DOUG", "AUF DIE PLÄTZE");
        patcher.SetStringInMethod<DougControl>(nameof(DougControl.DoPrepLevel), "GET READY {0}", "LOS {0}");
        patcher.SetStringInMethod<DougControl>(nameof(DougControl.SetFathoms), "{0}-FATHOMS", "{0}-KLAFTA");
        patcher.SetStringInMethod<DougControl>(nameof(DougControl.Dying), "GET READY {0}", "LOS {0}");

        patcher.AddBeforeRun<HOSToiletFlush>(nameof(HOSToiletFlush.OnInteract), (instance) =>
        {
            if (instance.transform.parent.name != "KH_Toilet")
            {
                return;
            }

            var useAgg = instance.useAgg;   // private in the game: visible thanks to Krafs.Publicizer (see the .csproj)

            if (useAgg > instance.cooldown)
            {
                ToiletFlushedCounter++;
                if (ToiletFlushedCounter == 10)
                {
                    var audiosource = instance.gameObject.AddComponent<AudioSource>();
                    audiosource.PlayOneShot(Assets.GetAudio("EyLeuteHörtAuf"));

                    var Dude = new GameObject();
                    Dude.transform.position = new Vector3(13.6f, 1f, 0.4f);
                    Dude.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    Dude.transform.eulerAngles = new Vector3(0, 180, 0);
                    var spr = Dude.AddComponent<SpriteRenderer>();
                    spr.sprite = Assets.GetSprite("KenneIchNicht");
                    spr.material = new Material(Shader.Find("Custom/BaseSurfaceShader (Cutout)"));
                }
                if (ToiletFlushedCounter == 11)
                {
                    Application.OpenURL("https://www.youtube.com/watch?v=jps7bZ1t8SE");
                    Application.Quit();
                }
            }
        });

        patcher.AddAfterRun<SendMessageOnHit>(nameof(SendMessageOnHit.TakeHit), (instance) =>
        {
            if (instance.gameObject.name != "GhostyGuy")
            {
                return;
            }

            if (instance.gameObject.activeSelf != false)
            {
                return;
            }

            AudioSource audsource;

            if (instance.transform.parent.gameObject.TryGetComponent(out AudioSource audioSource))
            {
                audsource = audioSource;
            }
            else
            {
                audsource = instance.transform.parent.gameObject.AddComponent<AudioSource>();
            }

            audsource.PlayOneShot(Assets.GetAudio("SoNeScheißeAua"));
        });

        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "INVALID", BavarianTranslationsFromJSON.Translate("INVALID"));
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Saves: {0}</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Saves") + ": {0}</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Loads: {0}</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Loads") + ": {0}</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Deaths: {0}</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Deaths") + ": {0}</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Specimen: {0}</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Specimen") + ": {0}</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Jumpscares: {0}</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Jumpscares") + ": {0}</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Distance: {0:F1}m</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Distance") + ": {0:F1}m</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "<nobr>Game Time: {0}</nobr> ", "<nobr>" + BavarianTranslationsFromJSON.Translate("Game Time") + ": {0}</nobr> ");
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), " (NICE)", BavarianTranslationsFromJSON.Translate(" (NICE)"));
        patcher.SetStringInMethod<SavePickerSave>(nameof(SavePickerSave.Start), "ROOM: {0}", BavarianTranslationsFromJSON.Translate("ROOM: {0}"));

        patcher.AddBeforeRun<UnknownSpec1FakeGameover2Controller>(nameof(UnknownSpec1FakeGameover2Controller.Awake), (instance) =>
        {
            instance.passwordInfo.password = BavarianTranslationsFromJSON.Translate("CLOSED");
        });
        patcher.SetStringInMethod<UnknownSpec1FakeGameover2Controller>(nameof(UnknownSpec1FakeGameover2Controller.PasswordEntryInputCoroutine), "OPEN", BavarianTranslationsFromJSON.Translate("OPEN"));



        patcher.AddAfterRun<CatDosCanvasController, string>(nameof(CatDosCanvasController.GetPromptText), (controller, result) =>
        {
            return BavarianTranslationsFromJSON.Translate(result);
        });
        patcher.SetStringInMethod<CatDosCanvasController>(nameof(CatDosCanvasController.SpecimenListDetailCoroutine), "Type: {0}", BavarianTranslationsFromJSON.Translate("Type: {0}"));
        patcher.SetStringInMethod<CatDosCanvasController>(nameof(CatDosCanvasController.SpecimenListDetailCoroutine), "Total Fatalities: {0}", BavarianTranslationsFromJSON.Translate("Total Fatalities: {0}"));
        patcher.SetStringInMethod<CatDosCanvasController>(nameof(CatDosCanvasController.SpecimenListDetailCoroutine), "Method: {0}", BavarianTranslationsFromJSON.Translate("Method: {0}"));

        patcher.SetStringInMethod<SavePoint>(nameof(SavePoint.OnInteract), "Saved", BavarianTranslationsFromJSON.Translate("Saved"));
        patcher.SetStringInMethod<SavePoint>(nameof(SavePoint.GetPromptText), "Save", BavarianTranslationsFromJSON.Translate("Save"));

        patcher.SetFloatInMethod<Rare04Phone>(nameof(Rare04Phone.Update), 4.6f, 16f);

        patcher.AddBeforeRun<HSMRoomReadyState.RoomRuntimeData>(nameof(HSMRoomReadyState.RoomRuntimeData.ConsumeRoomTitle), room =>
        {
            room.roomTitleString = room.roomTitleString.Replace("ROOM", BavarianTranslationsFromJSON.Translate("ROOM"));
        });

        patcher.SetStringInMethod<MsSpook>(nameof(MsSpook.WinCoroutine), "YOU WIN !", BavarianTranslationsFromJSON.Translate("YOU WIN !"));
        patcher.SetStringInMethod<MsSpook>(nameof(MsSpook.LoseCoroutine), "GAME OVER", BavarianTranslationsFromJSON.Translate("GAME OVER"));
        patcher.SetStringInMethod<MsSpook>(nameof(MsSpook.StartSequence), "GET READY", BavarianTranslationsFromJSON.Translate("GET READY"));

        patcher.AddAfterRun<SimpleInteractable, string>(nameof(SimpleInteractable.GetPromptText), (interactable, result) =>
        {
            if (interactable.promptText.key == "AMN_TOO_DEEP")
            {
                return BavarianTranslationsFromJSON.Translate("It's too deep");
            }
            return result;
        });

        patcher.SetStringInMethod<CatSpeaker>(nameof(CatSpeaker.GetPromptText), "Talk", BavarianTranslationsFromJSON.Translate("Talk"));

        patcher.AddBeforeRun<SpookyTalker>(nameof(SpookyTalker.Start), talker =>
            {
                UnityEngine.Debug.Log(talker.player.clip.name);
            });

        patcher.SetStringInMethod<SpookyKart>(nameof(SpookyKart.InGameUpdate), "TIME: {0:F0}", BavarianTranslationsFromJSON.Translate("TIME") + ": {0:F0}");
        patcher.SetStringInMethod<SpookyKart>(nameof(SpookyKart.InGameUpdate), "SPEED: {0:F0}", BavarianTranslationsFromJSON.Translate("SPEED") + ": {0:F0}");

        patcher.AddAfterRun<DollhouseGenericGameoverController>(nameof(DollhouseGenericGameoverController.Start), (instance, result) =>
        {
            instance.GetMember<List<string>>(nameof(DollhouseGenericGameoverController.killTexts)).Clear();
            instance.SetMember(nameof(DollhouseGenericGameoverController.killTexts), new List<string>
            {
                "Wer ko, der ko und wer ned ko, verliat hoid.",
                "Seng mas positiv: Du hast dem andern a Freide gmacht!",
                "Des war jetzt a klassischer Satz mit X... war wohl nix.",
                "Ned amoi Ignorieren host verdient mit der Leistung.",
                "hättst aa glei mit dei Fiaß im Gatsch stehn bleim kenna.",
                "is halb so wuid.",
                "Schreit koa Hahn danach.",
                "Mach d'Augn zua, dann sigst wos dia keahd."
            });
        });

        patcher.AddAfterRun<OptionsControllerButton>(nameof(OptionsControllerButton.InitWithData), (instance, args) =>
        {
            var controller = args.Get<Rewired.Controller>();
            if (controller == null)
            {
                return;
            }
            instance.text.text = BavarianTranslationsFromJSON.Translate(controller.name);
        });

        patcher.SetStringInMethod<SunshineAcademy>(nameof(SunshineAcademy.DoDayTransition), "DAY:   ", BavarianTranslationsFromJSON.Translate("DAY") + ":   ");
        patcher.SetStringInMethod<SunshineAcademy>(nameof(SunshineAcademy.DoDayTransition), "DAY: {0}", BavarianTranslationsFromJSON.Translate("DAY") + ": {0}");
        patcher.AddAfterRun<SunshineAcademy>(nameof(SunshineAcademy.StartGameImpl), (instance) =>
        {
            var SAC = instance.GetMember<SunshineAcademyConstants>(nameof(SunshineAcademy.constants));

            SAC.schoolRoute3Description = BavarianTranslationsFromJSON.Translate("schoolRoute3Description");
            SAC.schoolDefaultDescription = BavarianTranslationsFromJSON.Translate("schoolDefaultDescription");

            SAC.mini_text1[0] = BavarianTranslationsFromJSON.Translate("mini_text1_1");
            SAC.mini_text1[1] = BavarianTranslationsFromJSON.Translate("mini_text1_2");

            SAC.mini_pl_text1 = BavarianTranslationsFromJSON.Translate("mini_pl_text1");

            SAC.mini_text2[0] = BavarianTranslationsFromJSON.Translate("mini_text2_1");
            SAC.mini_text2[1] = BavarianTranslationsFromJSON.Translate("mini_text2_2");
            SAC.mini_text2[2] = BavarianTranslationsFromJSON.Translate("mini_text2_3");
            SAC.mini_text2[3] = BavarianTranslationsFromJSON.Translate("mini_text2_4");

            SAC.mini_text3[0] = BavarianTranslationsFromJSON.Translate("mini_text3_1");

            SAC.mini_pl_text2 = BavarianTranslationsFromJSON.Translate("mini_pl_text2");

            SAC.mini_text4[0] = BavarianTranslationsFromJSON.Translate("mini_text4_1");
            SAC.mini_text4[1] = BavarianTranslationsFromJSON.Translate("mini_text4_2");
            SAC.mini_text4[2] = BavarianTranslationsFromJSON.Translate("mini_text4_3");

            SAC.mini_pl_text3 = BavarianTranslationsFromJSON.Translate("mini_pl_text3");

            SAC.mini_text5[0] = BavarianTranslationsFromJSON.Translate("mini_text5_1");
            SAC.mini_text5[1] = BavarianTranslationsFromJSON.Translate("mini_text5_2");
            SAC.mini_text5[2] = BavarianTranslationsFromJSON.Translate("mini_text5_3");

            SAC.mini_text6[0] = BavarianTranslationsFromJSON.Translate("mini_text6_1");
            SAC.mini_text6[1] = BavarianTranslationsFromJSON.Translate("mini_text6_2");

            SAC.mini_pl_text4 = BavarianTranslationsFromJSON.Translate("mini_pl_text4");

            SAC.mini_text7[0] = BavarianTranslationsFromJSON.Translate("mini_text7_1");
            SAC.mini_text7[1] = BavarianTranslationsFromJSON.Translate("mini_text7_2");

            SAC.mini_pl_text5 = BavarianTranslationsFromJSON.Translate("mini_pl_text5");

            SAC.mini_text8[0] = BavarianTranslationsFromJSON.Translate("mini_text8_1");
            SAC.mini_text8[1] = BavarianTranslationsFromJSON.Translate("mini_text8_2");

            SAC.mini_text9[0] = BavarianTranslationsFromJSON.Translate("mini_text9_1");
            SAC.mini_text9[1] = BavarianTranslationsFromJSON.Translate("mini_text9_2");

            SAC.mini_pl_text6 = BavarianTranslationsFromJSON.Translate("mini_pl_text6");

            SAC.mini_text10[0] = BavarianTranslationsFromJSON.Translate("mini_text10_1");
            SAC.mini_text10[1] = BavarianTranslationsFromJSON.Translate("mini_text10_2");

            SAC.mini_text11[0] = BavarianTranslationsFromJSON.Translate("mini_text11_1");

            SAC.mini_pl_text7 = BavarianTranslationsFromJSON.Translate("mini_pl_text7");

            SAC.mini_text12[0] = BavarianTranslationsFromJSON.Translate("mini_text12_1");
            SAC.mini_text12[1] = BavarianTranslationsFromJSON.Translate("mini_text12_2");

            SAC.mini_pl_text8 = BavarianTranslationsFromJSON.Translate("mini_pl_text8");

            SAC.mini_text13[0] = BavarianTranslationsFromJSON.Translate("mini_text13_1");

            SAC.mini_pl_text9 = BavarianTranslationsFromJSON.Translate("mini_pl_text9");
            SAC.mini_pl_text10 = BavarianTranslationsFromJSON.Translate("mini_pl_text10");
            SAC.mini_pl_text11 = BavarianTranslationsFromJSON.Translate("mini_pl_text11");

            SAC.mini_text14[0] = BavarianTranslationsFromJSON.Translate("mini_text14_1");
            SAC.mini_text14[1] = BavarianTranslationsFromJSON.Translate("mini_text14_2");
            SAC.mini_text14[2] = BavarianTranslationsFromJSON.Translate("mini_text14_3");
            SAC.mini_text14[3] = BavarianTranslationsFromJSON.Translate("mini_text14_4");
            SAC.mini_text14[4] = BavarianTranslationsFromJSON.Translate("mini_text14_5");
            SAC.mini_text14[5] = BavarianTranslationsFromJSON.Translate("mini_text14_6");
            SAC.mini_text14[6] = BavarianTranslationsFromJSON.Translate("mini_text14_7");
            SAC.mini_text14[7] = BavarianTranslationsFromJSON.Translate("mini_text14_8");
            SAC.mini_text14[8] = BavarianTranslationsFromJSON.Translate("mini_text14_9");
            SAC.mini_text14[9] = BavarianTranslationsFromJSON.Translate("mini_text14_10");
            SAC.mini_text14[10] = BavarianTranslationsFromJSON.Translate("mini_text14_11");
            SAC.mini_text14[11] = BavarianTranslationsFromJSON.Translate("mini_text14_12");
            SAC.mini_text14[12] = BavarianTranslationsFromJSON.Translate("mini_text14_13");
            SAC.mini_text14[13] = BavarianTranslationsFromJSON.Translate("mini_text14_14");
            SAC.mini_text14[14] = BavarianTranslationsFromJSON.Translate("mini_text14_15");
            SAC.mini_text14[15] = BavarianTranslationsFromJSON.Translate("mini_text14_16");
            SAC.mini_text14[16] = BavarianTranslationsFromJSON.Translate("mini_text14_17");
            SAC.mini_text14[17] = BavarianTranslationsFromJSON.Translate("mini_text14_18");

            SAC.m2_mini_text1[0] = BavarianTranslationsFromJSON.Translate("m2_mini_text1_1");
            SAC.m2_mini_text1[1] = BavarianTranslationsFromJSON.Translate("m2_mini_text1_2");
            SAC.m2_mini_text1[2] = BavarianTranslationsFromJSON.Translate("m2_mini_text1_3");

            SAC.m2_mini_pl_text1 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text1");

            SAC.m2_mini_text2[0] = BavarianTranslationsFromJSON.Translate("m2_mini_text2_1");
            SAC.m2_mini_text2[1] = BavarianTranslationsFromJSON.Translate("m2_mini_text2_2");
            SAC.m2_mini_text2[2] = BavarianTranslationsFromJSON.Translate("m2_mini_text2_3");
            SAC.m2_mini_text2[3] = BavarianTranslationsFromJSON.Translate("m2_mini_text2_4");

            SAC.m2_mini_text3[0] = BavarianTranslationsFromJSON.Translate("m2_mini_text3_1");
            SAC.m2_mini_text3[1] = BavarianTranslationsFromJSON.Translate("m2_mini_text3_2");

            SAC.m2_mini_pl_text2 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text2");

            SAC.m2_mini_text4[0] = BavarianTranslationsFromJSON.Translate("m2_mini_text4_1");
            SAC.m2_mini_text4[1] = BavarianTranslationsFromJSON.Translate("m2_mini_text4_2");

            SAC.m2_mini_text5[0] = BavarianTranslationsFromJSON.Translate("m2_mini_text5_1");

            SAC.m2_mini_pl_text3 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text3");

            SAC.m2_mini_text6[0] = BavarianTranslationsFromJSON.Translate("m2_mini_text6_1");
            SAC.m2_mini_text6[1] = BavarianTranslationsFromJSON.Translate("m2_mini_text6_2");

            SAC.m2_mini_pl_text4 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text4");
            SAC.m2_mini_pl_text5 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text5");
            SAC.m2_mini_pl_text6 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text6");
            SAC.m2_mini_pl_text7 = BavarianTranslationsFromJSON.Translate("m2_mini_pl_text7");

            SAC.m3_mini_text1[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text1_1");
            SAC.m3_mini_text1[1] = BavarianTranslationsFromJSON.Translate("m3_mini_text1_2");

            SAC.m3_mini_pl_text1 = BavarianTranslationsFromJSON.Translate("m3_mini_pl_text1");

            SAC.m3_mini_text2[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text2_1");

            SAC.m3_mini_text3[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text3_1");
            SAC.m3_mini_text3[1] = BavarianTranslationsFromJSON.Translate("m3_mini_text3_2");

            SAC.m3_mini_pl_text2 = BavarianTranslationsFromJSON.Translate("m3_mini_pl_text2");

            SAC.m3_mini_text4[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text4_1");

            SAC.m3_mini_pl_text3 = BavarianTranslationsFromJSON.Translate("m3_mini_pl_text3");

            SAC.m3_mini_text5[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text5_1");
            SAC.m3_mini_text5[1] = BavarianTranslationsFromJSON.Translate("m3_mini_text5_2");

            SAC.m3_mini_text6[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text6_1");
            SAC.m3_mini_text6[1] = BavarianTranslationsFromJSON.Translate("m3_mini_text6_2");
            SAC.m3_mini_text6[2] = BavarianTranslationsFromJSON.Translate("m3_mini_text6_3");
            SAC.m3_mini_text6[3] = BavarianTranslationsFromJSON.Translate("m3_mini_text6_4");

            SAC.m3_mini_pl_text4 = BavarianTranslationsFromJSON.Translate("m3_mini_pl_text4");

            SAC.m3_mini_text7[0] = BavarianTranslationsFromJSON.Translate("m3_mini_text7_1");
            SAC.m3_mini_text7[1] = BavarianTranslationsFromJSON.Translate("m3_mini_text7_2");
            SAC.m3_mini_text7[2] = BavarianTranslationsFromJSON.Translate("m3_mini_text7_3");

            SAC.m4_mini_text1[0] = BavarianTranslationsFromJSON.Translate("m4_mini_text1_1");
            SAC.m4_mini_text1[1] = BavarianTranslationsFromJSON.Translate("m4_mini_text1_2");

            SAC.m4_mini_pl_text1 = BavarianTranslationsFromJSON.Translate("m4_mini_pl_text1");

            SAC.m4_mini_text2[0] = BavarianTranslationsFromJSON.Translate("m4_mini_text2_1");
            SAC.m4_mini_text2[1] = BavarianTranslationsFromJSON.Translate("m4_mini_text2_2");
            SAC.m4_mini_text2[2] = BavarianTranslationsFromJSON.Translate("m4_mini_text2_3");
            SAC.m4_mini_text2[3] = BavarianTranslationsFromJSON.Translate("m4_mini_text2_4");

            SAC.m4_mini_text4[0] = BavarianTranslationsFromJSON.Translate("m4_mini_text4_1");
            SAC.m4_mini_text4[1] = BavarianTranslationsFromJSON.Translate("m4_mini_text4_2");
            SAC.m4_mini_text4[2] = BavarianTranslationsFromJSON.Translate("m4_mini_text4_3");

            SAC.m4_mini_text8[0] = BavarianTranslationsFromJSON.Translate("m4_mini_text8_1");
            SAC.m4_mini_text8[1] = BavarianTranslationsFromJSON.Translate("m4_mini_text8_2");

            SAC.m4_mini_pl_text2 = BavarianTranslationsFromJSON.Translate("m4_mini_pl_text2");
            SAC.m4_mini_pl_text3 = BavarianTranslationsFromJSON.Translate("m4_mini_pl_text3");
            SAC.m4_mini_pl_text4 = BavarianTranslationsFromJSON.Translate("m4_mini_pl_text4");
        });

    }
}
