#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components.AdvVar
//       File: ToggleBoolReferenceToButtonEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaos;
using ForestOfChaos.Unity.FoCsUI.Button;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Toggle Bool Reference To Button")]
    public class ToggleBoolReferenceToButtonEvents: FoCsBehaviour {
        public BoolReference BoolReference;
        public FoCsButton    FoCsButton;

        private void OnEnable() {
            if (FoCsButton)
                FoCsButton.onMouseClick += OnMouseClick;
        }

        private void OnMouseClick() {
            if (BoolReference)
                BoolReference.Value = !BoolReference.Value;
        }

        private void OnDisable() {
            if (FoCsButton)
                FoCsButton.onMouseClick += OnMouseClick;
        }

        private void Reset() {
            FoCsButton = GetComponentInChildren<FoCsButton>();
        }
    }
}