#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsImageEvent.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.FoCsUI.Image {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Image/Image (Unity Text)")]
    public class FoCsImageEvent: FoCsImage {
        public UnityEngine.UI.Text TextObj;

        public override string Text {
            get => TextObj == null? "" : TextObj.text;
            set {
                if (TextObj != null)
                    TextObj.text = value;
            }
        }

        public override GameObject TextGO => TextObj.gameObject;

        private void Reset() {
            Image   = GetComponent<UnityEngine.UI.Image>();
            TextObj = GetComponentInChildren<UnityEngine.UI.Text>();
        }
    }
}