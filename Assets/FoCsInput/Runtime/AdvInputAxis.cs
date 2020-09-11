#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Input
//       File: AdvInputAxis.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.InputManager;
using ForestOfChaos.Unity.Utilities;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.InputSystem {
    [CreateAssetMenu(fileName = "Input Axis Variable", menuName = "ADV Variables/Input Axis", order = 2)]
    [Serializable]
    [AdvFolderName(AdvFolderNameAttribute.InternalNames.ForestOfChaos)]
    public class AdvInputAxis: AdvReference<InputAxis> {
        public bool OnlyButtonEvents {
            get => Value.OnlyButtonEvents;
            set => Value.OnlyButtonEvents = value;
        }

        public bool ValueInverted {
            get => Value.ValueInverted;
            set => Value.ValueInverted = value;
        }

        public KeyPosition KeyPos {
            get => Value.KeyPos;
            set => Value.KeyPos = value;
        }

        public Action OnKeyDown {
            get => Value.OnKeyDown;
            set => Value.OnKeyDown = value;
        }

        public Action OnKeyUp {
            get => Value.OnKeyUp;
            set => Value.OnKeyUp = value;
        }

        public Action OnKeyPositiveDown {
            get => Value.OnKeyPositiveDown;
            set => Value.OnKeyPositiveDown = value;
        }

        public Action OnKeyPositiveUp {
            get => Value.OnKeyPositiveUp;
            set => Value.OnKeyPositiveUp = value;
        }

        public Action OnKeyNegativeDown {
            get => Value.OnKeyNegativeDown;
            set => Value.OnKeyNegativeDown = value;
        }

        public Action OnKeyNegativeUp {
            get => Value.OnKeyNegativeUp;
            set => Value.OnKeyNegativeUp = value;
        }

        public Action OnKeyNoValue {
            get => Value.OnKeyNoValue;
            set => Value.OnKeyNoValue = value;
        }

        public Action<float> OnKey {
            get => Value.OnKey;
            set => Value.OnKey = value;
        }

        public Action<float> OnKeyNoDeadZone {
            get => Value.OnKeyNoDeadZone;
            set => Value.OnKeyNoDeadZone = value;
        }

        public static implicit operator float(AdvInputAxis input) => input.Value;

        public static implicit operator AdvInputAxis(string input) {
#if UNITY_EDITOR
            foreach (var axis in FoCsAssetFinder.FindAssetsByType<AdvInputAxis>()) {
                if (axis.Value.Axis == input)
                    return axis;
            }
#endif
            return null;
        }

        public bool InputInDeadZone() => Value.InputInDeadZone();

        public bool InputInDeadZone(float deadZone) => Value.InputInDeadZone(deadZone);

        public void CallEvents() {
            Value.CallEvents();
        }

        public void CallEvents(float deadZone) {
            Value.CallEvents(deadZone);
        }

        public void UpdateData() {
            Value.UpdateData();
        }

        public void UpdateDataAndCallEvents() {
            Value.UpdateDataAndCallEvents();
        }

        public void UpdateDataAndCallEvents(float deadZone) {
            Value.UpdateDataAndCallEvents(deadZone);
        }

        public void CallEventsCustomValue(float key) {
            Value.CallEventsCustomValue(key);
        }

        public void CallEventsCustomValue(float key, float deadZone) {
            Value.CallEventsCustomValue(key, deadZone);
        }
    }
}