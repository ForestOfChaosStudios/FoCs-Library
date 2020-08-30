#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: FoCsButton.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaosLibrary.FoCsUI.Button {
    public abstract class FoCsButton: FoCsBehaviour {
        public UButton Button;
        public Action  onMouseClick;

        public abstract string Text { get; set; }

        public abstract GameObject TextGO { get; }

        public bool Interactable {
            get => Button.interactable;
            set => Button.interactable = value;
        }

        private void MouseClick() {
            onMouseClick.Trigger();
        }

        public void OnEnable() {
            if (Button)
                Button.onClick.AddListener(MouseClick);
        }

        public void OnDisable() {
            if (Button)
                Button.onClick.RemoveListener(MouseClick);
        }
    }
}