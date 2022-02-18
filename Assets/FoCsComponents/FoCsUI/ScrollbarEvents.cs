#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: ScrollbarEvents.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaos.Unity.FoCsUI {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Scrollbar Events")]
    [RequireComponent(typeof(Scrollbar))]
    public class ScrollbarEvents: FoCsBehaviour {
        public Scrollbar     _Scrollbar;
        public Action<float> onValueChanged;

        public float Value {
            get => _Scrollbar.value;
            set => _Scrollbar.value = value;
        }

        private void OnEnable() {
            if (_Scrollbar == null)
                _Scrollbar = GetComponent<Scrollbar>();

            _Scrollbar.onValueChanged.AddListener(ValueChanged);
        }

        private void OnDisable() {
            _Scrollbar.onValueChanged.RemoveListener(ValueChanged);
        }

        private void ValueChanged(float value) {
            onValueChanged?.Invoke(value);
        }
    }
}