#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsButton.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaos.Unity.FoCsUI.Button {
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
            onMouseClick?.Invoke();
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