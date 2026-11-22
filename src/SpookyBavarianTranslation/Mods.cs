using AssetBundleModifier;
using SpookyBavaria.GameAssets;

namespace SpookyBavaria;

/// <summary>
/// All asset modifications applied by the installer before code patching.
/// </summary>
public static class ModList
{
    public static ModPlan BuildPlan()
    {
        var plan = new ModPlan();

        // ---- strings ----
        plan.Edit(EmScenes.HusksSpawn.Interactor_DollhouseModalInteractable).Update(x => x.promptText.defaultEn, BavarianTranslationsFromJSON.Translate);
        plan.Edit(Level0.LoadingText_TextMeshProUGUI).Set(x => x.m_text, "Lod d'Asset-Definitiona...");
        plan.Edit(Level0.WarningTitle_TextMeshProUGUI).Set(x => x.m_text, BavarianTranslationsFromJSON.Translate("WARNING"));
        plan.Edit(Level0.WarningText_TextMeshProUGUI).Set(x => x.m_text, "Des Spui enthoit blinkende Liacht, gewoitsame Inhoit und im Extremfall störende Sacha.\n\n\nHoffentlich gfiat’s da.");
        plan.Edit(Level1.Rewired_Input_Manager_InputManager)
            .ForEach(x => x._userData.actions, el => el
                .Update(e => e._descriptiveName, BavarianTranslationsFromJSON.Translate)
                .Update(e => e._negativeDescriptiveName, BavarianTranslationsFromJSON.Translate)
                .Update(e => e._positiveDescriptiveName, BavarianTranslationsFromJSON.Translate))
            .Set(x => x._userData.actionCategories[0]._descriptiveName, "Standard")
            .Set(x => x._userData.actionCategories[2]._descriptiveName, "Im Spui")
            .Set(x => x._userData.actionCategories[3]._descriptiveName, "UI Ned belegbar");
        plan.Edit(SharedAssets1.ModalRebind).Set(x => x.titleLocalizedText.defaultEn, "Knopfbelegung ändern fia {0}");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3042).Set(x => x.m_text, "Zrugg");
        plan.Edit(SharedAssets1.Action_TextMeshProUGUI).Set(x => x.m_text, "Wos's duad");
        plan.Edit(SharedAssets1.RankTitle_TextMeshProUGUI).Set(x => x.m_text, "Platz");
        plan.Edit(SharedAssets1.Sensitivity_TextMeshProUGUI).Set(x => x.m_text, "Empfindlichkeid");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3235).Set(x => x.m_text, "bestn 20");
        plan.Edit(SharedAssets1.TitleText_TextMeshProUGUI_3293).Set(x => x.m_text, "Knopfbelegung ändern fia {0} {0}");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3469).Set(x => x.m_text, "Spezl");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3505).Set(x => x.m_text, "Empfindlichkeid");
        plan.Edit(SharedAssets1.Alternate_TextMeshProUGUI).Set(x => x.m_text, "oder aa");
        plan.Edit(SharedAssets1.ScoreTitle_TextMeshProUGUI).Set(x => x.m_text, "Punktzahl");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3631).Set(x => x.m_text, "Mei Stand");
        plan.Edit(SharedAssets1.Binding_TextMeshProUGUI).Set(x => x.m_text, "Knopfbelegung");
        plan.Edit(SharedAssets1.TextMeshPro_Text_LocalizedTextComponent_3818).Set(x => x.localizedText.defaultEn, "Massenkontrolle");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3826).Set(x => x.m_text, "Nochrichtn im Spui zoagn");
        plan.Edit(SharedAssets1.DescriptionText_LocalizedTextComponent_3846).Set(x => x.localizedText.defaultEn, "Massenkontrolle erlaabt de Leit auf Twitch beim Spuin mitmischn, während du streamst. Wennst mehr wissn wuist, dann schau da des do o:");
        plan.Edit(SharedAssets1.Label_TextMeshProUGUI).Set(x => x.m_text, "Massenkontrolle");
        plan.Edit(SharedAssets1.CrowdControlStatusIndicator_3882)
            .Set(x => x.disconnected.labelText.defaultEn, "Ned verbunden")
            .Set(x => x.connecting.labelText.defaultEn, "Verbindet")
            .Set(x => x.needsToken.labelText.defaultEn, "Braucht Aktivierung")
            .Set(x => x.ready.labelText.defaultEn, "Bereit")
            .Set(x => x.error.labelText.defaultEn, "Fehler");
        plan.Edit(SharedAssets1.TextMeshPro_Text_LocalizedTextComponent_3898).Set(x => x.localizedText.defaultEn, "Gspeicherte Tokens löschen");
        plan.Edit(SharedAssets1.CrowdControlStatusIndicator_3934)
            .Set(x => x.disconnected.labelText.defaultEn, "Ned verbunden")
            .Set(x => x.connecting.labelText.defaultEn, "Verbindet")
            .Set(x => x.needsToken.labelText.defaultEn, "Braucht Aktivierung")
            .Set(x => x.ready.labelText.defaultEn, "Bereit")
            .Set(x => x.error.labelText.defaultEn, "Fehler");
        plan.Edit(SharedAssets1.DescriptionText_TextMeshProUGUI_3936).Set(x => x.m_text, "Massenkontrolle erlaabt de Leit auf Twitch beim Spuin mitmischn, während du streamst. Wennst mehr wissn wuist, dann schau da des do o:");
        plan.Edit(SharedAssets1.TextMeshPro_Text_LocalizedTextComponent_3939).Set(x => x.localizedText.defaultEn, "Vabinda");
        plan.Edit(SharedAssets1.DisclaimerText_LocalizedTextComponent_3961).Set(x => x.localizedText.defaultEn, "Im Karamari Krankenhaus und im Puppenhaus DLC wirkt de Massenkontrolle ned so gscheid");
        plan.Edit(SharedAssets1.TextMeshPro_Text_LocalizedTextComponent_3967).Set(x => x.localizedText.defaultEn, "Nochrichtn im Spui zoagn");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_3985).Set(x => x.m_text, "Gspeicherte Tokens löschen");
        plan.Edit(SharedAssets1.DisclaimerText_TextMeshProUGUI_4016).Set(x => x.m_text, "Im Karamari Krankenhaus und im Puppenhaus DLC wirkt de Massenkontrolle ned so gscheid");
        plan.Edit(SharedAssets1.Label_LocalizedTextComponent).Set(x => x.localizedText.defaultEn, "Massenkontrolle");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_4027).Set(x => x.m_text, "Massenkontrolle");
        plan.Edit(SharedAssets1.TextMeshPro_Text_TextMeshProUGUI_4045).Set(x => x.m_text, "Vabinda");
        plan.Edit(DollData.DollhouseNotesEnglish)
            .Set(x => x.kvps[0].defaultEn, "Herzlichen Glickwunsch GL Labs Mitarbeiter!\n\nDu wurdest fia unsa stolzes Eltern-Program ausgwäid worn.\n\nDu hast a Puppn kriagt, und dei Pflicht is, dassd de Sej dadrinn erziagst, de wo da gfanga is.\n\nDamit's in da Puppn drinbleibt, muaßst es bei guada Laun hoidn und Dornröschen singa. Vui von de Beta-Kandidatn warn Kinda, als se gestorben san, de wern si also ohne Groas gwiß glei an di hänga. Aba es ko sei, dass amoi a Strafe oda des Ozapfn von Geister-Energie nötig werd. Die Energie ko di gscheid aufladen, aba bitte treib's ned z'wuid, weil des am Geist ned guad duat.\n\nFalls de \"Husk\" des Ganze oablehnt oda wos bassiert, san de GL Labs unta koane Umständ schuid dadrann, obwoi des koa sinn macht aber muss aa ned.")
            .Set(x => x.kvps[1].defaultEn, "Tee-Stuberl fia stoize Eltern-Helfer.\nBedienungsanleitung\n\nDes Zimmerl is dafür da, dass man an Stress abbaut und d'Geistesenergie wieda aufladt, falls de Puppn an Schwung verlorn hod. Du kannst de Funktion nutzn, indemst de Puppn auf den Sockl stäist und di genau gegniba hihockst.\n\nIn the event of husk rejection or injury, GL labs is not responsible under any circumstance.\n\nFois de \"Husks\" abgelehnt wern oder jemand zu Schadn kommt, ibanimmt d'GL Labs unta koane Umständ de Verantwortung. obwoi des a schmarrn is.\n\nVui Spass, stoizer Elternteil!")
            .Set(x => x.kvps[2].defaultEn, "GL LABS ID 1863\nEINTRAG 23\n\nMia ham Fortschritte gmocht, aba optimal war davo gar nix. Mia ham a System entwickelt, um de Geista herzuwinken und einzusperrn, aba mia ham bis jetz no koa gscheide Hülln gfundn. Wia da Direktor sei Dochta s'erste Moi wieda vo de Toten herg'hoit hat, warma olle ganz staunig, aba lang is' ned do bliebn. Ohne ebbas Gscheids, wo de Geista an d'Erdn bindi, verflüchtigen de si oafoch wia da Rauch.\n\nZ'erst hamma's mit ganz normale Glasl, Vasn und so am Zeig probiert, aba de behälter ham de Geista in eanere Fähigkeitn total eigschränkt. A bisserl an Erfolg hamma ghabt, wia mia menschenähnliche G'fäß hergnumma ham, aba de Selln hängan imma no an de physikalischen Schadn vo dene behälter und desweng san's oafoch vui zu zerbrechlich.")
            .Set(x => x.kvps[4].defaultEn, "GL LABS ID 1863\nEINTRAG 24\n\n\nMia ham sakrische Probleme damit, oan vo de stärkan Gspenstn ozusperrn. De Puppn, de mia als G'fäß hernehma, ziagts imma wieda auseinander und geht hi, so dass mia den Geist jeds Moi wieda komplett nei heruafa miassn. Rein theoretisch sollt de Größn vom Behälta ja ganz wurscht sei, aba uns wird gsogt dass ois vui zu eng und zu kloa is.\n\nDesweng hamma's erst amoi hinta a Notfoi-Sperrdia weggasperrt.")
            .Set(x => x.kvps[5].defaultEn, "Den ganzn Dog war i a braves Mädl und hob no ma biebel glesn. Aber als ma Vada hoam kemma is, war er total meschugge. Desweng hab i mi in mei Zimmerl vergrom, bis er weg war. Und dann hab i eahm um 5:45 mitten ins Gsicht gschossn.\n\nSei Gwehr war so schee glänzend und sauber, und sei Gsicht war danach ganz gammelig, matschig und weich. I hätt gern no mehr Leit erschossn, aber mei Muada hat mi so miad gmacht. Jetz bin i in a komisches Haus mit de ganzn seltsama Weißkittel-Leit und de gebn mia oafoch koa Gwehr mehr.")
            .Set(x => x.kvps[6].defaultEn, "Mai Liabe Monica,\nObwois schwar war, hob i dei bittn respektiert und di ruhn lossn. I vamiss di jeden dog. I vamiss di. so sehr.\n\nI werd no versucha dei dochda zu retta. I woass des is ned wos du woitest, aba steck scho gscheid in da scheisse. Sie is so nah, I muass irgendwia a weg finda damit sie hier bleibt. \n\nDu bist mei Stern am Himme,")
            .Set(x => x.kvps[7].defaultEn, "GL LABS ID 1863\nEINTRAG 34\n\nDamit de Puppn bei Laun bleibn, hamma den 'Party-Raum' do hergricht. Mia ham sogoa extra an Geist herg'hoid, der's a bisserl unterhaltn soi, aba des Experiment is wirkli ins wossa gfalln.\n\nDe Puppn hassen den Ort da herinnat und san total g'schreckt, wia's den 'Clown' fei nur oschaung. I hob mir de Unterlang bstellt, wia de den ibahaubt g'fundn ham, und wia's ausschaut, wolltn de eigentlich an ganz an friedlichen, lustigen Menschengeist herbeinrufa, stattdessen hamma jetz a ganz andara kas do.\n\nSchaugt aus wia a Mensch, duat wia a Mensch, Zur Sicherheid hamma a Gitter drumrum baut. Was um Himmelswuin ham de da bittschee herg'hoit?\n")
            .Set(x => x.kvps[8].defaultEn, "GL LABS ID 1210\nEINTRAG 189\n\nI sieg sie. Ganz am Rand vo meim Aug.\nSobald i sie direkt oschau, zuckts und kimmt auf mi zua. Manchmal hia i sie fei hinta mia schnaufn.\n\nWia bin i bloß do herg'loffa? Is des unsane Straf dafia, dass mia den Tod ned ham gelten lassn? I hob doch allweil bloß Befehle befolgt.\nMei blinde Treue hat mi do herbracht... vielleicht hilft mia d'Blindheit ja aa wieda naus.")
            .Set(x => x.kvps[9].defaultEn, "GL LABS ID 1210\nEINTRAG 189\n\n\nI")
            .Set(x => x.kvps[10].defaultEn, "GL LABS ID 1863\nEINTRAG 46\n\n\nDe KIRA-Mega Drive is etz a totaler Klump.\n\nMia ham vui zu vui Geista herg'hoit, des packt de Maschinn einfach nimma. Sogoa wenn mia de wieda z'riackschicka, haut's uns vielleicht des ganze Tor zamm! Desweng hob i jetz 3 von de Ritual-Kerzn nunter im Erd-Kella gbracht. Des sollt den Beschwörungs-Schmarrn erst amoi aufhoitn.\n\nSpooky wird wahrscheinlich irgendwen losschicka, dass de des wieda herg'hoit, aba is ned mei Bier.\n\nChancen stehn eh aa guad, dass derjenige do druntn ned amoi ibalebt.")
            .Set(x => x.kvps[11].defaultEn, "Da Siegl is fast fertig, und dann kannste wieda zriackkemma.\n\nDamits aa geht, braacht's an Albtraum. Also opfere i meinen.\n\nDa gliche Albtraum, der di uns gnumma hod, bringt di wieda zriack.")
            .Set(x => x.kvps[12].defaultEn, "i hob an Bock gschossn i\nwoass des und du aa.\n\n\nI hoff du bist ned zu zwieder auf mi.\nDea Hofbräu Minga wars ned. Mei i woid hoid dei Vergebung.\n\n\nMei Liebe fia di hod mi krank gmacht, und am end hob i da nur dei Lem und ned-Lem gmaust.\nBitte geh weida, und bleib bei da Monica.\n\n\nI mecht mi am liabsten vergroam vor Scham.")
            .Set(x => x.kvps[13].defaultEn, "GL LABS ID 1210\nEINTRAG 187\n\nDe Geista wern fei grantig, mia miassn allweil wieda Rituale durchziang, damit mia de im Griff bheitn.\n\nWenns wieda narrisch wern, muass ma Druck auf de \"Husk\" ausiabn, wo da Geist drinnat steckt.\n\nVergiss ned, dass de Puppn koane echten Menschn san.")
            .Set(x => x.kvps[14].defaultEn, "GL LABS ID 54\nEINTRAG 809\n\n\nHoffentli werd i jetz, wo des Puppn-Projekt-Schmarrn vorbei is, boid wieda an die Oberflächn-Anlag versetzt. Intressant war's ja scho, aba ganz ehrlich hob i jedn Dog Angst um mei Lem. Des is jetz ned groad die beste Arbeitsplotzsicherheid.")
            .Set(x => x.kvps[15].defaultEn, "GL LABS ID 1863\nEINTRAG 32\n\nMia hom d'Idee mit da Puppn aufgem, wo mia des Versuchskaninchen an a physischn Gegenstand binden woitn. Stattdessn hobma ia Sej jetz direkt im Schloss sejba eisperrt. Ia Fähigkeitn do herinn im Labor miassn unvorstellbar sei. Da Herr Direktor wiad mit'm Ergebnis vo seim Opfer fei mehr ois zfriedn sein.")
            .Set(x => x.kvps[16].defaultEn, "GL LABS ID 54\nEINTRAG 67\n\nI hob's no koam erzäid, aba i glaab, in der Bude spukt's. Da drinnad gibts de ganze Zeid so komische, unheimliche Geraische. Des klingt wia a Jammarn, aba aa wia Woa, woasd? so a Woaman. Und do war des oane Buildl, wo i de ganze Zeid higstarrt hob, i denk des hod si vaändert nach a Zeid.")
            .Set(x => x.kvps[17].defaultEn, "A Puppn is wos Ewigs. Schaut aus wia a Kolleg, aber gans makellos gschaffn. Unsterblich und staad. Und fei drent dod, weil koa Seel drin is.\n\nA passends Symbol und womöglich a ganz nützlich's Werkzeig fia unsa Ziel do.\n\nBoid hob i di wieda bei mia, mei Schatz. Aba zearscht muass i sicherstäin, dass di des Ganze ned eisperrt.")
            .Set(x => x.kvps[18].defaultEn, "Nach dea ganzn Forscherei und de Experimente hobma am komplett foischn Ort gsuacht. De Puppn hom uns eigentlich bloß abglenkt. Mei Herz homs ned trösta kenna und fia di zum Eiziang war's aa ned. Genau desweng bist du ned zu mia zriackkumma.\n\nAba jetz hob i wos anders gfundn.\n\nA Relikt aus da oidn Kinigreich-Zeit, des wo de Geista an d'Ern feistmacht. Obwoi des urspriangli fia wos richtig Biass hergnumma worn is, werd i des fia di nutzn.");
        plan.Edit(DollData.DHMapOffhand)
            .Set(x => x.closeText.defaultEn, "Wegrama")
            .Set(x => x.mapText.defaultEn, "Hausplan")
            .Set(x => x.noMapText.defaultEn, "Es gibt do koa Hausplan ned");
        plan.Edit(DollData.DollhouseEnglish).ForEach(x => x.kvps, el => el.Update(e => e.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(DollScenes.FrenzyKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "Rasende Qual, meschugenna Verstand!\nBluat muass fliaßn, Knocha wern z'mahln!\n\nDes Fleisch g'fressen, damit de Zeit weidagacht,\nGewoit erzeugt Gegengewoit!");
        plan.Edit(DollScenes.SkunnyPuppi.KillText_TextMeshProUGUI).Set(x => x.m_text, "Säun aus gschmolzenem, verdrehtem Fleisch\nsan ausm Bodn kemma wia a Ameisn-Haufn,\nder von innen her am Kocha war.\n\nDa Blitz is schreind durch an \nHimme gfahrn, aba er is ned vergaunga\ner hod eher schwarze, marmorierte Narbn\nquer iaban Horizont hinterlassn.\n\nD'Luft is schwarer und schwarer worn\nbis s' zu ana festen Massn worn is\nde si unta deine Fiaß gwundn hat.\n\nDu hosd an Atem oghaltn.\nDu hosd deim Herrgott nimma traut.\nDu hosd dia seiba nimm traut.");
        plan.Edit(DollScenes.WireKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "Du bist so a Depp!");
        plan.Edit(DollScenes.DOLL_Nightmare.NightmareFloorManager_DollhouseNightmareControl)
            .Set(x => x.introLines[0], "I find die Worte ned.")
            .Set(x => x.introLines[1], "Die Nacht, wo i wie\na Wildviech reagiert hab")
            .Set(x => x.outroLines[0], "I ko  di ned verlian.")
            .Set(x => x.outroLines[1], "I bring di scho zriack.");
        plan.Edit(DollScenes.DOLL_LAB.Spooky)
            .Set(x => x.lines[0].subtitle.defaultEn, "hey Spetzl...")
            .Set(x => x.lines[1].subtitle.defaultEn, "I mogs hier ned.")
            .Set(x => x.lines[2].subtitle.defaultEn, "Schleich di am bestn.")
            .Set(x => x.lines[3].subtitle.defaultEn, "Also Sapallott! hier is nix fia di!")
            .Set(x => x.lines[4].subtitle.defaultEn, "... Jessas Maria -_-");
        plan.Edit(DollScenes.DOLL_NW.Spooky)
            .Set(x => x.lines[0].subtitle.defaultEn, "Oh hey... äh...")
            .Set(x => x.lines[1].subtitle.defaultEn, "I war am überleng,")
            .Set(x => x.lines[2].subtitle.defaultEn, "dass d' etwas hilfe brachst.")
            .Set(x => x.lines[3].subtitle.defaultEn, "Also, hob i de ganzn Puppen,")
            .Set(x => x.lines[4].subtitle.defaultEn, "aus'm weg g'rammt! :D")
            .Set(x => x.lines[6].subtitle.defaultEn, "Wünsche dir an Gaudi! OwO");
        plan.Edit(DollScenes.DOLL_1F.Spooky).ForEach(x => x.lines, el => el.Update(e => e.subtitle.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(EmScenes.UnknownSpec1FakeKillscreen.NoEscapeText_TextMeshProUGUI).Set(x => x.m_text, "DEA TOD IS KOA AUSWEG");
        plan.Edit(EmScenes.UnknownSpec5Killscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Ohne Dunkelheit ko ma ned trama.\nOhne Wähdam ko ma ned aufwacha.\nReiß dei depparte Fratzn ab.");
        plan.Edit(EmScenes.EMUnknownSpecimen2Spawn.KeyPizza)
            .Set(x => x.promptText.defaultEn, "MAMPFN")
            .Set(x => x.pickupText.defaultEn, "Gschmackig");
        plan.Edit(EmScenes.UnknownSpec1FakeKillscreen2.PlayerSpawn)
            .Set(x => x.passwordInfo.password, "ZUA")
            .Set(x => x.dialogLines[0], "Schau di o...")
            .Set(x => x.dialogLines[1], "Wie traurig.")
            .Set(x => x.dialogLines[2], "Dei Körper is komplett zuagspart.");
        plan.Edit(EmScenes.UnknownSpec3Killscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "HINTER DERA PFORTN ZUM HIMMELREICH LIEGT\nD'WAHRE WÄID.\nA WÄID, SCHEENER ALS JEDER DRAM...\nA WÄID WO DA HERRGOTT ALL DEI\nDIAFSTN SEHNSÜCHTE WAHR MACHT.\nA WÄID VOLLER GNAD’ UND\nDA GÖTTLICHEN PRACHT VON ALLE HEILIGEN...\nA WÄID WO D'HEILIGEN IM CHOR SINGEN,\nBLOSS UM DI IN IHRA GÖTTLICHEN MITTN AUFZUNEHMA.");
        plan.Edit(EmScenes.EndlessGenericGameover.JumpScaresLabel_TextMeshProUGUI).Set(x => x.m_text, "SCHRECKE:");
        plan.Edit(EmScenes.EndlessGenericGameover.SpecimenLabel_TextMeshProUGUI).Set(x => x.m_text, "ZIPFEL:");
        plan.Edit(EmScenes.EndlessGenericGameover.ScreenTitle_TextMeshProUGUI_591).Set(x => x.m_text, "ENDLOS MODUS");
        plan.Edit(EmScenes.EndlessGenericGameover.ScoreLabel_TextMeshProUGUI_592).Set(x => x.m_text, "RAUM:");
        plan.Edit(EmScenes.EndlessGenericGameover.TextMeshPro_Text_TextMeshProUGUI_598).Set(x => x.m_text, "Vorhärige Punktzahl ist besser");
        plan.Edit(EmScenes.EndlessGenericGameover.ScoreErrorReason_TextMeshProUGUI).Set(x => x.m_text, "Grund");
        plan.Edit(EmScenes.EndlessGenericGameover.ReportTitle_TextMeshProUGUI).Set(x => x.m_text, "ERGEBNISS");
        plan.Edit(KhData.HOSIngame).ForEach(x => x.kvps, el => el.Update(e => e.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(KhData.HOSNotes)
            .Set(x => x.kvps[0].defaultEn, "Dr. Ludwig\r\nOnkologe\r\n\r\n\r\nDea Patient hod erhiate Depressionen\r\ngzeigt nachdem dea mitbekomma hod\r\ndes ea a unheilbare Krankheit hod.\r\n\r\nI hob a Antidepressivum verschriam\r\num des zu bessan aba mia wurd späda\r\ngsogt des i des abgebrochn habe.\r\n\r\nI ko mi ned erinnern des i des gmacht\r\nhob. Hoban di an Vogel? oda bin I \r\nnarrisch?")
            .Set(x => x.kvps[1].defaultEn, "Dr. Ludwig\r\nOnkologe\r\n\r\n\r\nScheind so als ob des andre \"I\" ihm griaße\r\nmengn o Halluzinogen geban hod. \r\n\r\nSe ham de Depressionen vaschlimad und ea\r\nschreit und tut sei Angst ausdrückn\r\nwos aa zufällig ausschaugt.\r\n\r\n\r\nI hob probiert a Dialysegerät zu nutzn\r\num de Drogn zu wegdoan, aber bringt\r\nfei ned a moi wos, Jo mei!")
            .Set(x => x.kvps[2].defaultEn, "Dr. Korbinian\r\nHepatologe\r\n\r\n\r\nI wurd grod informiert des dea vorgang \r\nwo bei es rum geht de Leber vom Patient'n\r\nzu entfernen tödlich sei ko.\r\n\r\nI woas ned wieso...\r\nWarum ham ma sei Leber entfernt?\r\n\r\nEs gibt koane spende anfragn und dea hod\r\nBesserungen gzeigt.\r\n\r\nDea OP-Personal hom mi erzäid des i \r\nbefohlen hob sei Leber zu entfernen\r\nfia a notfall Transplantation, und des\r\nwuideste is des I es gfundn hob...\r\n\r\nI hob sei Leber gfundn, sei ganza Leber.\r\n\r\nDuad no wie bläd aaf ma Disch verrota...")
            .Set(x => x.kvps[3].defaultEn, "Dr. Shienazugawa\r\nHämatologe\r\n\r\n\r\nDea Patient is ned vo dea Blutverlust\r\nwieder fit gworda.\r\n\r\nI hob des gfühl des a Monster in ma Birne\r\nis und es versucht mi weg zu schubsen \r\nwährend es an etwos oabart.\r\n\r\nI bin in den Patienten Raam aufgwocht\r\nwo bei I iba iam gstandn bin während\r\na Arterienkatheter im Patienten woa,\r\nlässte iam nur am boden ausbluadn.")
            .Set(x => x.kvps[4].defaultEn, "Pflegefachfrau Sophia\r\nBericht \\#404\r\n\r\n\r\nScheind so als ob ma Patiente valiern\r\nwega 'chirurgische Komplikationen'\r\nvui iftas ois normal.\r\n\r\nWas ham de Doktorn gdoan?\r\n\r\nHälfte vo dea Eingriffe wirka sau\r\nunnötig. I woas des se iba mi san\r\nund vui wissen des i ned woas,\r\naber des kimmt ma spanisch vor.")
            .Set(x => x.kvps[5].defaultEn, "Pflegefachfrau Sophia\r\nBericht \\#405\r\n\r\nI bin in Ohnmacht gfoin, \r\nois i auf d'Arbeit gfahrn bin.\r\n\r\nZuerst fahr i no ganz normal de Straß \r\nnunda und auf oamoi, so wos konnst \r\ngar ned ausdenka, steh i scho draußn \r\nvor meim Auto und schau aaf a tote Katz \r\nnunda. Wahrscheinlich hob i’s mit’m Auto \r\ndawischt und mi hinteher scheiße gfuillt.\r\n\r\nDes Buidl vo dera Katz verfolgt mi bis \r\nheid und lasst mi nimma aus.\r\n\r\nWia hob i des Viech nur so dawischt kinna, \r\ndass’n den Körper sau komplett verdraht hod?")
            .Set(x => x.kvps[6].defaultEn, "Pflegefachfrau Sophia\r\nBericht \\#405\r\n\r\nEtwos Unheimliches lauert ganz tiaf \r\ndrin in meim Unterbewusstsein.\r\n\r\nEs schreit und wui, dass i \r\ndirekt in d'Höll nunda marschiar.\r\n\r\nVadda unsa im Himme, vagib uns \r\nunsa Schuid. Und fia uns ned in \r\nVersuachung, sondern erlös uns \r\nvo dem Biasn...")
            .Set(x => x.kvps[7].defaultEn, "Pflegefachfrau Sophia\r\nBericht \\#407\r\n\r\n\r\nI war des ned...\r\nI schwör’s beim Berch \r\nund beim Lem.\r\n\r\nEs miagn vielleicht mei Körper und \r\nmeine Händ gwen sei, aber i woas \r\nganz genau, dass i des ned war.\r\n\r\nHerr, nimm mei Hand und fia mi aus \r\nda Finsternis, damit mei Seel wieder \r\nrein werd.")
            .Set(x => x.kvps[8].defaultEn, "Pflegefachfrau Sophia\r\nBericht \\#408\r\n\r\n\r\nI hob herausgfund wie ma sie\r\naufhoitet.\r\n\r\nSchau sie san in ma Kopf und kinnan\r\nmi fia a bestimmte Zeid kontrollieren.\r\n\r\nAber wenn i ständig de Radiologie\r\nMaschine benutz um mei Birne mit \r\nStrahlung zu bestrahlen dann gengan\r\nsie fia a weile weg.")
            .Set(x => x.kvps[9].defaultEn, "Es duat ma so leid, mei kloanes Engel.\r\n\r\nI hob echt versucht, dass i den \r\nTypen hass, der di uns weggnumma hod. \r\nAber am End vom Dog konn i mi bloß no \r\nselber hassen.\r\n\r\nDu hosd es scho immer gmogt, \r\nauf d'Oktoberfest zu genga, vor allem \r\nweil’s di dena scheena und neier\r\nDirndl so bewundert hom. Du woitest \r\nunbedingt a Bier trinka, da hob i \r\ngsagt: 'Guad, aber bloß a alkoholfreies!' \r\nGschmeckt hod’s da, aa wenn ma’s sonst ned \r\noft g’kaaft hom. Du hosd gfeiert und gtanzt \r\nois Dinge, auf de i so sakrisch stolz bin.\r\nAber dieser Bua hod ohne Zweifel vui zu \r\nfuchsteufelswuid auf deinen Feuerwerkskörper \r\nreagiert. Aber mia kinna oane Person mit \r\nPTBS halt ned de ganze Schuid gem.")
            .Set(x => x.kvps[10].defaultEn, "I hass mi selber für des, was i do\r\n dua, aber i ko einfach \r\nnimmer lang warten.\r\n\r\nDei Muddi setzt zwar a tapfers Gsicht aaf, \r\naber i woas ganz genau, dass sie des aa so wui.\r\n\r\nI mach guade Fortschritte, damit i di wieder \r\nzruckbring, aber es schaut so aus, ois ob des \r\nbloß fia an kurzn Moment funktioniert sogar \r\nwenn i de Schwellenwerte länger einstell.\r\n\r\nHeid hob i de Antwort gfundn. Ma braucht a \r\nzweits Gerät, damit ma de Seel an d’Erden \r\nbindt, wenn’s erst amoi zruckbracht worden is. \r\nI woas, des klingt jetzt makaber, aber i werd’s \r\ndann scho wieder ausschoitn und di zarick in \r\nHimme schickn, nachdem dei Muddi und i di \r\nendlich wiedagseng hom.");
        plan.Edit(KhData.HOSSubtitles)
            .Set(x => x.kvps[0].defaultEn, "I woas ned, wia’d so weid unta kemma bist.")
            .Set(x => x.kvps[1].defaultEn, "I hob gar nimma gwusst, dass do unta no Zimma san.")
            .Set(x => x.kvps[2].defaultEn, "Na ja, vui Glück!")
            .Set(x => x.kvps[3].defaultEn, "Deser Oad is vui greßa ois i gdocht hob.")
            .Set(x => x.kvps[4].defaultEn, "Des is scho sehr...\nInteressant.")
            .Set(x => x.kvps[5].defaultEn, "Mach weida Rekrut, und i bin sicha dass du des schoffst.")
            .Set(x => x.kvps[6].defaultEn, "Möglicherweis...")
            .Set(x => x.kvps[7].defaultEn, "Ah, do bist ja!")
            .Set(x => x.kvps[8].defaultEn, "I glaab do gibts no a boa vasteckte Sachan.")
            .Set(x => x.kvps[9].defaultEn, "Mach hoid weida...")
            .Set(x => x.kvps[10].defaultEn, "Und mia schaugn moi wos bassiert.")
            .Set(x => x.kvps[11].defaultEn, "Jo...")
            .Set(x => x.kvps[12].defaultEn, "Pfiat di!")
            .Set(x => x.kvps[13].defaultEn, "Wie’s ausschaut, hoast de an andern Schliff.")
            .Set(x => x.kvps[14].defaultEn, "I bin scho sau long do... I hob scho so vui vagessn.")
            .Set(x => x.kvps[15].defaultEn, "Deser Oad... er muaß gschlossn wer’n.")
            .Set(x => x.kvps[16].defaultEn, "I woaß, dass du es schaffen kost, beeil di bloß. Du bist etzad so nah dro.")
            .Set(x => x.kvps[17].defaultEn, "Bitte...dua...mi...ned...weh")
            .Set(x => x.kvps[18].defaultEn, "Lass mi einfach in Ruah!");
        plan.Edit(KhScenes.MonsterSixKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Steh net vor Samsdog auf");
        plan.Edit(KhScenes.MonsterFourKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Finstare Würma schrein in meim Hirn.\nSie flehn mi o, dass i wieda friss.\nHerzn, Bluad, Galln und Erdn.\nI muas mi nährn, damit da Aufruhr aufhört.\n");
        plan.Edit(KhScenes.ScareChairKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Du erwachst in einer Wüste,\ndie nicht für dich bestimmt ist.\nDer Boden unter dir schreit,\nwie die Seelen im Fegefeuer.\nDer Himmel über dir reißt gewaltsam an dir,\ngleich dem Zorn des Herrn.\nUnd die Luft um dich herum presst sich herab,\nversucht, sich einen Weg hinein zu winden\nals ob der Atem des Teufels dich\nzum Abfall vom Glauben führen wolle.");
        plan.Edit(KhScenes.HOS_Lab.SchoolText_TextMeshPro_2027).Set(x => x.m_text, "dei Weib Ume Ito hod di fia dei verhalten\r\nan die Bulln gemeldet. Du wurdest ins\r\nKnast verfrachtet dazu zu a lemslanga \r\nFreiheitsstrafe verurteilt.\r\n\r\n\r\nHOSD NEIGESCHISSEN...");
        plan.Edit(KhScenes.MonsterFiveKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Deine Verpflichtung erlaabts mia, dei Hend zu kontrollieren.\nDeine Erwartung erlaabt es mia, de Wahrheit zu verbergen.\nDeine Rückgänge erlaabens mia, di einfacher zu kontrollieren.\nDeine Gründe erlaabens ma, dei Aung zu brechen.\nDeine Ignoranz erlaabt mia, dei Lem zu beenden.\nDeine Schwächen erlaaben es mia, di zu brechen.\nDeine Schuid erlaabts mia, deinen Hois zu lockern.\nDeine Tendenzen hom es mia ermöglicht,\ndass i dafür sorge dass du");
        plan.Edit(Mansionkillscreens.SpecEightKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Und i hob gseng mid Aung, de ma goa ned ghiat ham,\nUnd i hob a angst gspiad, de ma ned erklära konnt.\nSie luang uns zua und treibn si rum in unsara Gengand.\nUnd macha uns gliacklich, san jedoch blond.\nAn am Kini, den ma ned verdient ham.\nAn am Bua dea weinend wartet.\nDes wusst i, nachdem i wach wurde hob i des erwartet.");
        plan.Edit(Mansionkillscreens.SpecTenKillscreen.BinaryText_TextMeshProUGUI).Set(x => x.m_text, "01000100 01110101 00100000 01100010 01101001 \r\n01110011 01110100 00100000 01101101 01100101 01100001 \r\n01101000 01110010 00100000 01100001 01101100 01110011 \r\n00100000 01100001 00100000 01010100 01101001 01100101 \r\n01110010 00101110 00001010 01001110 01110101 01110100 \r\n01111010 01100101 00100000 01100100 01100101 00100000 \r\n01010011 01100101 01100101 01101100 01100101 00101100 \r\n00100000 01100100 01100101 00100000 01100100 01101001 \r\n01100001 00100000 01100111 01100101 01101101 00100000 \r\n01110111 01110101 01110010 01100100 00101110 00001010 \r\n01010101 01101110 01100100 00100000 11000011 10111100 \r\n01100010 01100101 01110010 01101110 01101001 01101101 \r\n01101101 00100000 01010110 01100101 01110010 01100001 \r\n01101110 01110100 01110111 01101111 01110010 01110100 \r\n01110101 01101110 01100111 00100000 01100110 01101001 \r\n01100001 00100000 01100100 01100101 01101001 00100000 \r\n01001000 01100001 01101110 01100100 01101100 01110101 \r\n01101110 01100111 01100101 01101110 00101110");
        plan.Edit(Mansionkillscreens.SpecTenKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Etzad host du nix meahr zu befürchten.\n Etzad musst du ned meahr nachdenken.\n Folge deinen egoistischen Wünschen.\n Folge deinem natürlichen Instinkt.\n Schließlich bist du eh a Tier.\n Des is vui einfacher, als zu versuchan, nachzudenken.");
        plan.Edit(Mansionkillscreens.SpecFiveKillscreen.PlayerSpawn_SpecimenFiveGameoverController).ForEach(x => x.deathLines, el => el.UpdateSelf(BavarianTranslationsFromJSON.Translate));
        plan.Edit(Mansionkillscreens.GoodEnding.SeriousText_TextMeshProUGUI).Set(x => x.m_text, "Hosd du wirklich gdocht, dass es ernsthaft enden würde?");
        plan.Edit(Mansionkillscreens.SpecElevenKillscreen2.KillText_TextMeshProUGUI).Set(x => x.m_text, "Mid jedn Biss, mid Boana und Haut,\nStöhnte und bebte da Dom erneid.\nSei heilige Statt tat ma leid.\nmit schlimman Wirkungen am ende da Zeid.");
        plan.Edit(Mansionkillscreens.SpecElevenKillscreen2.HellText_TextMeshProUGUI).Set(x => x.m_text, "mit schlimman Wirkungen am ende da Zeid.\nMa pfad a oanziga Gelegenheid.\nDes Fett, Öl, bluad wia es Schreid.\nA Liadl fia ewig lärm is Bereid.");
        plan.Edit(Mansionkillscreens.SpecElevenKillscreen2.KillBinary_TextMeshProUGUI).Set(x => x.m_text, "01000111 01101100 01100001 \r\n01110101 01100010 01100101 00100000 \r\n01100001 01101110 00100000 01000111 \r\n01101111 01100100 00101100 00100000 \r\n01100001 01100010 01100001 00100000 \r\n01101000 01101001 01101110 01110100 \r\n01100101 01110010 01100110 01110010 \r\n01101111 01100111 00100000 01100100 \r\n01100101 00100000 01001100 01100101 \r\n01101000 01110010 01100101 01101110 \r\n00100000 01100100 01100101 01100001 \r\n00100000 01001101 01100101 01101110 \r\n01110011 01100011 01101000 01101110 \r\n00101110");
        plan.Edit(Mansionkillscreens.SpecElevenKillscreen2.HellBinary_TextMeshProUGUI).Set(x => x.m_text, "01001110 01100001 01101000\n01110010 01110101 01101110 01100111\n00100000 01101110 11000011 10100100 01101000\n01110010 01110100 00100000 01100100 01100101\n01101110 00100000 01001011 11000011 10110110\n01110010 01110000 01100101 01110010 00101100\n00100000 01010111 01101111 01110010 01110100\n01100101 00100000 01101110 11000011 10100100\n01101000 01110010 01100101 01101110 00100000\n01100100 01100101 01101110 00100000 01000111\n01100101 01101001 01110011 01110100 00101110");
        plan.Edit(Mansionkillscreens.SpecThreeKillscreen.Manager_SpecimenThreeGameoverController)
            .Set(x => x.textLines[0].line, "Ammoi")
            .Set(x => x.textLines[1].line, "In am Land vo Träume")
            .Set(x => x.textLines[2].line, "Hob i g’meint, i kan frei sei")
            .Set(x => x.textLines[3].line, "Aba etz")
            .Set(x => x.textLines[4].line, "Da Hunger schlaft nia");
        plan.Edit(Mansionkillscreens.SpecTwoKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "I woaß, wos’d gmacht host, und wos da no bevorsteht.\nAba is scho ok, weil i bin etz in dir drin.\n\nMia san oans... aba i bin vui…");
        plan.Edit(Mansionkillscreens.NeutralEnding.TextMeshPro).Set(x => x.m_text, "Du fliachst ausm Irrnhaus und erzäist oin vo\nseim riesign laan Kella, de hohln Gänge,\nund dem oigmoan Mangl an Substanz.\n\nKoana glaubt da.\n\nOba du lebst weida…\n\n\nIrgendwia.");
        plan.Edit(Mansionkillscreens.SpecFourKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Sei staad, mei Kind, du bist in Sichaheid...");
        plan.Edit(Mansionkillscreens.Credits.WinLabel_TextMeshProUGUI).Set(x => x.m_text, "Du hosd’s geschafft!");
        plan.Edit(Mansionkillscreens.Credits.MansionSubtitle_TextMeshProUGUI).Set(x => x.m_text, "Des Irrenhaus");
        plan.Edit(Mansionkillscreens.Credits.KHSubtitle_TextMeshProUGUI_799).Set(x => x.m_text, "Karamari Krankenhaus");
        plan.Edit(Mansionkillscreens.Credits.MoiQuote_TextMeshProUGUI).Set(x => x.m_text, "Dankschee, dass i Teil vo diesem Projekt sei diafta!!");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_804).Set(x => x.m_text, "Kunst");
        plan.Edit(Mansionkillscreens.Credits.ModelsSubtitle_TextMeshProUGUI).Set(x => x.m_text, "3D Modelle & Textur'n");
        plan.Edit(Mansionkillscreens.Credits.NorboQuote_TextMeshProUGUI).Set(x => x.m_text, "I wui mi o meine ejdan bedank'n dass se ma unterstützn, Leid ausm SJSM kreis dass se mei werk meng und mi zu motivieren mehr zu doa und o Kira und Sheena weil die Burschn a spui gmacht ham des ma Inspiration gab fia modelling und zeichnen");
        plan.Edit(Mansionkillscreens.Credits.Promotional_TextMeshProUGUI).Set(x => x.m_text, "Werbe- und Erfolgsbuidl");
        plan.Edit(Mansionkillscreens.Credits.SouzouQuote_TextMeshProUGUI).Set(x => x.m_text, "Danke des i mitmacha diafte!");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_851).Set(x => x.m_text, "Albino Moose Games Logo Vorstellung");
        plan.Edit(Mansionkillscreens.Credits.KHSubtitle_TextMeshProUGUI_855).Set(x => x.m_text, "Des Katholische Haus\n");
        plan.Edit(Mansionkillscreens.Credits.FontCredit_TextMeshProUGUI).Set(x => x.m_text, "Des Katholische Haus nutzt d'schriftart \"Cartridge\" vom jeti\n");
        plan.Edit(Mansionkillscreens.Credits.MusicSubtitle_TextMeshProUGUI).Set(x => x.m_text, "Originale Mucke");
        plan.Edit(Mansionkillscreens.Credits.InLovingMemory_TextMeshProUGUI).Set(x => x.m_text, "A liebevolle Erinnerung o Aurora \"Paloma\" Rodriguez\nAug 15, 1924 - Oct 04, 2019");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_821).Set(x => x.m_text, "A herzliches Dank o");
        plan.Edit(Mansionkillscreens.Credits.ThanksForPlaying_TextMeshProUGUI).Set(x => x.m_text, "...und di fias spuin!\n...und natürlich aa meiner Mod!");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_831).Set(x => x.m_text, "Zusätzliche Programmierung");
        plan.Edit(Mansionkillscreens.Credits.SeanQuote_TextMeshProUGUI).Set(x => x.m_text, "Moin twitch chat!");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_842).Set(x => x.m_text, "Software-Tester");
        plan.Edit(Mansionkillscreens.Credits.InGameTimeLabel_TextMeshProUGUI).Set(x => x.m_text, "Spui Zeid:");
        plan.Edit(Mansionkillscreens.Credits.TeshnoQuote_TextMeshProUGUI).Set(x => x.m_text, "wann kimmt Sunshine Academy des eigenständige spui..?");
        plan.Edit(Mansionkillscreens.Credits.TravisThanksHeader_TextMeshProUGUI).Set(x => x.m_text, "Vuin Dank o Travis bis hi zu");
        plan.Edit(Mansionkillscreens.Credits.SheenaThanksHeader_TextMeshProUGUI).Set(x => x.m_text, "Vuin Dank o Sheena bis hi zu");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_866).Set(x => x.m_text, "Sprecher");
        plan.Edit(Mansionkillscreens.Credits.DemonChildLabel_TextMeshProUGUI).Set(x => x.m_text, "Dämon Kind");
        plan.Edit(Mansionkillscreens.Credits.Title_TextMeshProUGUI_871).Set(x => x.m_text, "Hauptentwickler");
        plan.Edit(Mansionkillscreens.SpecSixKillscreen.KillText_TextMeshProUGUI).Set(x => x.m_text, "Um in Minga bei am Theater teilzunehma hoasd,\ndassd de dei Handlung, Schuid und Verantwortung\nin da abfoikiwe schmeisst, wenns des ned wuist\nis wurscht, denn du ghearst ma.");
        plan.Edit(Mansionkillscreens.SpecSixKillscreen.HellText_TextMeshProUGUI).Set(x => x.m_text, "Mei Zwerge san dasoffn. also hob i dera gborgt.\nI hob se aufbewahrt, mi um dera zustand gesorgt.\nMa bohrmaschin des eich a neier kiaper verleihe.\nSei staad ma Bua, i setz a end zu dei Gschreie.");
        plan.Edit(Mansionroomdefs.Spec_1)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 1")
            .Set(x => x.kvps[1].defaultEn, "Freindlich")
            .Set(x => x.kvps[2].defaultEn, "Herzanfall")
            .Set(x => x.kvps[3].defaultEn, "A Pappfigur, de aus da Wand ausspringt. Hod si ned fei wirkungsvoll g’zeigt gegen g’sunde Leit.");
        plan.Edit(Mansionroomdefs.Spec_9)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 9")
            .Set(x => x.kvps[3].defaultEn, "TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE TOTEN HOLEN DIE")
            .Set(x => x.kvps[4].defaultEn, "Zipfel__");
        plan.Edit(Mansionroomdefs.Spec_7)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 7")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Nur Gott weiß, mia aba ned\r")
            .Set(x => x.kvps[3].defaultEn, "Der Zipfel verändert sich ständig in Form und Merkmale, abhängig vo de Persönlichkeit von der Preson. De meistgse Form is wie a Wand vo sich bewegenden Anatomiesymbolen. Is nur bei Leit guad, de wo a traumatische Vergangenheit oda a Geschichte mit psychische Probleme ham.");
        plan.Edit(Mansionroomdefs.Spec_6)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 6")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Physische Einstiche\r")
            .Set(x => x.kvps[3].defaultEn, "A hoizane Puppn in Lebnsgreß, de wo ma in am Stausee treibn gfundn hod, wo friara amoi a Stadt gwen is. Des Zipfel macht oan schmoan, obwoi's ned so ausschaut, und hod si ois sehr guad erwiesen geng Leit, de wo's ignorian oda de wo schlecht segn kenna.\r");
        plan.Edit(Mansionroomdefs.Clock)
            .Set(x => x.kvps[0].defaultEn, "Wos is'n des?\n\nOha, was fia a riesigs Haus!\r\nIn an andam riesign Haus.\r\n\r\nVielleicht bin i ja\r\nam End vom Haus oam kemma.\r\nVielleicht is des hier so was wia\r\na Ruheplatz oda an andam Eingang?\r\nWie au imma, i find, des is a\r\nguad Ort, um si auszuruhn.")
            .Set(x => x.kvps[1].defaultEn, "Desa Herrenhaus is seltsam...\n\n\nI glaab, de Ziagl und des Holz\nsan nur aufgmalt. Ois hoit irgendwie\nkoa richtigs Gfühl. Außerdem hör i\nständig Gräusch und Stimm unter mir.\nVielleicht versteckn si da\nuntn andre Owalebende!")
            .Set(x => x.kvps[2].defaultEn, "I ko ihn hören! ea kimmt \r\ndo runter vom gang! I muass mi \r\nvasteckn I woaß aber ned wo.\r\n\r\nI woaß dass des ned a Ausgang is\r\noder zuam ausruhan. Nur a weiterer\r\nbescheierter zipfel Raum!\r\n\r\nI glaab ea is jetzat draußen.")
            .Set(x => x.kvps[3].defaultEn, "I hobs gschoft weggart zu kemma.\r\nFia wie Long? woass i ned.\r\n\r\n\r\nI hör ihn, obwoi I woass dass\r\nea ned hier is. Is wie als wäre\r\nea ned echt aber staddesn sans \r\nmeine eignen Ängste de sich\r\nsichtboar mochan und mi verfolga.")
            .Set(x => x.kvps[4].defaultEn, "I hob a Theorie.\r\n\r\nI denk es ist desa\r\nunechten Quatsch-hoam.\r\nI denk es spuit mit \r\nma Birne.\r\n\r\nI hör ihn no…\r\nI muass ihm umbringa\r\nmit dea Sichel den i \r\ngfunden hob in den \r\nWoid...\r\n\r\nAber des is nur \r\na Theorie!\r\na Spui Theorie! \r\nDanksche fias lesen!");
        plan.Edit(Mansionroomdefs.BaseMansion)
            .Set(x => x.passwords[0].password, "NACHTALB")
            .Set(x => x.passwords[1].password, "LEBERKAS")
            .Set(x => x.passwords[2].password, "SEMMEL");
        plan.Edit(Mansionroomdefs.Spec_9_Alt)
            .Set(x => x.kvps[1].defaultEn, "Macht unsinn")
            .Set(x => x.kvps[2].defaultEn, "Verschiden")
            .Set(x => x.kvps[3].defaultEn, "Ein Überlebender aus den Experimenten, die im Einheit 731 durchgeführt wurden. Exemplar 9 wurde in einem verfallenen Bauernhaus in Russland gefunden. Exemplar 9 scheint sich von Toten oder Leichen angezogen zu fühlen und scheint aus einer lehm-ähnlichen Substanz zu bestehen, die ihre Dichte verändert.\n\n\nDie Einschließung ist bisher noch nicht erfolgreich gewesen, aber das Exemplar hat sich als äußerst effektiv gegen alle Versuchspersonen erwiesen.");
        plan.Edit(Mansionroomdefs.WakeGelSpawn_LocalizationPatch)
            .Set(x => x.kvps[0].defaultEn, "Spritz’n, Platschn, geleeartig.\n\nInnerein, Fress’n, Beschwören.\n\nNageln, Nie, hört’s Würgen ned aaf")
            .Set(x => x.kvps[1].defaultEn, "ERROR 002313FB_GEL.\nZWEIMAL LOSLASSN GEHT NED.\nGEH RAUS ÜBER’N EXPRESS-WEG.");
        plan.Edit(Mansionroomdefs.Woods)
            .Set(x => x.kvps[0].defaultEn, "A Zeid long hob i gdocht, i waar\nwirkli dem Ort entkomma.\nAba trotz de „Baam\" und da\nFlora glaab i, dass des eigentli\nnur a weitara Raum is. I hob oba\nRehe gfundn, also werd i\nwenigstens wos zum Essn kriagn.\n\n\nOba sie machad komische\nGrausch...")
            .Set(x => x.kvps[1].defaultEn, "I hob koa Ahnung, wos für Tiere des san,\r\nowa des san definitiv koa Rehe!\r\nNeilich hob i versucht, mia an ains\r\nranzuschleichen, ums z’essn, owa’s\r\nhod mi glei gsehn, als i in seine Näh kam.\r\nI hob grod no recht fliehn kenna vor dem Dings.\r\n\r\nI hob’s glei gschafft, die meistn von eana\r\neinzuschperren.\r\nHoffentlich find i a andern Weg hier raus.");
        plan.Edit(Mansionroomdefs.Food)
            .Set(x => x.kvps[0].defaultEn, "1.\r\nI wa anfongs sehr beängstigt,\r\n hier a Stelle zu bekimma, aber\r\nes scheint, als würden de Dinge\r\nbesser wern. Diese Kette\r\n expandiert wia a sau, scho\r\nkomisch denn erst letzt Wocha hob\r\ni ghört, dass des Unternehmen\r\n pleite gehen wiad. Jeda Dog\r\nkimma mehr und mehr Leit, um hier\r\nz'essa. Etwos stimmt aber immer\r\n noch ned mit dem Ort und da Essa,\r\ndeshalb werd i versuachn,\r\nnix vo hier z'essa.")
            .Set(x => x.kvps[1].defaultEn, "2.\r\nSo Meddl loide \\m/...\r\n\r\nI mog koane Hamburger i mog \r\neigentlich koane Burger I ess \r\nkoane Burger i mag de eigentli ned \r\nes gibt scho moi selten welche \r\ndos i se esse aber im normalfall\r\ni lieb Cheeseburger \r\nhasse aber alle andere Burger \r\nhoaßt aber ned dass i etzat aa \r\nanderen Burger deswegen...\r\n\r\nwoaßt wos i moan?")
            .Set(x => x.kvps[2].defaultEn, "3.\r\nNun heid hab i oa vo ma Regeln\r\ngbrocha. Jo i bin hoid rauß \r\nganga aber is hoid ned erlaabt\r\ndigga do is ned ammoi a Klimaanlage\r\nund sehr stickig hier drinn is aa\r\nalso wirkli wos machn se?\r\nA Ventilator kennan sie wenigstens\r\ndo installieren oder ned?\r\nEgal i hab heid a vo diesen Burgern\r\ngemampft sie schmeckan guad.\r\nwerd so a paar moi vielleicht \r\nmir sie gönnen.")
            .Set(x => x.kvps[3].defaultEn, "4.\r\nWos zuam geier?...\r\n\r\nI hob letzt nocht a Traum vo diesen \r\nRestuarant g'habbt I hörte Tier\r\ngreische manche von dennan wie\r\na Kuh wenn sie stirbt, ois wa so\r\nkomisch wie sau nix in de richtigan\r\ngriaße und ois sah so foisch aus.\r\nDazu is no das so a Typ so\r\n20x durch den drive-thru gangn\r\nis und jede 10 Minuten den\r\nselban Quatsch kafft bro tut der\r\nGeld zauban oder wos?")
            .Set(x => x.kvps[4].defaultEn, "5.\r\nHeid gab's was richtig \r\nMerkwürdiges. Und i hab\r\nden Sinn ned ganz kapiert...\r\n\r\nI war hoit in da Pause und\r\nzwo Kollegn ham gredt, ob\r\ndes Restaurant Germknödel\r\noder Zwetschgendatschi aufs\r\nMenü bringt. Kurz gsagt, se\r\nham sich do entscheida, des\r\nz'macha aba aus irgendweiarn\r\nGründen is des Fleisch\r\nverschwunda, wobei ma sogar \r\nfürn Transport und ois\r\ngzoit ham.\r\naba so a scheiß!")
            .Set(x => x.kvps[5].defaultEn, "6.\r\nDes is a scam.\r\n\r\nI hab jetzt scho ungfähr 50\r\nBig Tastys gegessen, und die\r\nwoarn imma warm und lecker. Heid\r\nhatt i ma ersten Big Tasty:\r\nDer Käse woar scho an da Verpackung\r\nfestgeschmolzen, des hoaßt, der hot\r\ndo scho 20 Minutn rumglegen.\r\nDieser Big Tasty hot fei nix mehr mit\r\nam Big Tasty zu tun außer dem\r\nAussehen, I hob aa Komische\r\nBilder vo irgend so nem Typen oder\r\nnem Tier gseng.");
        plan.Edit(Mansionroomdefs.Secret_Spec_3)
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Brandstiftung")
            .Set(x => x.kvps[3].defaultEn, "A unfeatige Videospui-KI, vo dera ma glaabt, dass sie an Code drin hot, dea vo am obgbrochenan Kriaggsexperiment gstohln worn is.\n\nHod bei a boa Leit guat gewiakt, oba a boa hom's ned vastandn und hom's ignoriert.");
        plan.Edit(Mansionroomdefs.End_Subtitles).ForEach(x => x.kvps, el => el.Update(e => e.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(Mansionroomdefs.Spec_12)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 12")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Verschiedn\n")
            .Set(x => x.kvps[3].defaultEn, "A oite, Schanze vom Drachenlord, des scheinbaa um sei Umgebung herum aufbaut hod. Der Zipfel wählt mol jemand zum kontrollieren aus, den’s in Bsuiz nimmt, und nutzt den, um de Subjekte mit vaschiedenen Mittln ozugreifa, je noch de Eignschaftn vom Typen. Üba den Ursprung der Schanze is ned viel bekannt, owa’s gibt a mal Anzeichen, dass in der Drachenschanze früher a Massaker oda a Tragödie war. Hod si ois sehr effektiv erwisn, voriert owa z’oft, um a zuverlässige Method z’sei, zum Extrahier’n.\r");
        plan.Edit(Mansionroomdefs.PTNote_LocalizationPatch).Set(x => x.kvps[0].defaultEn, "Des woa so a Überraschung.\nDass es an weitern Eitrog gem wiad.\nAn weitern echtn Eitrog.\nAn, den i bewundern hob kenna.\n\n\nOba dann is a so plötzli verschwundn, wia a kemma is.\nUnd jetzt löst's eich auf.\n\n\nEier Einfluss und eire Inspiration werdn mi\nniemals valossn.");
        plan.Edit(Mansionroomdefs.SH)
            .Set(x => x.kvps[0].defaultEn, "Die Dunkelheid verschlingt\nuns jetz langsam.\nI glaab ned, dass unsere Rituale\nsie no lang besänftigen\nkenna. Wia hätten wir\nwissn soin, dass des\npassieren würd?")
            .Set(x => x.kvps[1].defaultEn, "O felix statua feminae,\nO felix statua feminae nobilis.\nO felix statua feminae,\nstatua feminae felix\nstatua feminae nobilis.\nSedes es Petri, qui Christi\nvicem gerit, Sedes es Petri,\nqui apostolus est Pacis.\nPontifex tecum erimus omnes\nnos Pontifex es magister qui\ntuos confirmas fratres. Pontifex\nfundamentum ac robur nostrum,\nHominumque piscator pastor es\ngregis ligans terram et coelum.\nPetre tu es Christi es Vicarius\nsuper terram, Rupes inter\nfluctus, tu es pharus\nac veritas. Tu Christi es\ncaritas, tu es unitatis\ncustos, Promptus libertatis\ndefensor; in te auctoritas.\nO statua feminae nobilis\nO statua feminae felix nobilis\n")
            .Set(x => x.kvps[2].defaultEn, "Es is ned wirklich unsre Schuld,\nma hobm nur g’macht, wos Mutter\nuns in so am Situation gsogt hod.\nMutter is ned zufriedn mit\r\nuns, aber wia hätt’n\r\nwir wissn soin, dass das\r\nMädl ned rein war?");
        plan.Edit(Mansionroomdefs.Spec_8)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 8")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Aufnehmen\r")
            .Set(x => x.kvps[3].defaultEn, "A wiaandn Gestalt, de wiaa Joahr, nomoi de Testkammr mit aafoch nua ungewöhnlich aggressivn Hirsche gfüllt worn is, in dera erschienen is. Der Zipfel scheint de Vaversuchojekte z’verschlinga und in seinm Obakörpabezirk z’absorbiern. Hat si bei aggressivn Vaversuchobjektn ois äußerst wiaksum erwisn.\r");
        plan.Edit(Mansionroomdefs.Amn)
            .Set(x => x.kvps[0].defaultEn, "Forschungsbericht I\r\n\r\nNo mehra Wale wern morgen\r\ng'bracht, oan fia gesundheits\r\nInspektion und zwoa fia die \r\nscho tot san aber mia autopsieren\r\nse. \r\n\r\nNo weitere gestrandete Wale\r\nkimman imma wieda rund um diese\r\nInsel und i ko imma no ned\r\nherausfinda wea oder wos des\r\nverursacht.")
            .Set(x => x.kvps[1].defaultEn, "Forschungsbericht II\r\n\r\nWal 014-D hod a Boa extrige\r\nbieße. vo a kloanaren Säugetier \r\nkimman sie wahrscheinlich. aber\r\netwos wos sehr komisch is, is de\r\nPlatzierung sie san in a geraden \r\nReihe im Magen alle ungfähr so\r\neineinhalb meda vo den\r\n'Unteren Bereich' dea Magen-\r\nschleimhaut.")
            .Set(x => x.kvps[2].defaultEn, "Forschungsbericht III\r\n\r\nWal 015-A lebt no aber dea\r\nhod iftas hia und do \r\nSchloganfälle und kimmt vui\r\nifta an dea Oberfläche ois\r\ngewöhnlich. Dea kinnt a \r\nProblem mit de Lungen haben \r\naber I hob Koa Werkzeuge per\r\nHand grod ohne dos i jetzt\r\nsterben wiad. \r\n\r\nI miass erlauben dos ea stirbt\r\nvo was aa immer des duad.")
            .Set(x => x.kvps[3].defaultEn, "Forschungsbericht IV\r\n\r\nWal 015-D starb vui friara\r\nals i erworted hob i hob\r\ng'docht dea werd scho länger\r\nleben als i im Urlaub woa \r\nin dea Schweiz. Des Team\r\nhod gsogt des de Lungen\r\nOkay san aber dea Bauch hod\r\na rießiga Loch so ungfähr a \r\nhalben meda der Durchmesser\r\ntotal duach dem Wal.\r\n\r\nDes hoaßt des a parasid dro \r\nschuid is warum dea starb.")
            .Set(x => x.kvps[4].defaultEn, "Forschungsbericht V\r\n\r\nDe Forschungseinrichtung braacht \r\ndringend no mehra Ingenieure. \r\nA ganza Gebäudeteil is untawossa, \r\nund a boa wichtige Leit wern vermisst.")
            .Set(x => x.kvps[5].defaultEn, "Forschungsbericht VI\r\n\r\nI hia a mädl.\r\nOder a Tier.\r\nOder sowos…\r\n\r\nSing zu mia, bittet des\r\nI aus ma Zimmer raus kemma\r\nund de wogendn Wellen\r\nmia beruhiga loss'n.")
            .Set(x => x.kvps[6].defaultEn, "Forschungsbericht VII\r\n\r\nAll Personal is weg \r\ngeganga. Nur i bin do.\r\nFia Koa zweck, bleib i do.\r\nwiedasetz' den Ruf hinta\r\ndem versiegeltn Dia\r\n\r\nAber i bleib do...\r\nfia so Long wie i ko.\r\nMach ned dese Dia aaf.")
            .Set(x => x.kvps[7].defaultEn, "Ausschnitt 4132\r\nUnd do hob i ihn gseng! i woa\r\nin Raum 1000 und do kam er!\r\n\"etwos ging kaputt\" sogt er\r\nDes woa dea! \r\ndea Pizza liferant!\r\n\r\nEa hot mi in de Fressn gschlong!\r\ndea bastard! Paar räume späda\r\nwird ea sau aggressiv und rennt \r\nauf mi zua! i glaab i bin in dea\r\nHölle...");
        plan.Edit(Mansionroomdefs.Special_N3394874571739135542)
            .Set(x => x.kvps[0].defaultEn, "O")
            .Set(x => x.kvps[1].defaultEn, "Aus")
            .Set(x => x.kvps[2].defaultEn, "Boarisch")
            .Set(x => x.kvps[3].defaultEn, "Russisch")
            .Set(x => x.kvps[4].defaultEn, "Spanisch")
            .Set(x => x.kvps[5].defaultEn, "Deitsch")
            .Set(x => x.kvps[6].defaultEn, "Japanisch")
            .Set(x => x.kvps[7].defaultEn, "Polnisch")
            .Set(x => x.kvps[11].defaultEn, "Generell")
            .Set(x => x.kvps[12].defaultEn, "Grafik")
            .Set(x => x.kvps[13].defaultEn, "Eingabe")
            .Set(x => x.kvps[14].defaultEn, "Französisch")
            .Set(x => x.kvps[15].defaultEn, "Niederländisch")
            .Set(x => x.kvps[17].defaultEn, "Im Spui");
        plan.Edit(Mansionroomdefs.Spec_4)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 4")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Fresserei\r")
            .Set(x => x.kvps[3].defaultEn, "A Japaner-zipfel-Geist ausm 14. Jahrhundert, den’s ei’fangt ham und jetz do eing’sperrt ham. De Versuach ham no ned rausgfundn, woher der eig’ntlich kimmt, aber ois, wos relevant is, ham’s ins Test-Kammerl neiglegt. Hod si als wirkungsvoll erwiesen, aber ned vui besser ois de voherig’n Zipfelklatscher.");
        plan.Edit(Mansionroomdefs.Special_N1497641068856586445).Set(x => x.kvps[2].defaultEn, "Idioma bávaro");
        plan.Edit(Mansionroomdefs.School_LocalizationPatch)
            .Set(x => x.kvps[0].defaultEn, "Matsuri is heid ned zum\nUnterricht kemma, I hoff sie\nis guad hoam kemma.")
            .Set(x => x.kvps[1].defaultEn, "Könnt’s wirklich wahr sei?\nI hab gdocht, de Märchen\nvom Geist, der Kinda frisst\nwos si nochm Unterricht einschleim\ndienen nur dazu uns\ndavo obzuhalten, ungehorsam z’sei.\nAber Matsuri wird\nimmer no vermisst. wos is a des?");
        plan.Edit(Mansionroomdefs.TropesNotes)
            .Set(x => x.kvps[0].defaultEn, "I hob so paar Tiere gseng die i\r\neigentli ned zuvor gseng hob.\r\n\r\nSo a Wolpertinger den ma eigentli \r\nnur so kinnt aber anscheinend gibts \r\nden in echt aa... \r\nvalier i den verstand oder ned?")
            .Set(x => x.kvps[1].defaultEn, "Als i aaf de Alpen war hab i ihn doch\r\ngseng er hod mi do hi gbracht... \r\n\r\nI denk Gott wui dos i wos rausfind \r\nals 'Hauptfigur' werd i warscheinlich \r\nIrgendwelche zauberein veranstallten.\r\n\r\n'Pack do ne unbekannte horror\r\nanspielung einne de konna versteht \r\nund denkt sie sein Anleitungn'")
            .Set(x => x.kvps[2].defaultEn, "I hob des Fabelwesa no ned gfunda aber\r\nI bin wahrscheinlich jetzat, \r\nder Protagonist wäre super... \r\n\r\nI hoff i bin koa unnötiger neben \r\ncharakter der nur do is und quatsch \r\nlabbert.\r\n\r\nI hob aa an komischn Computer gfunda\r\ndes so Beschreibungen vo de zipfeln gibt. \r\ndie schaung alle total scheisse aus.\r\naa schmincke tuads aa ned helfa.")
            .Set(x => x.kvps[3].defaultEn, "I glaab wie \"effektiv\" sie san\r\nhod aa wos damit zu tua mit de\r\nSeelen vo dena Lei'd sie töten\r\n\r\nNun i bin no fit wie a Turnschuh,\r\nI denk ma Reise hod grad erst \r\nbegunna und es erwartet mi a haffn\r\nzeig.\r\n\r\nI frog mi wie der Antagonist\r\nausschaung tat.\r\n\r\nI hoff der oder die is goidig.")
            .Set(x => x.kvps[4].defaultEn, "Mia is grad klar gworn, dass i nie a\r\nMentorfigur, a Prüfung oder a \r\nSzene hatte, in der i vo dahoam \r\nweggeganga bi und vielleicht war das mit\r\ndem Fabelwesen a streich.\r\n\r\nDes hoaßt, dass diese Geschicht' ned den\r\nArchetypen folgt, die mi zu a\r\ntraditionelln Helden mochan würdn.\r\n\r\nDes hoaßt, dass i getötet wern ko.\r\n\r\nNun, war es fia kurze Zeid schee.");
        plan.Edit(Mansionroomdefs.Secret_Spec_1)
            .Set(x => x.kvps[0].defaultEn, "DER_MATRAZENMANN")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Schrein")
            .Set(x => x.kvps[3].defaultEn, "A seltsame Kreatur aus Haut, die über a Bettrahmen gespannt is. Der Zipfel is im Grunde gnumma nur a unsichtbarer schneller Zombie mit einem Schmerzauslöser und a flochn Texturbox, die daran angeschweißt is.\n\nHod si als sehr effektiv erwiesen, um Probanden zum Schrein und Davonalafn z'bringa.");
        plan.Edit(Mansionroomdefs.MansionDetails)
            .Set(x => x.kvps[0].defaultEn, "des groaße Haus")
            .Set(x => x.kvps[1].defaultEn, "A frisch hergricht’s Spukhaus, genau wia’s ganz am Anfang aa war!")
            .Set(x => x.kvps[2].defaultEn, "Baue-dein-eigenen Irrenhaus")
            .Set(x => x.kvps[3].defaultEn, "Kimmt a moi!")
            .Set(x => x.kvps[4].defaultEn, "Endlosmodus")
            .Set(x => x.kvps[5].defaultEn, "Karamari Krankenhaus")
            .Set(x => x.kvps[6].defaultEn, "Kimmt Boid!")
            .Set(x => x.kvps[7].defaultEn, "Entschliassl de Geheimnisse vo dera gspinstigen verlassenen Kranknhaus")
            .Set(x => x.kvps[8].defaultEn, "Verschmiz mit’m Ewigen!")
            .Set(x => x.kvps[9].defaultEn, "Spookys Katholische Familie")
            .Set(x => x.kvps[10].defaultEn, "Beend di Gschicht")
            .Set(x => x.kvps[11].defaultEn, "Es is no net vorbei");
        plan.Edit(Mansionroomdefs.Spec_10)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 10")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Parasitäre Infektionen")
            .Set(x => x.kvps[3].defaultEn, "A Wesn, des sei Form wandlt und umanhafft a Fremdling is, obwoa des ned offiziell bewiesn woa. Hod si ois extrem guad erwiesen geng de meistn Probanden, is aber zu schwierich zum eigschnian, so dass's gfoahlich is. Der Zipfel is aus sei Gfängnis ausbrochn, weil's oft Stromprobleme gab.\n");
        plan.Edit(Mansionroomdefs.RomanceNotes_2699867187143063811)
            .Set(x => x.kvps[0].defaultEn, "Zerscht sah da Ort niedlich aus,\r\naba i bin scho seid Tagen do …\r\nI fühl mi jetzt rechd ausgetrocknet, und\r\nI hob ständig des Gfühl, dass i vo\r\nwos beobocht wern.\r\n\r\nDes is überhaupt ned romantisch ...")
            .Set(x => x.kvps[1].defaultEn, "I woaß, dass mia wos verfoigt.\nOwa i hom’s Gfühl, dass i imma wieda duach\nde glechn Raam tanz.\nHoffentlich beweis’n de Notitzn, de i wia\nBrotkrum hinterließ, dass i Fortschritt mach\nund i iwgendwann a Ziel erreich.\n\nI hoff nur, dass ma ned de Tint\nausgeht. I hob a schrecklich’n Durst ...")
            .Set(x => x.kvps[2].defaultEn, "Tinte...\nStillt mein Duascht ned wirkli.\nDa Gschmack is ungeniaßboa, de Fleckn san schrecklich.\n\nI glaab ned, dass des a bsonders\nromantische Idee woa,\ndes zum trinken.")
            .Set(x => x.kvps[3].defaultEn, "I hob heid wos g’fundn,\n zum Stilla von meim unromantischen Durscht.\n I bin heid aufgwacht ausm kurzn Ohnmachtsschlof,\n und hob vor mir a Flaschl\n Rotbier g’fundn!\n\n I woaß ned genau, wos für a Marke oder Jahr,\n denn es gibt koan Aufkleber.\n Alles, wos i g’schnappt hob,\n is, dass’s a richtig\n metallischen G’schmack hot.")
            .Set(x => x.kvps[4].defaultEn, "I glaab ned, dass des Bier woa...")
            .Set(x => x.kvps[5].defaultEn, "I woaß ned, wie lang\ni no dorchhoitn ko…\n\nI hob koane vo mei frührn\nNotitzn gseng, des hoisst oiso\ndass i wos erreiche\noda des oa deepart sie mitnimmt.")
            .Set(x => x.kvps[6].defaultEn, "I denk dass des ma letzte Notiz is.\nI wird sterben ohne dos\ni ma Ausweg gefunden hob, aber \ndes stimmt ned. Dieser ort war wie ma\nAusweg. Ma Ausweg von all\nanderen quatsch. am ende is ma Tot scho\nromantisch.");
        plan.Edit(Mansionroomdefs.InGame_2874833270264989338).ForEach(x => x.kvps, el => el.Update(e => e.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(Mansionroomdefs.Lab_LocalizationPatch)
            .Set(x => x.kvps[0].defaultEn, "I glaab, Zipfel 5 is entkemma.\r\nDes Glos um sei Gfängnis is zbrocha,\r\nund i hör leise Klickgeräusch vo\r\nda Deck’ herunna. I woaß ned, wos\r\njetzt passiern wird. Wenn’s draußa\r\nis und lebt, dann is des woscheinlich\r\nmei letzta Bericht.\r\nDes Geklick wird jetzt lauter.\r\n\r\n      – Allgemeina Laborassistent")
            .Set(x => x.kvps[1].defaultEn, "Subjekt 5 wird imma unruhiger.\nI hob Spooky gsogt, dass ma\nmehra Gelt für Beruhigungsmittel\nbrauchan, owa sie hod nur glocht\nund is an d’Deck’ gfloga. Ohne\nmehra Drogen, um de Wesn ruhig\nz’hoita, bin i mir ned sicha,\nwie lang ma’s no sicha hier\nbehoiden kenna.\n\n          – Generischer Laborassistent");
        plan.Edit(Mansionroomdefs.WakeGelSpawn_NoteConfig).Set(x => x.text, "Spritz’n, Platschn, geleeartig.\n\nInnerein, Fress’n, Beschwören.\n\nNageln, Nie, hört’s Würgen ned aaf");
        plan.Edit(Mansionroomdefs.DS)
            .Set(x => x.kvps[0].defaultEn, "Das alte GL-Labs is irgendwie\r\nno schlechta wia’s neie.\r\nObwohl’s ausschaun tuat\r\nois hätt’s mit a großerer Buidget 'baut worn\r\nfunktionierts nimma ganz.\r\nI ko scho vasteihn\r\nwoswegen’s so schnei\r\n aufg’gebn worn is.\r\nI frag mi, ob’s do\r\n iwaubhaupt wos zom Rettn gibt.")
            .Set(x => x.kvps[1].defaultEn, "Dese Einrichtung is ziemli komisch.\r\nA Teil vo de Ausrüstung scheint\r\nned ganz richdig zo sein,\r\nois hätt’s fia Leid ohne Hände\r\nkonstruiert worn sei…\r\nI bin ma au ned sicha\r\nob's de geräte san die\r\nned genggan\r\nOwa de Stroom schwankt und es\r\n kimman komische G’räuschn\r\n aus de Lüftungsschächtn.")
            .Set(x => x.kvps[2].defaultEn, "Spooky hod grod g’sogt, dass do \r\n„Dinga“ gibt, de mia aus dem\r\noad rettn miassn.\r\nI fang a, mi sorgn zomoch’n\r\nob a  Zipflklatscher aa bei de\r\n„Dinga“ dabei is,\r\nde mia hoin missa.\r\nDer Stroom is wieda ausg’foin.\r\nIs ois do kaputt?")
            .Set(x => x.kvps[3].defaultEn, "I woaß ned, wos i toa soi.\nI ko ned gscheit denka\nmir is so komisch.\nI versteck mi vor dem Zipfel.\nMir is, als wia wanns ma wos\nauf da Haut wachst.\n\n\nI bring's ned schnei gnug oba,\nund i valier\na Haufn Bluad...")
            .Set(x => x.kvps[4].defaultEn, "Du musst den Zipfel nah bei dir hoitn.\nEs werd wos andas\nwenn's z'weit weg kimmt.\n\n\nEtwos, vor dem i ned davonrennan ko.");
        plan.Edit(Mansionroomdefs.Spec_3)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 3")
            .Set(x => x.kvps[1].defaultEn, "macht oan schmoan\nIn Entwicklung\r")
            .Set(x => x.kvps[2].defaultEn, "Dreckige Biss’n")
            .Set(x => x.kvps[3].defaultEn, "A Test-Zipfelklatscher, wos grad im GL-Labora zücht’n. Sollt scho nützlich sei, wenn ma’n amoi auslossn. De Versuach ham g’zeigt, dass a recht wirksam is – zumindst bei de durchschnittlich’n Leit.");
        plan.Edit(Mansionroomdefs.Spec_11)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 11")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Nur Gott weiß, mia aba ned")
            .Set(x => x.kvps[3].defaultEn, "A schwebende rote Gstalt, de unterm grodn, oamoligen Firmengebäude vo ana Restaurantkett gfundn wurn is, wo a geheimen Beziak hod. Der Zipfel is äußerst gewolttätig und schein, obwoi verschiedene Eindämmungsmaßnahmen, des Gebeid noch Belieng z’verlassen. Bei Kontakt mit dem Zipfel verschwinden de Opfer, owa mol wurn Tage spieter Nochste von de Opfer in da Testkamma gfundn.\n\nEs hod si ois unwiaksum erwisn, da dei de Seelen vo de Opfer nochm Kontakt net zruckbleim.");
        plan.Edit(Mansionroomdefs.RomanceNotes_4317078113098548725)
            .Set(x => x.kvps[0].defaultEn, "Zerscht sah da Ort niedlich aus,\r\naba i bin scho seid Tagen do …\r\nI fühl mi jetzt rechd ausgetrocknet, und\r\nI hob ständig des Gfühl, dass i vo\r\nwos beobocht wern.\r\n\r\nDes is überhaupt ned romantisch ...")
            .Set(x => x.kvps[1].defaultEn, "I woaß, dass mia wos verfoigt.\nOwa i hom’s Gfühl, dass i imma wieda duach\nde glechn Raam tanz.\nHoffentlich beweis’n de Notitzn, de i wia\nBrotkrum hinterließ, dass i Fortschritt mach\nund i iwgendwann a Ziel erreich.\n\nI hoff nur, dass ma ned de Tint\nausgeht. I hob a schrecklich’n Durst ...")
            .Set(x => x.kvps[2].defaultEn, "Tinte...\nStillt mein Duascht ned wirkli.\nDa Gschmack is ungeniaßboa, de Fleckn san schrecklich.\n\nI glaab ned, dass des a bsonders\nromantische Idee woa,\ndes zum trinken.")
            .Set(x => x.kvps[3].defaultEn, "I hob heid wos g’fundn,\n zum Stilla von meim unromantischen Durscht.\n I bin heid aufgwacht ausm kurzn Ohnmachtsschlof,\n und hob vor mir a Flaschl\n Rotbier g’fundn!\n\n I woaß ned genau, wos für a Marke oder Jahr,\n denn es gibt koan Aufkleber.\n Alles, wos i g’schnappt hob,\n is, dass’s a richtig\n metallischen G’schmack hot.")
            .Set(x => x.kvps[4].defaultEn, "I glaab ned, dass des Bier woa...")
            .Set(x => x.kvps[5].defaultEn, "I woaß ned, wie lang\ni no dorchhoitn ko…\n\nI hob koane vo mei frührn\nNotitzn gseng, des hoisst oiso\ndass i wos erreiche\noda des oa deepart sie mitnimmt.")
            .Set(x => x.kvps[6].defaultEn, "I denk dass des ma letzte Notiz is.\nI wird sterben ohne dos\ni ma Ausweg gefunden hob, aber \ndes stimmt ned. Dieser ort war wie ma\nAusweg. Ma Ausweg von all\nanderen quatsch. am ende is ma Tot scho\nromantisch.");
        plan.Edit(Mansionroomdefs.Secret_Spec_2)
            .Set(x => x.kvps[0].defaultEn, "DER_DELFIN")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Beißn")
            .Set(x => x.kvps[3].defaultEn, "A plastischer Chirurg, der no am Schwimmerlebnis mit Delfine fasziniert war. Der is dann auffa Idee kemma, si selber zu operiern, um mehra wia a Delfin auszsehn. Irgendwann is er dann in a übaflossne Höhle gfundn worn.\n\nDer is äußerst effektiv, wenn’s drum geht, Probanden komplett zu verwirrn und ihnen a Gänsehaut zu jagn.");
        plan.Edit(Mansionroomdefs.SurvivalistNotes)
            .Set(x => x.kvps[0].defaultEn, "DOG #2\r\n\r\nToilleten stinken wie sau.\r\nBier is fast nimma do.\r\nUnd ich muss dringend raus, \r\nI dua o boa Notizen hinterlassen damit i woaß wo i scho war.")
            .Set(x => x.kvps[1].defaultEn, "DOG #3\r\n\r\nI sah mal ein reh\r\noda wars doch wos andars? Der \r\nZipfel hat mich beinahe gegessn \r\nDoch i konnt ihn mit etwos schmackes vertreiben\r\nJo i bin der beste!")
            .Set(x => x.kvps[2].defaultEn, "DOG #4\r\n\r\nI hob vagessn wos fia deppat i bin\r\n warum bin i do?\r\n\r\nHier san eh nur hungrige Zipfel \r\ndie mi fressn woin \r\nlieber wärs mit aan Planierraupe alles zu vernichten.")
            .Set(x => x.kvps[3].defaultEn, "DOG #5\r\n\r\nI woaß nimma. \r\nWarum zum teifel bin i hier? \r\n\r\nGob es ann grund?\r\n\r\nI glaab der Vater im Himmel\r\nkimmt gleich zu mia. De\r\nhalluzinationen macha aua aua,\r\nI hob koa Bier nedda, \r\nI bin so weid von Minga \r\nI wui wieda do hi.")
            .Set(x => x.kvps[4].defaultEn, "DOG #7\r\n  \r\nLiaba Gott im himmel dua mia oan \r\ngfalln. Falls i jetztat sterben sollte \r\nmach mi bitte zu an Geist. I miass \r\nDen spieler angucka \r\nund mit iam gerne sprecha \r\ndann hob i gsellschofft.\r\n\r\nNun bleib i do und spui so kloane speilchen \r\nbevor i weida genga.I woaß dos i \r\nwahrscheinlich verfolgt werd. \r\n\r\nAber mia wurscht. \r\nDiese Wiecheier und dieser Ort, \r\nkenna mia am osch lecka \r\ni werd glaab i den Ausgang findn \r\nin diesa Irrenhaus.\r\n\r\nWerd erstmoi ausruha.\r\nUnd über di vielleicht gucka.");
        plan.Edit(Mansionroomdefs.Special_5062067516839061240).Set(x => x.kvps[2].defaultEn, "Język bawarski");
        plan.Edit(Mansionroomdefs.Spec_5)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 5")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "Nur Gott weiß, mia aba ned")
            .Set(x => x.kvps[3].defaultEn, "A Zipfel, den wo ma in da Kirchn vo am kloan Kaffl gfundn hod. De Leit san weg noch'm Kontakt mid dem Exemplar. Wia ma den Zipfel umbringt, woas ma no ned. Hod si ois extrem guad erwiesen geng Leit mid psychische Probleme oda an schwochn Willn.");
        plan.Edit(Mansionroomdefs.Spec_13)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 13")
            .Set(x => x.kvps[1].defaultEn, "Macht oan schmoan")
            .Set(x => x.kvps[2].defaultEn, "aadringa\r")
            .Set(x => x.kvps[3].defaultEn, "A uraltes Wassawesen, des ois verlorene Seele gilt, de währand da Sintflut auf tragische Weis gstorbn is. Hod si ois äußerst wiaksam erwisn gega Personen, di ned schwimma konntn oda auf an Köder vom Zipfel hereingfoin san.\r");
        plan.Edit(Mansionroomdefs.Spec_2)
            .Set(x => x.kvps[0].defaultEn, "Zipfelklatscher 2")
            .Set(x => x.kvps[1].defaultEn, "Macht oan Schmorrn")
            .Set(x => x.kvps[2].defaultEn, "Körper völlig zamreissn\r")
            .Set(x => x.kvps[3].defaultEn, "A g’mocht’s G’spenst, des größtenteils aus so halbfestem Zeig besteht und dauernd sei Zustand ändert. Hod si als recht wirkungsvoll gegenüber de schwächern oder langsamern Opfer rausgstellt.");
        plan.Edit(Mansionroomdefs.Secret_Spec_4)
            .Set(x => x.kvps[1].defaultEn, "in Entwicklung")
            .Set(x => x.kvps[2].defaultEn, "Nur Gott weiß, mia aba ned")
            .Set(x => x.kvps[3].defaultEn, "A kloanes mädl, vo dem ma glaabt, dass es irgendwia was mid da Gschicht vom 'Pied Piper' z'toa hod und si in vaschiedene grauslige Formen verwandlt,\n\ndamit da Bosskampf länga dauert. Is no in da Entwicklung, hot oba bei gwissn Mitaboata scho guat gwirkt.");
        plan.Edit(Mansionroomdefs.PrerollStuff).Set(x => x.kvps[0].defaultEn, "So lang wia ma si zurückerinnern kinnt, werdn Gschichten über de verfallene Villa ob’m Berg vazeihlt, de a Decke aus Dunkelheit über d’Stod legt. De Gschichtn vom Haus selber san praktisch unbekannt, und a de oidsten Leit im Dorf kennen si ned, woher de Villa eigentlich kimmt. Du, a richtiga G’schichtsfan, steigst drauf auf’n Berg, um’s Anwesen z’besuchn. In da Hoffnung, a weng Licht auf de Vorgschicht von dem zerfallenen Schloss vo da Dunkelheit zu werfn.\n\n");
        plan.Edit(Mansionroomdefs.Menus_6771480481796675210).ForEach(x => x.kvps, el => el.Update(e => e.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(Mansionroomdefs.Subtitles).ForEach(x => x.kvps, el => el.Update(e => e.defaultEn, BavarianTranslationsFromJSON.Translate));
        plan.Edit(Mansionroomdefs.Special_7471878311913830621).Set(x => x.kvps[2].defaultEn, "Ваварский язык");
        plan.Edit(Mansionroomdefs.BEN)
            .Set(x => x.kvps[0].defaultEn, "Eines Tages is a seltsamer Händla\r\nin d’Stadt kemma. Der hod\r\nhandgschaffene Puppn und\r\nSchmuckstucke verkauft\r\nund olle Kinda hom sei Lodn\r\nund seine Gschenke g’liebt.\r\nOwa d’Stadt hod sei Laden ned\r\nunterstützn kenna,\r\nweil de andan Geschäfte schlecht\r\ng’laafa hom.\r\n\r\nDe andan Ladenbesitza\r\nhom s’neidisch g’mocht.\r\nAlso hom a paar Dorfbewohner\r\noa nocht olle sei Puppn\r\ng’nomma und\r\nin den Fluss g’worfen.")
            .Set(x => x.kvps[1].defaultEn, "Doch kurz drauf is er\nweinend und kloagand zua\nFluss g’rannt, dass sei Kinder\nertrunken wern. Er is in den Fluss\ng’sprunga, um sei Eigentum z’rettn.\n\n\nDe Stadtbewohner, verbittat\nund immer no wütend,\nhom z’g’schaut, wia er\nverzweiflt um si g’schlogn und\nin den Fluss g’tauft is,\nbis er nie wieder obi kemma is.")
            .Set(x => x.kvps[2].defaultEn, "Obwoi’s ned des woarn is, wos se g’woit hom\n, hom de Ladenbesitza\n sie g’freut g’habt.")
            .Set(x => x.kvps[3].defaultEn, "Joare späda hom de Kinda\r\nda Stadt oifach z’verschwinden ofangt.\r\nUnd je mea\r\nKinder verschwunden san\r\n, desto mea Puppn hom\r\nde Leit’ im Woid und uman Fluss g’fundn.\r\n\r\nDe Puppn hom ma mol\r\nfast wia de vermissten\r\nKinda ausgschaugt.");
        plan.Edit(Mansionrooms.mini_room.ScreenTitle_TextMeshProUGUI).Set(x => x.m_text, "Neia Rekord!");
        plan.Edit(Mansionrooms.mini_room.IntroHeaderText_TextMeshProUGUI).Set(x => x.m_text, "Mia stella...\n     ...paar <color=#9EEBFF>Gspensta vor!</color>");
        plan.Edit(Mansionrooms.mini_room.BeginText_TextMeshProUGUI).Set(x => x.m_text, "Drück a Knopf");
        plan.Edit(Mansionrooms.mini_room.StageText_TextMeshProUGUI).Set(x => x.m_text, "Level 1");
        plan.Edit(Mansionrooms.mini_room.MsSpookGame)
            .Set(x => x.introGhosts[0].ghostIntroText, "Zerscht is <color=#65CAFF>Edgar</color>. er ist a bisal trostlos!")
            .Set(x => x.introGhosts[1].ghostIntroText, "Als nächsts ham ma, <color=#FF9A69>Mary</color> Is endlich aus irra Hülle kemma!")
            .Set(x => x.introGhosts[2].ghostIntroText, "Dritte is <color=#65FF65>Bram</color> und er is angheizt hier zu soa!")
            .Set(x => x.introGhosts[3].ghostIntroText, "Und endlich auf dea mia alle gwotet hom, es is <color=#B3EFF9>Spooky</color> selba!!!! !!!!!!!!!!!!");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_563).Set(x => x.m_text, "HÄUSL_GRUNDRISS_ÄNDA");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_567).Set(x => x.m_text, "EINNE");
        plan.Edit(Mansionrooms.CAT_room.ErrorText_TextMeshProUGUI).Set(x => x.m_text, "UNB'KONNTA FEHLA");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_570).Set(x => x.m_text, "ZURIACK");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_571).Set(x => x.m_text, "ZURIACK");
        plan.Edit(Mansionrooms.CAT_room.FatalitiesLabel_TextMeshProUGUI).Set(x => x.m_text, "Todesfälle: {0}");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_573).Set(x => x.m_text, "PROGRAM_BEENDEN");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_574).Set(x => x.m_text, "ZURIACK");
        plan.Edit(Mansionrooms.CAT_room.TextMeshPro_Text_TextMeshProUGUI_575).Set(x => x.m_text, "AUF_ZIPFEL_DATENBANK_ZUGREIFFA");
        plan.Edit(DollScenes.HuskKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "Scharlachrode, brennade Lecha wern auf d'Haut brennt\nund s'Fleisch hupft in a ganz fremde Form z'riack.\nZu wos Neim z'ammg'quetscht, de Husk nei g'staltet\nin a Haut, de de schreiande Lehre viel liaba aufnimmt.");
        plan.Edit(DollScenes.WoormyKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "Brät in Brät windet und bläht si.\nDie groben Gewürze drängen unaufhaltsam nach auße\ngega de Naturdarm, der se eng umschließt.\nEs zieht und spannt, bis de Elastizität da Haut\nletztendlich kläglich versagt.\nDurch die kleinen Risse brecha de weißen Brät-Flocken endlich hervor. \n\nDu bist endlich frei von diesem einengenden Hautschlauch.");
        plan.Edit(DollScenes.HookKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "A \"ned-bayrischs\" Kind is in a Gruam gschmissn worn.\nKoa Tradition hods jemals kennalerna derfa.\n\nGstraft homs es, ohne Gnad und ohne Zögern.\nAls wia wenns recht gwesn war, vom Herrgott sejba.\n\nGerecht war des ned, es war ehrenlos, ja daiflisch.\nIrgendwann werns alle versteng, in da ewign Verdammnis.");
        plan.Edit(DollScenes.ShockKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "BLITZE REISSN DA D’HAUT VOMS GSICHT\nDA DAMPFNE SAFT IN DA GLUAD VERRICHT’\nDE BOANA BRENNA, ES RÜTTELT DI GSCHEID\nVERLASS DEI HÜLLN, ES IS SOWEIT");
        plan.Edit(DollScenes.BurnKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "BIST NO GANZ SAUBER?!");
        plan.Edit(DollScenes.BurnKillScene.PlayerSpawn_BurnGameoverController).Set(x => x.afterText, "DE BRANDBLODERN KOCHEN UND WOCHSN GSCHEID\nBIS D' HAUT ZAFOID UND SE ZERREISST\nAUS DE KLOANAN LIACHA KRIECHAT DE GLUAT\nHINEIN IN DA WÄID AUS FLEISCH UND BLUT \n\nDU BIST DA WEG FIA D' HÖLLE WORN.");
        plan.Edit(DollScenes.BoomKillScene.KillText_TextMeshProUGUI).Set(x => x.m_text, "DEI GESTALT WIRD ZU VAPUIVATN ASCHN");
        plan.Edit(Specimen.LisaNotesLocalization)
            .Set(x => x.kvps[0].defaultEn, "Denkst du bist a gfeider\r\nfuchs ned?")
            .Set(x => x.kvps[1].defaultEn, "I beobacht di scho fia\nne lange Zeid.")
            .Set(x => x.kvps[2].defaultEn, "Fia wos blost 'n dei\nLuftballon überhaupt no auf?")
            .Set(x => x.kvps[3].defaultEn, "Dei Lebenssaft riacht so dick.\nI ko d'Adern saftln hian.")
            .Set(x => x.kvps[4].defaultEn, "Glaubst leicht, dei Trinität\nschützt di?")
            .Set(x => x.kvps[5].defaultEn, "Diese Texte zu lesen wird di\r\n  \r\nned helfa nur dea Himmel duads.");
        plan.Edit(DollScenes.DOLL_LAB.Description_TextMeshProUGUI).Set(x => x.m_text, "DOUG\n1964-1986\n\nGL LABS MITARBEITER");
        plan.Edit(DollScenes.DOLL_LAB.TextMeshPro_Text_TextMeshProUGUI_3388).Set(x => x.m_text, "Doug! Mia gratuliern da! \n\nGL Labs hod di ausgwählt,\ndassst di freiwillig fia an\nSpezialauftrag meldest! \n\nMia schicka di diaf\nunta d’Eadn, dassd as\nGebiet fia unsa neie\nAbteilung ausgrobst. \n\nPass dort untn auf vor \nGspensta und oide Skelettn. \n\nVui Glück!");
        plan.Edit(DollScenes.DOLL_LAB.In_Memory_Of_TextMeshProUGUI).Set(x => x.m_text, "In Erinnerung o");
        plan.Edit(DollScenes.DOLL_LAB.TextMeshPro_Text_TextMeshProUGUI_3393).Set(x => x.m_text, "SPUIN");
        plan.Edit(DollScenes.DOLL_LAB.RIP_TextMeshProUGUI).Set(x => x.m_text, "EWIGE");
        plan.Edit(DollScenes.DOLL_LAB.In_TextMeshProUGUI).Set(x => x.m_text, "");
        plan.Edit(DollScenes.DOLL_LAB.Peace_TextMeshProUGUI).Set(x => x.m_text, "RUHE");
        plan.Edit(DollScenes.DOLL_LAB.ErrorTitle_TextMeshProUGUI).Set(x => x.m_text, "FEHLER");
        plan.Edit(Mansionkillscreens.SpecEightKillscreen.HellText_TextMeshProUGUI).Set(x => x.m_text, "Dazu kimmt beim schlafa, des i gwoxn bin.\nEtwos regte si, Wurzln und Sehna.\nI ko Need fressn, oda aa vahunga.\nA gsicht des i am großen baam bwunda.\nEs sprach mi o, es fliastete sacha.\nEs wui mehr lem, des i wos fia ihn macha.");
        plan.Edit(DollScenes.DOLL_LAB.ErrorMessage_TextMeshProUGUI_3396).Set(x => x.m_text, "BEI WEITEREN VERSUCHEN\nWIRD DES SYSTEM HII GEHN!");
        plan.Edit(DollScenes.DOLL_LAB.KiragenControl).ForEach(x => x.specInfos, el => el.Update(e => e.description, BavarianTranslationsFromJSON.Translate));
        plan.Edit(DollScenes.DOLL_LAB.InfoBox_TextMeshProUGUI).Set(x => x.m_text, "STATUS: AM LEM\nTYP: NE SAU\nBESCH: WIA AN HIRSCH");
        plan.Edit(DollScenes.DOLL_LAB.WarningTitle_TextMeshProUGUI).Set(x => x.m_text, "OBACHT");
        plan.Edit(DollScenes.DOLL_LAB.TextMeshPro_Text_TextMeshProUGUI_3394).Set(x => x.m_text, "D'Seele is scho do, brings zriack zum höllenpforten quelln");
        plan.Edit(Mansionkillscreens.Credits.CentQuote_TextMeshProUGUI).Set(x => x.m_text, "A greassn dankschee o Sheena und Travis weil se ma Traum erfüllt ham! herzlichn dank an Kori the trash cat weil er is da beste Kopilot & viele grüße o Specimen 2 weil er imma do is.");
        plan.Edit(Mansionkillscreens.Credits.SoahQuote_TextMeshProUGUI).Set(x => x.m_text, "I mecht mi no besonders an Albino Moose Games bedankn da se ma d'Erlaubnis geba ham teil vo diesm Projekt zu sein. Insbesondere Sheena 'Mean Boss Lady' dass se mi leiden seng woite, und Travis 'Dungeon Mooster' Rupp-Greene fia d'rampen.");
        plan.Edit(Mansionkillscreens.Credits.NovaQuote_TextMeshProUGUI).Set(x => x.m_text, "A HERZLICHES DANKESCHÖN o sheena und Travis dass i mitmacha diafte mit eich an des spui. Des war schoo lang ma Traum seitdem i zum ersta moi an Kontroller in de Hand hatte, und des endlich verwirklichen zu lassen is fia mi wos besonders. Ihr seid de bestn.");
        plan.Edit(Mansionkillscreens.Credits.SheenaThanksText_TextMeshProUGUI).Set(x => x.m_text, "Mei bester Freund meines Lebens und Geschäftspartner Travis Rupp-Greene - Danke dass d' dei vertraun in mi steckst!\nPhil Fortunat - Danke dass d' bei ma Seitn stehst von dem gonza spuin kram, danke spezl.\nMa Muada - Danke dass D' um mi kümmerst und dass D' in meine \"albernen video spiele\" glaabst.\nA RIASIGN DANK an all meine narrischn Freunde die bei ma Seitn blieben und da waren fois i jemandn braachte.");
        plan.Edit(Mansionkillscreens.Credits.TravisThanksText_TextMeshProUGUI).Set(x => x.m_text, "Ma Spezl und Gschäftspartner Sheena dass d' mi glauben glassn hosd dass des Wahr werda ko, ma Eltern dass se ma d'richtigen weg zeign als a junger, und alle andere de in mi glaabtn und mi unterstüzt ham durch des ganze!");
        plan.Edit(Mansionkillscreens.Credits.SpookyCredit_TextMeshProUGUI).Set(x => x.m_text, "Imahuman");
        plan.Edit(Mansionkillscreens.Credits.SpookyAddlCredit_TextMeshProUGUI).Set(x => x.m_text, "Imahuman");
        plan.Edit(EmData.EM1NoteLoc)
            .Set(x => x.kvps[0].defaultEn, "Erkundn!\nWie schee des doch is! bin aus ma grab\nkemma und bin bereit weiter z'macha.\n\nD'Gedanke über meim Tod is scho\nromantisch gwesn aber i packs etzala\nund versuch so schnei wia es geht\nraus zu kemma.")
            .Set(x => x.kvps[1].defaultEn, "i fühl mi total munter und ois\nnacha ma erlebnis vom gestern.\nHunger und durst brach i ned\nois wos i denk is an romantische\nsacha, is wia droge woasst?")
            .Set(x => x.kvps[2].defaultEn, "Sogar aa de monstern und\nandere kreaturn woin mi ned\nattackieren. de wissn scho des\ni do bin aber so de oidn burschn\nwia frira sans ned.\n\nDefinitiv wega mei romantischn\netnschlossenheid!")
            .Set(x => x.kvps[3].defaultEn, "A komischer blauer geist kam heid\nzu mia und war stinkig und wirkte\naa unromantisch. Hod gsogt i dua\nmy job ned richtig und des i sacha\nmelden soll. i hob dann gsogt des\ni Koa Offizier hab und bin dann\nweggart ganga sie is ins bodn\nganga und jo des war des.")
            .Set(x => x.kvps[4].defaultEn, "I frog mi warum i Koa essn oder trinken\nbrauchad nach i glab zwei wochn scho.\nI docht des wäre weil d'biere und\nBrezn in d'luft mikroskopisch klein\nauftaucha.\n\nI woas etzala wos fia bescheiada \ng'dankn des war i bin natürlich\nunsterblich jo genau! do legst di\nnieda ned Leser?")
            .Set(x => x.kvps[5].defaultEn, "Hob wos überraschendes gesng.\n\nMei Hautfarbe hod is geändert.\n\nI glaab des is vielleicht normal weil\ni scho lang nimma in d'sonne war aber\nkam rüber wia a schock fia mi.\nAba mei romantischa partna is scho no\ndo und de interessiern si scoh fia\nmi egal ob i transparent oder a richtiger\nAlkoholiker bin.")
            .Set(x => x.kvps[6].defaultEn, "Da geist mädl is zriack kemma\nund sie schaut mi wütend o während\ni des schreib. Sie sagt nochmoi des\ni a job hier hob des i ned macha.\nI hob ihr gsogt egal welchan job\nsie denkt i hob des juckt mi ned.\nSie is etz furchtbar stinkig und\nsogt wenn i ned aufhöre nimmt sie\nmia des recht zu schrei____");
        plan.Edit(EmData.EM2NoteLoc)
            .Set(x => x.kvps[0].defaultEn, "Mami und Papi lieben mi\nsowas von gerne!\n\nSie ham ma gsogt se machan a\ntanz mit Dirndl und oim!")
            .Set(x => x.kvps[1].defaultEn, "Momment wo is Papi? Da hod ma do\ngsogt des ma a richtiges Volksfest\nmacha.")
            .Set(x => x.kvps[2].defaultEn, "Mami hod ma a korb voller Krapfen\ngegem fian Volksfest..\n\nSan schmackig.")
            .Set(x => x.kvps[3].defaultEn, "Wos ischn los? Warum hia i ge\nraische? kimmt Papi oda wos?\nSpuin ma fangen?")
            .Set(x => x.kvps[4].defaultEn, "ZEFIX! so a mist! bin runter\ngfoin und ma bein duad sau weh!")
            .Set(x => x.kvps[5].defaultEn, "I hob a Nickerchen gmochd.\nMa bein duad imma no weh.\nI glaab Paps kommt etz endlich..\n\n...DES IS NED PAPS!");
        plan.Edit(EmData.EM3NoteLoc)
            .Set(x => x.kvps[0].defaultEn, "Tag 1\nIch habe ein komisches Irrenhaus \nbetreten. Ich weiß nicht wie lange \nich hier sein werde aber ich hoffe \nnicht zu lange ich will lilli wieder\nsehen.")
            .Set(x => x.kvps[1].defaultEn, "Tag 2\nHeute hab ich was richtiges \ngrußeliges gesehen aber nicht so\nwie in The Outlast Trials.")
            .Set(x => x.kvps[2].defaultEn, "Tag 3\nAls Snake_Power_1234 habe ich fast\nkeine power mehr. ich habe nur ne\nGurke eingepackt mehr nicht\n\nIch hoffe dass mir die Brille\nessen anzeigt.")
            .Set(x => x.kvps[3].defaultEn, "Tag 4\nOk ich habe es satt hier!\nHeute hat mich ein grünes dingsbums\nattackiert und mir fast meinen coolen\nSigma rizz look versaut das geht\nzu weit!")
            .Set(x => x.kvps[4].defaultEn, "Tag 5\nIch wünschte ich könnte hier Lilli\nkontaktieren. so ein bisschen Live\ngehen und bullshit in Minecraft \nmachen.\n\nDass das nicht geht ist wild.")
            .Set(x => x.kvps[5].defaultEn, "Tag 6\nLilli falls du das lesen solltest\nIch komme definitiv zurück ich muss\nnur meine innere Schlange erwecken\nDENN ICH BIN Snake_Power_1234!!!\nund mit meiner Pose und meewing\nist alles möglich! OH YES.")
            .Set(x => x.kvps[6].defaultEn, "Tag 7\nAlso Heute hab ich richtig Rabatz\ngemacht und Wände zerstört. Da kam\nso ein geist Mädchen mit ihrem Dirndl\ndie war absolut nicht happy zu sehen\nwas ich getan habe. aber wenn juckts!\nich habe hier diesen Zettel für dich\ngelassen um dir zu sagen dass du nur\nmeine macht brauchst! denn mit mir\nist alles möglich!");
        plan.Edit(EmData.EM4NoteLoc)
            .Set(x => x.kvps[0].defaultEn, "Also, I schreib hier so Notizen.\nI glaab des is a guade idee. Fia\nBayern 1# Horror Film des Jahres\nbraucha neie orte fia guades video\nMaterial jedoch is hier grüner\nschleim der mi langsamer macht\ni glaab des is wurscht.")
            .Set(x => x.kvps[1].defaultEn, "Meine burschn! also ois geht guad\nvoran. i hob erst etz realisiert\ndes de Aufzüge nur runter gengan\nwer hod diese scheisse eigentlich\ngebaut?! Zefix, naja i ko\nwahrscheinlich mi oafoch rausgraba\nwenns sein muss.")
            .Set(x => x.kvps[2].defaultEn, "Wi nenn ma denn den horror film?\nVermutlich 5000 verschiedene Kartons\nversuchen a schreck einzujaga. aber\nmoi im ernst wer macht des? i bin\na ernster film dreher und i bekomm\ndes? ja mei.")
            .Set(x => x.kvps[3].defaultEn, "Guad guad guad…\nEssen und wasser is fast weg.\nWenigstens is da Ort hier Stabil\naber jo i woit nur paar Filme drehn\ndann vom acker macha. i muss so\nschnei wia es geht spada weg.")
            .Set(x => x.kvps[4].defaultEn, "Liebe Film crew, I hob a garten gfundn.\nhod ma zwar nix g'bracht aber hob a bissl\nMedal musik abgespielt. hob a coolen\nSichel gfunden glaab des is aa guad fia\nunser Horror Film Projekt fia Minga.\nAlso is stehl des ja Ned des wird nur\nausgelien fia unser projekt.")
            .Set(x => x.kvps[5].defaultEn, "Servus film crew, I wünschte i hätt\nno batterie um aufzunehmen aber egal.\nI hab ne geile japanische schule gfundn\nja und ich kann auch japanisch\nkonnichiwa. Do gibt's aa Fleish und a\nRestaurant und wos a imma \"gl labs\" is\ni woass ned ob i des Fleisch essn soll.")
            .Set(x => x.kvps[6].defaultEn, "Ok Crew, i bin hier fertig hob ma\nSichel um mich von die Haider zu\nverteidign wenigstens des denn i ko\nnimmer nach oben denn i bin scho\nziemlich weit runter.")
            .Set(x => x.kvps[7].defaultEn, "Ok Film crew, i denk i bin scho nah\nam a Ausgang. I denk i mach erstmoi a\npause hier in nem Herrenhaus. \nWenigstens besser als Altschauerberg.");

        // ---- other values ----
        plan.Edit(SharedAssets1.ScoreTitle_RectTransform).Set(x => x.sizeDelta.x, 200.0f);
        plan.Edit(DollScenes.DOLL_LAB.TextMeshPro_Text_RectTransform_3329).Set(x => x.sizeDelta.x, 500.0f);

        // ---- textures ----
        plan.ReplaceTexture(DollScenes.DOLL_Nightmare_SharedAssets.sd, "Textures/sd.png");
        plan.ReplaceTexture(SharedAssets1.spookylogo, "Textures/spookylogo__sharedassets1_58.png");
        plan.ReplaceTexture(Mansionkillscreens.Credits_SharedAssets.spookylogo, "Textures/spookylogo__sharedassets1_58.png");
        plan.ReplaceTexture(SharedAssets1.UISpritesheetHD, "Textures/UISpritesheetHD__sharedassets1_61.png");
        plan.ReplaceTexture(DollData.map3, "Textures/map3__doll_data_-7377147933388613871.png");
        plan.ReplaceTexture(DollData.map2, "Textures/map2__doll_data_2767156580898098491.png");
        plan.ReplaceTexture(DollData.map1, "Textures/map1__doll_data_6829643823182025284.png");
        plan.ReplaceTexture(DollScenes.HELL_SPEC11_SharedAssets.MB8_19_tex, "Textures/MB8_19_tex__doll_scenes_22.png");
        plan.ReplaceTexture(DollScenes.HELL_SPEC11_SharedAssets.MB8_18_tex, "Textures/MB8_18_tex__doll_scenes_34.png");
        plan.ReplaceTexture(DollScenes.HELL_SPEC11_SharedAssets.MB8_24_tex, "Textures/MB8_24_tex__doll_scenes_38.png");
        plan.ReplaceTexture(DollScenes.DOLL_LAB_SharedAssets.Spooky_Clothes_D, "Textures/Spooky_Clothes_D__doll_scenes_80.png");
        plan.ReplaceTexture(DollScenes.DOLL_LAB_SharedAssets.Spooky_Skin_D, "Textures/Spooky_Skin_D__doll_scenes_94.png");
        plan.ReplaceTexture(DollScenes.DOLL_1F_SharedAssets.NOTE2_spr, "Textures/NOTE2_spr__doll_scenes_62.png");
        plan.ReplaceTexture(EmData.EM_POS_04_Texture2D, "Textures/EM_POS_04__em_data_-8995535304360541640.png");
        plan.ReplaceTexture(EmData.EM_POS_09_Texture2D, "Textures/EM_POS_09__em_data_-6844272703609576926.png");
        plan.ReplaceTexture(EmData.EM_POS_05_Texture2D, "Textures/EM_POS_05__em_data_-3928463557712245678.png");
        plan.ReplaceTexture(EmData.EM_POS_11_Texture2D, "Textures/EM_POS_11__em_data_4551544373102716285.png");
        plan.ReplaceTexture(EmData.EM_POS_02_Texture2D, "Textures/EM_POS_02__em_data_5080823195972641693.png");
        plan.ReplaceTexture(EmData.EM_POS_10_Texture2D, "Textures/EM_POS_10__em_data_5483833596442969434.png");
        plan.ReplaceTexture(EmData.EM_POS_03_Texture2D, "Textures/EM_POS_03__em_data_5961730268307252226.png");
        plan.ReplaceTexture(EmScenes.UnknownSpec1FakeKillscreen_SharedAssets.menu4_tex_UI, "Textures/menu4_tex_UI__em_scenes_5.png");
        plan.ReplaceTexture(EmScenes.EndlessGenericGameover_SharedAssets.menu5_tex, "Textures/menu5_tex__em_scenes_7.png");
        plan.ReplaceTexture(KhData.SCARE_CAN, "Textures/SCARE_CAN__kh_data_-1783435112454933666.png");
        plan.ReplaceTexture(KhData.SCARE_CAN2, "Textures/SCARE_CAN2__kh_data_-1434070727773802169.png");
        plan.ReplaceTexture(KhScenes.HOS_Hall_01_SharedAssets.HOS_ex2, "Textures/HOS_ex2__kh_scenes_36.png");
        plan.ReplaceTexture(KhScenes.HOS_Hall_01_SharedAssets.HOS_ex8, "Textures/HOS_ex8__kh_scenes_47.png");
        plan.ReplaceTexture(KhScenes.HOS_Hall_01_SharedAssets.HOS_ex, "Textures/HOS_ex__kh_scenes_51.png");
        plan.ReplaceTexture(KhScenes.MonsterFourKillscreen_SharedAssets.ms21_01_relayout_UI, "Textures/ms21_01_relayout_UI__kh_scenes_2.png");
        plan.ReplaceTexture(KhScenes.HOS_Basement_SharedAssets.prop_14c_tex, "Textures/prop_14c_tex__kh_scenes_51.png");
        plan.ReplaceTexture(KhScenes.HOS_Basement_SharedAssets.hos_ex7_sprited, "Textures/hos_ex7_sprited__kh_scenes_58.png");
        plan.ReplaceTexture(KhScenes.HOS_Iso_SharedAssets.demon_spr, "Textures/demon_spr__kh_scenes_4.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.mini_day_spr, "Textures/mini_day_spr__kh_scenes_45.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.mini_bg_spr4, "Textures/mini_bg_spr4__kh_scenes_49.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.mini_over_spr, "Textures/mini_over_spr__kh_scenes_50.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.Ume_spr, "Textures/Ume_spr__kh_scenes_52.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.mini_name_spr, "Textures/mini_name_spr__kh_scenes_56.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.mini_school_spr_strip3, "Textures/mini_school_spr_strip3__kh_scenes_65.png");
        plan.ReplaceTexture(KhScenes.HOS_Lab_SharedAssets.npc_6_tex, "Textures/npc_6_tex__kh_scenes_73.png");
        plan.ReplaceTexture(KhScenes.HOS_Hall_02_SharedAssets.npc_3_tex, "Textures/npc_3_tex__kh_scenes_24.png");
        plan.ReplaceTexture(KhScenes.KH_Mid_Room_SharedAssets.Spooky_Clothes_D, "Textures/Spooky_Clothes_D__kh_scenes_15.png");
        plan.ReplaceTexture(KhScenes.KH_Mid_Room_SharedAssets.Spooky_Skin_D, "Textures/Spooky_Skin_D__kh_scenes_18.png");
        plan.ReplaceTexture(KhScenes.KH_Hall_06_SharedAssets.SCARE_CAN2, "Textures/SCARE_CAN2__kh_scenes_9.png");
        plan.ReplaceTexture(KhScenes.HOS_Bathroom_SharedAssets.prop_22b_tex, "Textures/prop_22b_tex__kh_scenes_18.png");
        plan.ReplaceTexture(KhScenes.HOS_Bathroom_SharedAssets.prop_24_tex, "Textures/prop_24_tex__kh_scenes_20.png");
        plan.ReplaceTexture(KhScenes.HOS_HUB_Lightmapped_SharedAssets.prop_17_tex, "Textures/prop_17_tex__kh_scenes_9.png");
        plan.ReplaceTexture(KhScenes.HOS_HUB_Lightmapped_SharedAssets.prop_2_tex, "Textures/prop_2_tex__kh_scenes_11.png");
        plan.ReplaceTexture(KhScenes.HOS_HUB_Lightmapped_SharedAssets.prop_5_tex, "Textures/prop_5_tex__kh_scenes_14.png");
        plan.ReplaceTexture(KhScenes.HOS_Office_Hall_SharedAssets.HOS_ex5, "Textures/HOS_ex5__kh_scenes_14.png");
        plan.ReplaceTexture(KhScenes.KHElevator_SharedAssets.BGN_08, "Textures/BGN_08__kh_scenes_20.png");
        plan.ReplaceTexture(KhScenes.KHElevator_SharedAssets.BGN_07, "Textures/BGN_07__kh_scenes_26.png");
        plan.ReplaceTexture(KhScenes.KHElevator_SharedAssets.Button_01, "Textures/Button_01__kh_scenes_35.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecEightKillscreen_SharedAssets.deer_effects_spr, "Textures/deer_effects_spr__mansionkillscreens_6.png");
        plan.ReplaceTexture(Mansionkillscreens.BadEnding_SharedAssets.END_03_resized, "Textures/END_03_resized__mansionkillscreens_14.png");
        plan.ReplaceTexture(Mansionkillscreens.BadEnding_SharedAssets.Spooky_Clothes_D, "Textures/Spooky_Clothes_D__mansionkillscreens_19.png");
        plan.ReplaceTexture(Mansionkillscreens.BadEnding_SharedAssets.Spooky_Skin_D, "Textures/Spooky_Skin_D__mansionkillscreens_23.png");
        plan.ReplaceTexture(Mansionkillscreens.GoodEnding_SharedAssets.END_05, "Textures/END_05__mansionkillscreens_32.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecTwelveKillscreen_SharedAssets.FACE_02_spr, "Textures/FACE_02_spr__mansionkillscreens_3.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecTwelveKillscreen_SharedAssets.FACE_02b_spr_tall, "Textures/FACE_02b_spr_tall__mansionkillscreens_5.png");
        plan.ReplaceTexture(Mansionkillscreens.NeutralEnding_SharedAssets.neutral_ending_bg, "Textures/neutral_ending_bg__mansionkillscreens_5.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.gameover_spr_03, "Textures/gameover_spr_03__mansionkillscreens_4.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.menu4_tex_UI, "Textures/menu4_tex_UI__mansionkillscreens_5.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.gameover_spr_01, "Textures/gameover_spr_01__mansionkillscreens_6.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.gameover_spr_04, "Textures/gameover_spr_04__mansionkillscreens_7.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.gameover_spr_02, "Textures/gameover_spr_02__mansionkillscreens_9.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.gameover_spr_06, "Textures/gameover_spr_06__mansionkillscreens_10.png");
        plan.ReplaceTexture(Mansionkillscreens.GenericGameover_SharedAssets.gameover_spr_05, "Textures/gameover_spr_05__mansionkillscreens_11.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecEightForestKillscreen_SharedAssets.deer_effects_1, "Textures/deer_effects_1__mansionkillscreens_15.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecThirteenKillscreen_SharedAssets.FACE_03b_spr_UI, "Textures/FACE_03b_spr_UI__mansionkillscreens_3.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecThirteenKillscreen_SharedAssets.FACE_03_spr_UI, "Textures/FACE_03_spr_UI__mansionkillscreens_5.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecNineKillscreen_SharedAssets.TAKE_tex, "Textures/TAKE_tex__mansionkillscreens_5.png");
        plan.ReplaceTexture(Mansionkillscreens.SpecNineAFKKillscreen_SharedAssets.catWinSheet, "Textures/catWinSheet__mansionkillscreens_6.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_05_spr, "Textures/POS_05_spr__mansionroomdefs_-8864225647225872552.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_01_spr, "Textures/POS_01_spr__mansionroomdefs_-8802408338300975882.png");
        plan.ReplaceTexture(Mansionroomdefs.catPicsSprited, "Textures/catPicsSprited__mansionroomdefs_-8405694072072103338.png");
        plan.ReplaceTexture(Mansionroomdefs.ART_05_Texture2D, "Textures/ART_05__mansionroomdefs_-7962048263277520671.png");
        plan.ReplaceTexture(Mansionroomdefs.SCARE_06, "Textures/SCARE_06__mansionroomdefs_-4630915722458198931.png");
        plan.ReplaceTexture(Mansionroomdefs.ART_01_Texture2D, "Textures/ART_01__mansionroomdefs_-4240779346071875943.png");
        plan.ReplaceTexture(Mansionroomdefs.ART_11_Texture2D, "Textures/ART_11__mansionroomdefs_-3302125697202251459.png");
        plan.ReplaceTexture(Mansionroomdefs.SCARE_05B, "Textures/SCARE_05B__mansionroomdefs_-69577357090007774.png");
        plan.ReplaceTexture(Mansionroomdefs.SCARE_05, "Textures/SCARE_05__mansionroomdefs_84503226330097867.png");
        plan.ReplaceTexture(Mansionroomdefs.ART_10_Texture2D, "Textures/ART_10__mansionroomdefs_154729152181979745.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_08_spr, "Textures/POS_08_spr__mansionroomdefs_282477557414169546.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_02_spr, "Textures/POS_02_spr__mansionroomdefs_495710974424110074.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_03_spr, "Textures/POS_03_spr__mansionroomdefs_1496302551968540777.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_07_spr, "Textures/POS_07_spr__mansionroomdefs_1506263196271703277.png");
        plan.ReplaceTexture(Mansionroomdefs.SCARE_09, "Textures/SCARE_09__mansionroomdefs_1597999187332437468.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_04_spr, "Textures/POS_04_spr__mansionroomdefs_1677478761891375653.png");
        plan.ReplaceTexture(Mansionroomdefs.POS_10_spr, "Textures/POS_10_spr__mansionroomdefs_3686383605593675971.png");
        plan.ReplaceTexture(Mansionroomdefs.SCARE_06B, "Textures/SCARE_06B__mansionroomdefs_5046849194092827900.png");
        plan.ReplaceTexture(Mansionroomdefs.SCARE_09B, "Textures/SCARE_09B__mansionroomdefs_8151009531055040716.png");
        plan.ReplaceTexture(Mansionroomdefs.ART_09_Texture2D, "Textures/ART_09__mansionroomdefs_8657119657950577801.png");
        plan.ReplaceTexture(Mansionroomdefs.ART_04_Texture2D, "Textures/ART_04__mansionroomdefs_8660908949506810593.png");
        plan.ReplaceTexture(Mansionrooms.School_SharedAssets.EX_02_spr, "Textures/EX_02_spr__mansionrooms_33.png");
        plan.ReplaceTexture(Mansionrooms.Elevator_01_SharedAssets.Button_01, "Textures/Button_01__mansionrooms_33.png");
        plan.ReplaceTexture(Mansionrooms.MAD_New_SharedAssets.mad_pc_spr_strip6, "Textures/mad_pc_spr_strip6__mansionrooms_35.png");
        plan.ReplaceTexture(Mansionrooms.MAD_New_SharedAssets.MB5_07_tex, "Textures/MB5_07_tex__mansionrooms_46.png");
        plan.ReplaceTexture(Mansionrooms.Woods_03_SharedAssets.deer_effects_1, "Textures/deer_effects_1__mansionrooms_33.png");
        plan.ReplaceTexture(Mansionrooms.Amn_NewHall_01_SharedAssets.MB10_15_tex, "Textures/MB10_15_tex__mansionrooms_6.png");
        plan.ReplaceTexture(Mansionrooms.Demo_End_Room_SharedAssets.map_front_spr, "Textures/map_front_spr__mansionrooms_14.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_SharedAssets.giftOpen, "Textures/giftOpen__mansionrooms_16.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_SharedAssets.Pass_01, "Textures/Pass_01__mansionrooms_18.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_SharedAssets.Spooky_Clothes_D, "Textures/Spooky_Clothes_D__mansionrooms_20.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_SharedAssets.Spooky_Skin_D, "Textures/Spooky_Skin_D__mansionrooms_23.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_SharedAssets.MID_01_tex, "Textures/MID_01_tex__mansionrooms_25.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.Sign_tex, "Textures/Sign_tex__mansionrooms_61.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.mallSprites, "Textures/mallSprites__mansionrooms_64.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.spookyKartSpooky, "Textures/spookyKartSpooky__mansionrooms_66.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.BS_02, "Textures/BS_02__mansionrooms_70.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.BS_03, "Textures/BS_03__mansionrooms_74.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.PROP_arcadeCabinet_mrsSpook_Em, "Textures/PROP_arcadeCabinet_mrsSpook_Em__mansionrooms_76.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.PROP_arcadeCabinet_spookyKart_Alb, "Textures/PROP_arcadeCabinet_spookyKart_Alb__mansionrooms_80.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.BS_04, "Textures/BS_04__mansionrooms_82.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.PROP_arcadeCabinet_mrsSpook_Alb, "Textures/PROP_arcadeCabinet_mrsSpook_Alb__mansionrooms_87.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.road_menu_tex, "Textures/road_menu_tex__mansionrooms_88.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.PROP_arcadeCabinet_MOTS_Em, "Textures/PROP_arcadeCabinet_MOTS_Em__mansionrooms_89.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.mallOfTheSpookMenu, "Textures/mallOfTheSpookMenu__mansionrooms_91.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.mallOfTheSpookGameOver, "Textures/mallOfTheSpookGameOver__mansionrooms_92.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.PROP_arcadeCabinet_MOTS_Alb, "Textures/PROP_arcadeCabinet_MOTS_Alb__mansionrooms_93.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.PROP_arcadeCabinet_spookyKart_Em, "Textures/PROP_arcadeCabinet_spookyKart_Em__mansionrooms_99.png");
        plan.ReplaceTexture(Mansionrooms.mini_room_SharedAssets.BS_01, "Textures/BS_01__mansionrooms_105.png");
        plan.ReplaceTexture(Mansionrooms.CAT_room_SharedAssets.DOS_spr, "Textures/DOS_spr__mansionrooms_10.png");
        plan.ReplaceTexture(Mansionrooms.BEN1_SharedAssets.MB4_16_spr, "Textures/MB4_16_spr__mansionrooms_34.png");
        plan.ReplaceTexture(Mansionrooms.End_04_SharedAssets.TAKE_10, "Textures/TAKE_10__mansionrooms_18.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_02_SharedAssets.Pass_02, "Textures/Pass_02__mansionrooms_9.png");
        plan.ReplaceTexture(Mansionrooms.End_03_SharedAssets.SKY_02, "Textures/SKY_02__mansionrooms_13.png");
        plan.ReplaceTexture(Mansionrooms.End_01_SharedAssets.DOOR_03, "Textures/DOOR_03__mansionrooms_5.png");
        plan.ReplaceTexture(Mansionrooms.Mid_Room_03_SharedAssets.Pass_03, "Textures/Pass_03__mansionrooms_3.png");
        plan.ReplaceTexture(Mansionrooms.Lab_SharedAssets.CARD_01, "Textures/CARD_01__mansionrooms_24.png");
        plan.ReplaceTexture(Mansionrooms.End_05_SharedAssets.TAKE_tex, "Textures/TAKE_tex__mansionrooms_38.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_19_tex, "Textures/MB8_19_tex__mansionrooms_47.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.Fun_rules, "Textures/Fun_rules__mansionrooms_51.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_22_tex, "Textures/MB8_22_tex__mansionrooms_53.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_08_tex, "Textures/MB8_08_tex__mansionrooms_61.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_17_tex, "Textures/MB8_17_tex__mansionrooms_68.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_18_tex, "Textures/MB8_18_tex__mansionrooms_73.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_24_tex, "Textures/MB8_24_tex__mansionrooms_77.png");
        plan.ReplaceTexture(Mansionrooms.Food_01_SharedAssets.MB8_25_tex, "Textures/MB8_25_tex__mansionrooms_79.png");
        plan.ReplaceTexture(Specimen.deer_effects_1, "Textures/deer_effects_1__specimen_-9026125749120366731.png");
        plan.ReplaceTexture(Specimen.hos_ex7_sprited, "Textures/hos_ex7_sprited__specimen_-5813685775444505577.png");
        plan.ReplaceTexture(DollScenes.DOLL_NW_SharedAssets.secret, "Textures/secret.png");
        plan.ReplaceTexture(DollScenes.WoormyKillScene_SharedAssets.WD_SPR7, "Textures/WD_SPR7.png");
        plan.ReplaceTexture(DollScenes.DOLL_Splode_SharedAssets.end2, "Textures/end2.png");
        plan.ReplaceTexture(DollScenes.DOLL_Splode_SharedAssets.end1, "Textures/end1.png");
        plan.ReplaceTexture(DollScenes.DollTestRemap_SharedAssets.dollAreaTitle, "Textures/dollAreaTitle.png");
        plan.ReplaceTexture(DollScenes.DOLL_LAB_SharedAssets.GEN_tex, "Textures/GEN_tex.png");
        plan.ReplaceTexture(DollScenes.DOLL_LAB_SharedAssets.posters, "Textures/posters.png");
        plan.ReplaceTexture(DollScenes.DollTestRemap_SharedAssets.FRAME_02, "Textures/FRAME_02.png");
        plan.ReplaceTexture(DollScenes.DollTestRemap_SharedAssets.FRAME_03, "Textures/FRAME_03.png");
        plan.ReplaceTexture(DollScenes.DOLL_LAB_SharedAssets.DAD, "Textures/DAD.png");

        // ---- audio ----
        plan.ReplaceAudio(DollScenes.DOLL_LAB_SharedAssets.PANIC, "Audio/panic.ogg");
        plan.ReplaceAudio(Mansionrooms.Manor_SharedAssets.Spooky_01, "Audio/Spooky_01.ogg");
        plan.ReplaceAudio(Mansionrooms.Mid_Room_SharedAssets.Spooky_02, "Audio/Spooky_02.ogg");
        plan.ReplaceAudio(Mansionrooms.Mid_Room_02_SharedAssets.Spooky_03, "Audio/Spooky_03.ogg");
        plan.ReplaceAudio(Mansionrooms.Mid_Room_03_SharedAssets.Spooky_04, "Audio/Spooky_04.ogg");
        plan.ReplaceAudio(Mansionrooms.End_03_SharedAssets.Spooky_05, "Audio/Spooky_05.ogg");
        plan.ReplaceAudio(Mansionkillscreens.BadEnding_SharedAssets.Spooky_06, "Audio/Spooky_06.ogg");
        plan.ReplaceAudio(Mansionkillscreens.GoodEnding_SharedAssets.Spooky_07, "Audio/Spooky_07.ogg");
        plan.ReplaceAudio(Mansionkillscreens.NeutralEnding_SharedAssets.ending_neutral, "Audio/ending_neutral.ogg");
        plan.ReplaceAudio(KhScenes.KH_Mid_Room_SharedAssets.kh_spooky_1, "Audio/kh_spooky_1.ogg");
        plan.ReplaceAudio(KhScenes.HOS_HUB_Lightmapped_SharedAssets.kh_spooky_2, "Audio/kh_spooky_2.ogg");
        plan.ReplaceAudio(KhScenes.KH_End_Room_SharedAssets.kh_spooky_3, "Audio/kh_spooky_3.ogg");
        plan.ReplaceAudio(Mansionrooms.MAD_New_SharedAssets.Cat_01, "Audio/Cat_01.ogg");
        plan.ReplaceAudio(Mansionrooms.MAD_New_SharedAssets.Cat_02, "Audio/Cat_02.ogg");
        plan.ReplaceAudio(Mansionrooms.MAD_New_SharedAssets.Cat_03, "Audio/Cat_03.ogg");
        plan.ReplaceAudio(Mansionrooms.MAD_New_SharedAssets.Cat_04, "Audio/Cat_04.ogg");
        plan.ReplaceAudio(Mansionrooms.MAD_New_SharedAssets.Cat_05, "Audio/Cat_05.ogg");
        plan.ReplaceAudio(Mansionrooms.MAD_New_SharedAssets.Cat_06, "Audio/Cat_06.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_01, "Audio/DB 1000min später.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_02, "Audio/DB 110min später.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_03, "Audio/DB 60min später.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_04, "Audio/DB baum.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_05, "Audio/DB dortmund ausfall.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_06, "Audio/DB reparatur.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_07, "Audio/DB schnee und eis.ogg");
        plan.ReplaceAudio(Mansionrooms.Rare_04_SharedAssets.Hello_08, "Audio/DB technische störung.ogg");
        plan.ReplaceAudio(Specimen.npc_music_11_snd, "Audio/Skrr Skrr Audi.ogg");
        plan.ReplaceAudio(Specimen.STAB_11_snd, "Audio/DL Prügel.ogg");
        plan.ReplaceAudio(Specimen.are_you_in_here_01, "Audio/DL asi.ogg");
        plan.ReplaceAudio(Specimen.come_out_come_out_01, "Audio/DL englisch.ogg");
        plan.ReplaceAudio(Specimen.i_m_so_lonely_01, "Audio/DL fresse.ogg");
        plan.ReplaceAudio(Specimen.i_can_smell_you_01, "Audio/DL konnichiwa.ogg");
        plan.ReplaceAudio(Specimen.i_hear_you_01, "Audio/DL schreit.ogg");
        plan.ReplaceAudio(Specimen.i_see_you_01, "Audio/DL Stark.ogg");
        plan.ReplaceAudio(Specimen.where_are_you_01, "Audio/DL traut euch.ogg");
        plan.ReplaceAudio(Specimen.you_ll_like_being_dead_i_promise_01, "Audio/DL you ahole.ogg");
        plan.ReplaceAudio(Specimen.you_re_wasting_both_our_time_01, "Audio/DL zittern.ogg");
        plan.ReplaceAudio(Specimen.npc_music_09_snd, "Audio/Burger Pommes.ogg");
        plan.ReplaceAudio(Specimen.BEN_05_fastStart_snd, "Audio/SM6 jodeln.ogg");
        plan.ReplaceAudio(Specimen.BEN_05_snd, "Audio/SM6 jodeln.ogg");
        plan.ReplaceAudio(Specimen.npc_music_07_snd, "Audio/Das Jägerlied.ogg");
        plan.ReplaceAudio(KhScenes.HOS_Lab_SharedAssets.mini_clock_snd, "Audio/SA_Salutschuss.ogg");
        plan.ReplaceAudio(KhScenes.HOS_Hall_02_SharedAssets.surgery_song, "Audio/TanteMarianne.ogg");
        plan.ReplaceAudio(Mansionrooms.mini_room_SharedAssets.theme, "Audio/nun massacre.ogg");
        plan.ReplaceAudio(DollScenes.DollTestRemap_SharedAssets.rip2, "Audio/rip2.ogg");
        plan.ReplaceAudio(DollScenes.DOLL_Splode_SharedAssets.Nolan_come_again, "Audio/BayernHymne.ogg");
        plan.ReplaceAudio(DollScenes.DOLL_1F_SharedAssets.new_spooky1, "Audio/Spooky_DH (1).ogg");
        plan.ReplaceAudio(DollScenes.DOLL_NW_SharedAssets.new_spooky2, "Audio/Spooky_DH (2).ogg");
        plan.ReplaceAudio(DollScenes.DOLL_LAB_SharedAssets.spooky_last1, "Audio/Spooky_DH (3).ogg");
        plan.ReplaceAudio(DollScenes.DOLL_LAB_SharedAssets.spooky_last2, "Audio/Spooky_DH (4).ogg");
        plan.ReplaceAudio(Specimen.DL_01_snd, "Audio/DL (1).ogg");
        plan.ReplaceAudio(Specimen.DL_02_snd, "Audio/DL (2).ogg");
        plan.ReplaceAudio(Specimen.DL_03_snd, "Audio/DL (3).ogg");
        plan.ReplaceAudio(Specimen.DL_04_snd, "Audio/DL (4).ogg");
        plan.ReplaceAudio(Specimen.ring_wake_snd, "Audio/ring_wake_snd.ogg");
        plan.ReplaceAudio(Specimen.ring_02_snd, "Audio/ring_02_snd.ogg");
        plan.ReplaceAudio(Specimen.ring_03_snd, "Audio/ring_03_snd.ogg");
        plan.ReplaceAudio(Specimen.fox_01, "Audio/fox_01.ogg");
        plan.ReplaceAudio(Specimen.fox_02, "Audio/fox_02.ogg");
        plan.ReplaceAudio(Specimen.fox_03, "Audio/fox_03.ogg");
        plan.ReplaceAudio(Specimen.fox_04, "Audio/fox_04.ogg");
        plan.AddAudio(KhScenes.HOS_Hall_02_SharedAssets.Container, "Audio/SoNeScheißeAua.ogg");
        plan.AddAudio(KhScenes.HOS_Bathroom_SharedAssets.Container, "Audio/EyLeuteHörtAuf.ogg");
        plan.AddTexture(KhScenes.HOS_Bathroom_SharedAssets.Container, "Textures/KenneIchNicht.png");
        plan.MakeSprite(KhScenes.HOS_Bathroom_SharedAssets.Container, "Textures/KenneIchNicht.png");

        return plan;
    }
}
