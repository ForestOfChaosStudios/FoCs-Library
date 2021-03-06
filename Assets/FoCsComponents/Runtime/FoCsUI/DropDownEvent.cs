#region � Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: DropDownEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaos.Unity.FoCsUI {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Dropdown Events")]
    [RequireComponent(typeof(Dropdown))]
    public class DropDownEvent: FoCsBehaviour {
        public Dropdown    _DropDown;
        public Action<int> onValueChanged;

        public int Value {
            get => _DropDown.value;
            set => _DropDown.value = value;
        }

        private void OnEnable() {
            if (_DropDown == null)
                _DropDown = GetComponent<Dropdown>();

            _DropDown.onValueChanged.AddListener(ValueChanged);
        }

        private void OnDisable() {
            _DropDown.onValueChanged.RemoveListener(ValueChanged);
        }

        private void ValueChanged(int value) {
            onValueChanged.Trigger(value);
        }
    }
}