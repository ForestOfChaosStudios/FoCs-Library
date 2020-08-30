#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: FoCsToggleClickEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;
using UText = UnityEngine.UI.Text;
using UToggle = UnityEngine.UI.Toggle;

namespace ForestOfChaosLibrary.FoCsUI.Toggle {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Toggle/Events (Unity Text)")]
    public class FoCsToggleClickEvent: FoCsToggle {
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
            Toggle  = GetComponent<UToggle>();
            TextObj = GetComponentInChildren<UText>();
        }
    }
}