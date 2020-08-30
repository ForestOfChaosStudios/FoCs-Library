#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: FoCsImageEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.FoCsUI.Image {
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