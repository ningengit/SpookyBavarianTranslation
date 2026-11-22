using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpookyBavaria
{
    /// The mod's main object, like a BepInEx plugin: BavarianMod registers it with patcher.AddMod<Mod>(), so the game
    /// creates it once at startup on its own GameObject that survives scene changes.
    public class Mod : MonoBehaviour
    {
        public bool isRadioOn = false;

        /// The game's data folder: <game>_Data on Windows/Linux, <game>.app/Contents/Resources/Data on macOS
        /// (Application.dataPath would be .../Contents there, so it's taken from StreamingAssets, which sits inside the data folder everywhere).
        public static string DataFolder => Path.GetDirectoryName(Application.streamingAssetsPath)!;

        private void Awake()
        {
            PlainAndEasyInjector.Assets.ManifestRelativePath = "Bavaria/added_assets.json";

            // missing translations go to the game's log (Player.log) instead of the console
            BavarianTranslationsFromJSON.Log = message => Debug.LogWarning(message);
            // the editable translations the installer copied into the game
            BavarianTranslationsFromJSON.Load(
                Path.Combine(DataFolder, "Bavaria", BavarianTranslationsFromJSON.FileName));

            Debug.Log("Bavaria SJSM HD Mod");
            Debug.Log("Servus! you are running version 1.3.0 of my bavarian mod");

            var ModMainObj = new GameObject();
            GameObject.DontDestroyOnLoad(ModMainObj);

            //ModMainObj.AddComponent<ModExternalAssets>();

            //audio
            //Destroy(audio, 60);

            //var audsource = gameObject.AddComponent<AudioSource>();
            //audsource.clip = ModExternal.audioClips["Das Jägerlied"];
            //audsource.Play();

            //var gamObject = new GameObject();
            //GameObject.DontDestroyOnLoad(gamObject);
            //gamObject.AddComponent<RadioRund>();

            //ModExternalAssets.Load_PNG_From_Ressource_Into_Dictionary(PlainAndEasyInjector.Properties.Resources.KenneIchNicht, "KenneIchNicht");

            //SceneManager.sceneLoaded += MakeRadioScene;
        }

        private void MakeRadioScene(Scene scene, LoadSceneMode mode)
        {
            Debug.Log($"Loaded scene: {scene.name}");

            // Check for a specific scene
            if (scene.name == "HOS_HUB_Lightmapped")
            {
                var khradio = GameObject.Find("KHRadio");
                if (khradio == null)
                {
                    Debug.LogWarning("radio gameobject doesn't exist");
                    return;
                }

                var radioComp = khradio.GetComponentInChildren<RadioRund>();
                if (radioComp != null)
                {
                    Debug.LogWarning("found radio");
                    return;
                }

                Debug.LogWarning("made the radio");
                var RadioBoxinteract = new GameObject
                {
                    layer = LayerMask.NameToLayer("Interactable"),
                    name = "radio box"
                };
                //DontDestroyOnLoad(RadioBoxinteract);
                RadioBoxinteract.transform.position = new Vector3(10.3f, 0f, 16.5f);
                var boxcoll = RadioBoxinteract.AddComponent<BoxCollider>();
                boxcoll.isTrigger = true;
                boxcoll.size = new Vector3(1.5f*3, 1.5f*3, 1.5f*3);
                RadioBoxinteract.AddComponent<RadioRund>().bavmod = this;
                RadioBoxinteract.transform.SetParent(khradio.transform, true);

                //SceneManager.sceneLoaded -= MakeRadioScene;
            }

            if (scene.name == "DefaultMainMenu")
            {
                isRadioOn = false;
            }
        }
    }
}
