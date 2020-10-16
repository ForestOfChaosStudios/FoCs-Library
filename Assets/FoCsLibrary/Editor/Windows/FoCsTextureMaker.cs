#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsTextureMaker.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using ForestOfChaos.Unity.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Windows {
    [FoCsWindow]
    public class FoCsTextureMaker: FoCsWindow<FoCsTextureMaker> {
        private const string TITLE = "Texture Maker";
        private       Color  color;

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + TITLE)]
        private static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = TITLE;
        }

        protected override void OnGUI() {
            color = EditorGUILayout.ColorField("Colour To Make Texture", color);

            if (FoCsGUI.Layout.Button("Create Texture")) {
                var tex = new Texture2D(2, 2);
                tex.SetPixels(new[] {color, color, color, color});
                tex.Apply();
                AssetDatabase.CreateAsset(tex, $"Assets/Solid_{ColorUtility.ToHtmlStringRGB(color)}.asset");
            }
        }
    }
}