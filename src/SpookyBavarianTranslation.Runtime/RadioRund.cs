using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using SpookyBavaria;
using System.Collections.Generic;

public class RadioRund : MonoBehaviour, InteractableInterface
{
    public string radioUrl = "https://dispatcher.rndfnk.com/br/br1/obb/mp3/mid";
    public Mod bavmod = null!;
    private AudioSource sourceA = null!;
    private AudioSource sourceB = null!;
    private bool useSourceA = true;

    private string TurnOnString = BavarianTranslationsFromJSON.Translate("Turn radio on");
    private string TurnOffString = BavarianTranslationsFromJSON.Translate("Turn radio off");

    public string GetPromptText()
    {
        if (bavmod.isRadioOn)
        {
            return TurnOffString;
        }
        return TurnOnString;
    }

    // Token: 0x06000677 RID: 1655 RVA: 0x0001AEBC File Offset: 0x000190BC
    public void OnInteract()
    {
        bavmod.isRadioOn = !bavmod.isRadioOn;
        if (!bavmod.isRadioOn)
        {
            sourceA.Stop();
            sourceB.Stop();
            sourceA.clip = null;
            sourceB.clip = null;
            return;
        }
        StartCoroutine(RadioLoop());
    }

    void Awake()
    {
        sourceA = gameObject.AddComponent<AudioSource>();
        sourceB = gameObject.AddComponent<AudioSource>();

        sourceA.spatialBlend = 1;
        sourceB.spatialBlend = 1;
        sourceA.dopplerLevel = 0;
        sourceB.dopplerLevel = 0;
        sourceA.maxDistance = 300;
        sourceB.maxDistance = 300;

        // --- RADIO EFFEKT SETUP ---

        // 1. High Pass: Schneidet alles unter 500Hz ab (kein Bass mehr)
        AudioHighPassFilter hpA = gameObject.AddComponent<AudioHighPassFilter>();
        hpA.cutoffFrequency = 1000f;

        // 2. Low Pass: Schneidet alles über 5000Hz ab (dumpferer Sound)
        AudioLowPassFilter lpA = gameObject.AddComponent<AudioLowPassFilter>();
        lpA.cutoffFrequency = 5000f;

        // Das gleiche für Source B (da wir zwischen beiden hin- und herwechseln)
        // Hinweis: In Unity teilen sich Komponenten an einem Objekt die Filter, 
        // wenn du es perfekt trennen willst, erstelle zwei leere Child-Objekte für die Sources.
    }

    void Start()
    {
        if (bavmod.isRadioOn)
        {
            StartCoroutine(RadioLoop());
        }
    }

    IEnumerator RadioLoop()
    {
        // Wir starten mit einem kleinen Puffer
        yield return StartCoroutine(DownloadAndPlay(64));

        while (bavmod.isRadioOn)
        {
            // Danach laden wir alle 5-6 Sekunden nach
            yield return StartCoroutine(DownloadAndPlay(128));
        }
    }

    IEnumerator DownloadAndPlay(int sizeKB)
    {
        if (!bavmod.isRadioOn)
        {
            yield break;
        }

        string path = Path.Combine(Application.temporaryCachePath, "chunk" + (useSourceA ? "A" : "B") + ".mp3");
        AudioSource currentSource = useSourceA ? sourceA : sourceB;
        AudioSource otherSource = useSourceA ? sourceB : sourceA;

        using (UnityWebRequest www = UnityWebRequest.Get(radioUrl))
        {
            www.SendWebRequest();
            ulong target = (ulong)sizeKB * 1024;

            while (www.downloadedBytes < target && !www.isDone) yield return null;

            if (www.downloadHandler.data != null)
            {
                // Wir speichern die rohen Bytes. 
                // Der Trick: Wir fügen KEIN Padding an, sondern lassen die Datei 
                // so kurz wie möglich, damit der Header-Scan von Unity nicht verwirrt wird.
                File.WriteAllBytes(path, www.downloadHandler.data);
            }
            www.Abort();
        }

        // Jetzt kommt der entscheidende Teil: Wir nutzen einen "Buffer-Warte-Zyklus"
        // bevor wir den Clip überhaupt anfassen.
        yield return new WaitForSecondsRealtime(0.1f);

        using (UnityWebRequest loader = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.MPEG))
        {
            // Wir erzwingen, dass Unity die Datei NICHT streamt, sondern komplett lädt.
            // Das ist bei kleinen 128KB Chunks schnell genug und stabiler gegen Header-Fehler.
            ((DownloadHandlerAudioClip)loader.downloadHandler).streamAudio = false;

            yield return loader.SendWebRequest();

            if (loader.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(loader);

                if (clip != null && clip.loadState == AudioDataLoadState.Loaded)
                {
                    // Synchronisation
                    if (otherSource.isPlaying)
                    {
                        while (otherSource.time < otherSource.clip.length - 0.3f) yield return null;
                    }

                    // --- SPEICHER-OPTIMIERUNG START ---
                    // Wenn die aktuelle Source noch einen alten Clip hat, löschen wir ihn jetzt
                    if (currentSource.clip != null)
                    {
                        AudioClip oldClip = currentSource.clip;
                        currentSource.clip = null; // Verbindung lösen
                        Destroy(oldClip);          // Aus dem RAM löschen
                    }
                    // --- SPEICHER-OPTIMIERUNG ENDE ---

                    currentSource.clip = clip;
                    currentSource.Play();
                    useSourceA = !useSourceA;

                    Debug.Log($"<color=lime>Erfolg:</color> {clip.length:F2}s geladen.");
                }
            }
            else
            {
                // Falls FMOD wieder meckert, warten wir nicht, sondern versuchen sofort den nächsten
                Debug.LogWarning("FMOD Ignoriert. Lade nächsten Chunk...");
            }
        }
    }
}