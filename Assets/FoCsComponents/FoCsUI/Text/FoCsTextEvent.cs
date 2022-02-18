#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsTextEvent.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.FoCsUI.Text {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Toggle/Events (Unity Text)")]
    public class FoCsTextEvent: FoCsText {
        public UnityEngine.UI.Text TextObj;

        public override string Text {
            get => TextObj.text;
            set => TextObj.text = value;
        }

        public override GameObject TextGO => TextObj.gameObject;

        private void Reset() {
            TextObj = GetComponentInChildren<UnityEngine.UI.Text>();
        }
    }
}