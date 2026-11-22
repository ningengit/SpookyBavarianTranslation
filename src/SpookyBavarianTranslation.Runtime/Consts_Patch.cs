//using HarmonyLib;
//using Rewired;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Reflection;
//using UnityEngine;

//namespace PlainAndEasyInjector.ModThingies
//{
//    [HarmonyPatch(typeof(Consts))]
//    public static class Consts_Unified_Patch
//    {
//        // Direct, high-performance reference to the private _name field inside ControllerElementIdentifier
//        private static readonly AccessTools.FieldRef<ControllerElementIdentifier, string> ControllerElementIdentifier_name =
//            AccessTools.FieldRefAccess<ControllerElementIdentifier, string>("_name");

//        private static readonly AccessTools.FieldRef<ControllerElementIdentifier, string> ControllerElementIdentifier_positiveName =
//    AccessTools.FieldRefAccess<ControllerElementIdentifier, string>("_positiveName");

//        private static readonly AccessTools.FieldRef<ControllerElementIdentifier, string> ControllerElementIdentifier_negativeName =
//AccessTools.FieldRefAccess<ControllerElementIdentifier, string>("_negativeName");

//        // Runs exactly ONCE when Harmony first prepares this patch file.
//        // Fully obfuscation-proof.
//        [HarmonyPrepare]
//        public static bool Prepare()
//        {
//            // ----------------------------------------------------
//            // 1. OBFUSCATION-PROOF KEYBOARD OVERRIDE
//            // ----------------------------------------------------
//            try
//            {
//                // Grab the un-obfuscated public field 'keyboardKeyNames'
//                var keyboardField = AccessTools.Field(typeof(Consts), "keyboardKeyNames");
//                if (keyboardField == null)
//                {
//                    return false;
//                }

//                var readOnlyCollection = keyboardField.GetValue(null) as ReadOnlyCollection<string>;
//                if (readOnlyCollection == null)
//                {
//                    return false;
//                }

//                // Standard .NET / Mono wraps its backing collection inside a private/protected field named "list" or "items"
//                FieldInfo ReadOnlyCollection_list =
//                    typeof(ReadOnlyCollection<string>).GetField("list", BindingFlags.NonPublic | BindingFlags.Instance) ??
//                    typeof(ReadOnlyCollection<string>).GetField("items", BindingFlags.NonPublic | BindingFlags.Instance);

//                if (ReadOnlyCollection_list == null)
//                {
//                    return false;
//                }

//                var internalList = ReadOnlyCollection_list.GetValue(readOnlyCollection) as IList<string>;
//                if (internalList == null)
//                {
//                    return false;
//                }

//                // Overwrite the memory array directly at its current pointer
//                for (int i = 0; i < internalList.Count; i++)
//                {
//                    if (string.IsNullOrEmpty(internalList[i])) continue;

//                    string translated = BavarianTranslationsFromJSON.Translate(internalList[i]);

//                    // FIX: Log the warning but CONTINUE the loop to process subsequent keys!
//                    if (translated == internalList[i])
//                    {
//                        Debug.LogWarning($"[SpookyBavaria] Couldn't translate keyboard key: {internalList[i]}");
//                        continue;
//                    }

//                    internalList[i] = translated;
//                }
//            }
//            catch (Exception ex)
//            {
//                UnityEngine.Debug.LogError($"[SpookyBavaria] Obfuscation-proof keyboard bypass failed: {ex}");
//            }

//            // ----------------------------------------------------
//            // 2. OBFUSCATION-PROOF MOUSE OVERRIDE
//            // ----------------------------------------------------
//            // Force evaluate properties immediately to mutate values inside active layout memory
//            ForceModifyMouseProperty("unityUnifiedMouseElementIdentifiers");
//            ForceModifyMouseProperty("rawInputUnifiedMouseElementIdentifiers");

//            return true;
//        }

//        // ==========================================
//        // MOUSE MODIFICATIONS (Runtime Fallback Hooks)
//        // ==========================================
//        [HarmonyPatch("unityUnifiedMouseElementIdentifiers", MethodType.Getter)]
//        [HarmonyPostfix]
//        public static void Postfix_UnityUnified(ref IList<ControllerElementIdentifier> __result)
//        {
//            ModifyNamesOfTheList(__result);
//        }

//        [HarmonyPatch("rawInputUnifiedMouseElementIdentifiers", MethodType.Getter)]
//        [HarmonyPostfix]
//        public static void Postfix_RawInput(ref IList<ControllerElementIdentifier> __result)
//        {
//            ModifyNamesOfTheList(__result);
//        }

//        private static void ForceModifyMouseProperty(string propertyName)
//        {
//            try
//            {
//                var property = AccessTools.Property(typeof(Consts), propertyName);
//                if (property == null)
//                {
//                    return;
//                }

//                var list = (IList<ControllerElementIdentifier>)property.GetValue(null);
//                ModifyNamesOfTheList(list);
//            }
//            catch (Exception ex)
//            {
//                UnityEngine.Debug.LogError($"[SpookyBavaria] Failed forcing mouse property load for {propertyName}: {ex}");
//            }
//        }

//        private static void ModifyNamesOfTheList(IList<ControllerElementIdentifier> list)
//        {
//            if (list == null) return;

//            //NAME
//            for (int i = 0; i < list.Count; i++)
//            {
//                ControllerElementIdentifier element = list[i];
//                if (element == null) continue;

//                if (string.IsNullOrEmpty(element.name)) continue;

//                string translated = BavarianTranslationsFromJSON.Translate(element.name);

//                // FIX: Use continue so a single missing mouse translation does not freeze the remaining list
//                if (translated == element.name)
//                {
//                    Debug.LogWarning("[SpookyBavaria] Couldn't translate mouse element: " + element.name);
//                    continue;
//                }

//                ControllerElementIdentifier_name(element) = translated;
//            }

//            //POSITIVE NAME
//            for (int i = 0; i < list.Count; i++)
//            {
//                ControllerElementIdentifier element = list[i];
//                if (element == null) continue;

//                if (string.IsNullOrEmpty(element.positiveName)) continue;

//                string translated = BavarianTranslationsFromJSON.Translate(element.positiveName);

//                // FIX: Use continue so a single missing mouse translation does not freeze the remaining list
//                if (translated == element.positiveName)
//                {
//                    Debug.LogWarning("[SpookyBavaria] Couldn't translate mouse element: " + element.positiveName);
//                    continue;
//                }

//                ControllerElementIdentifier_positiveName(element) = translated;
//            }

//            //NEGATIVE NAME
//            for (int i = 0; i < list.Count; i++)
//            {
//                ControllerElementIdentifier element = list[i];
//                if (element == null) continue;

//                if (string.IsNullOrEmpty(element.negativeName)) continue;

//                string translated = BavarianTranslationsFromJSON.Translate(element.negativeName);

//                // FIX: Use continue so a single missing mouse translation does not freeze the remaining list
//                if (translated == element.negativeName)
//                {
//                    Debug.LogWarning("[SpookyBavaria] Couldn't translate mouse element: " + element.negativeName);
//                    continue;
//                }

//                ControllerElementIdentifier_negativeName(element) = translated;
//            }
//        }
//    }
//}
