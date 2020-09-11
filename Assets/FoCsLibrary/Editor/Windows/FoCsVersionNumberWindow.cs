#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsVersionNumberWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using System.Linq;
using ForestOfChaos.Unity.Editor.UnitySettings;
using ForestOfChaos.Unity.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Windows {
    [FoCsWindow]
    public class FoCsVersionNumberWindow: FoCsWindow<FoCsVersionNumberWindow> {
        private const           string           TITLE   = "Version Number";
        private static readonly GUIContent       Heading = new GUIContent("Bundle Version");
        private static          SerializedObject SerializedObject;
        private                 string           versionNumber;

        private static SerializedProperty BundleVersion => SerializedObject.FindProperty("bundleVersion");

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + TITLE)]
        internal static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = TITLE;
        }

        private void OnEnable() {
            SerializedObject = new SerializedObject(UnitySettingsReader.ProjectSettings.Assets.First());
            versionNumber    = BundleVersion.stringValue;
        }

        protected override void OnGUI() {
            FoCsGUI.Layout.Label(Heading);

            using (Disposables.HorizontalScope()) {
                using (var cc = Disposables.ChangeCheck()) {
                    versionNumber = FoCsGUI.Layout.DelayedTextField(versionNumber);

                    if (cc.changed) {
                        BundleVersion.stringValue = versionNumber;
                        SerializedObject.ApplyModifiedProperties();
                    }
                }
            }
        }
    }
}