#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsButtonClickEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;
using UText = UnityEngine.UI.Text;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaos.Unity.FoCsUI.Button {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Button/Button (Unity Text)")]
    public class FoCsButtonClickEvent: FoCsButton {
        public UText TextObj;

        public override string Text {
            get => TextObj == null? "" : TextObj.text;
            set {
                if (TextObj != null)
                    TextObj.text = value;
            }
        }

        public override GameObject TextGO => TextObj.gameObject;

        private void Reset() {
            Button  = GetComponent<UButton>();
            TextObj = GetComponentInChildren<UText>();
        }
    }
}