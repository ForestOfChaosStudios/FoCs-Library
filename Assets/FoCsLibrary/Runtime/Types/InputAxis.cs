#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: InputAxis.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace ForestOfChaos.Unity.InputManager {
    [Serializable]
    public class InputAxis {
        /// <summary>
        ///     The Axis that the coder uses as Reference
        /// </summary>
        public string Axis;

        [SerializeField]
        private float deadZone;

        [SerializeField]
        public KeyPosition KeyPos = KeyPosition.Up;

        public bool OnlyButtonEvents;
        public bool UseSmoothInput = true;

        [FormerlySerializedAs("value")]
        [SerializeField]
        private float valueRaw;

        [SerializeField]
        private float valueSmooth;

        public bool ValueInverted;

        public float Value => ValueInverted? GetValueFloat(this) : -GetValueFloat(this);

        public float ValueRaw {
            get => ValueInverted? valueRaw : -valueRaw;
            set => valueRaw = ValueInverted? value : -value;
        }

        public float ValueSmooth {
            get => ValueInverted? valueSmooth : -valueSmooth;
            set => valueSmooth = ValueInverted? value : -value;
        }

        public float DeadZone {
            get => deadZone;
            set => deadZone = value;
        }

        public InputAxis(string axis) {
            Axis          = axis;
            ValueInverted = false;
        }

        public InputAxis(string axis, bool invert) {
            Axis          = axis;
            ValueInverted = invert;
        }

        public static implicit operator float(InputAxis fp) => GetValueFloat(fp);

        public static implicit operator string(InputAxis fp) => fp.Axis;

        public static implicit operator bool(InputAxis fp) => fp.ValueInverted;

        public static implicit operator InputAxis(string fp) => new InputAxis(fp);

        private static float GetValueFloat(InputAxis fp) => fp.UseSmoothInput? fp.ValueSmooth : fp.ValueRaw;

        public bool InputInDeadZone() => Math.Abs(Value) > DeadZone;

        public bool InputInDeadZone(float _deadZone) => Math.Abs(Value) > _deadZone;

        public void CallEvents() {
            CallEvents(this, deadZone);
        }

        public void CallEvents(float _deadZone) {
            CallEvents(this, _deadZone);
        }

        public void UpdateData() {
            valueRaw    = Input.GetAxisRaw(Axis);
            valueSmooth = Input.GetAxis(Axis);

            if (Input.GetButtonUp(Axis))
                KeyPos = KeyPosition.Up;
            else if (Input.GetButtonDown(Axis))
                KeyPos = KeyPosition.Down;
            else if (Input.GetButton(Axis))
                KeyPos = KeyPosition.Held;
        }

        public void UpdateDataAndCallEvents() {
            UpdateData();
            CallEvents(this, DeadZone);
        }

        public void UpdateDataAndCallEvents(float _deadZone) {
            UpdateData();
            CallEvents(this, _deadZone);
        }

        public static void CallEvents(InputAxis key) {
            CallEvents(key, key.DeadZone);
        }

        public void CallEventsCustomValue(float val) {
            var tempValRaw    = ValueRaw;
            var tempValSmooth = ValueSmooth;
            ValueRaw    = val;
            ValueSmooth = val;
            CallEvents(this, DeadZone);
            ValueRaw    = tempValRaw;
            ValueSmooth = tempValSmooth;
        }

        public void CallEventsCustomValue(float val, float _deadZone) {
            var tempValRaw    = ValueRaw;
            var tempValSmooth = ValueSmooth;
            ValueRaw    = val;
            ValueSmooth = val;
            CallEvents(this, _deadZone);
            ValueRaw    = tempValRaw;
            ValueSmooth = tempValSmooth;
        }

        public static void CallEvents(InputAxis key, float _deadZone) {
            if (key.OnlyButtonEvents) {
                switch (key.KeyPos) {
                    case KeyPosition.Up:
                        KeyUp(key, _deadZone);

                        return;
                    case KeyPosition.Down:
                        KeyDown(key, _deadZone);

                        return;
                    case KeyPosition.Held:
                        KeyHeld(key);

                        return;
                }

                return;
            }

            if (Input.GetButtonUp(key))
                KeyUp(key, _deadZone);
            else if (Input.GetButtonDown(key))
                KeyDown(key, _deadZone);
            else if (Math.Abs(key.Value) > _deadZone)
                KeyHeld(key);

            key.OnKeyNoDeadZone.Trigger(key.Value);

            if (key.InputInDeadZone())
                key.KeyPos = KeyPosition.None;
        }

        private static void KeyHeld(InputAxis key) {
            key.OnKey.Trigger(key.Value);
            key.OnKeyNoValue.Trigger();
        }

        private static void KeyDown(InputAxis key, float _deadZone) {
            key.OnKeyDown.Trigger();

            if (key.Value > _deadZone)
                key.OnKeyPositiveDown.Trigger();
            else if (key.Value < _deadZone)
                key.OnKeyNegativeDown.Trigger();
        }

        private static void KeyUp(InputAxis key, float _deadZone) {
            key.OnKeyUp.Trigger();

            if (key.Value > _deadZone)
                key.OnKeyPositiveUp.Trigger();
            else if (key.Value < _deadZone)
                key.OnKeyNegativeUp.Trigger();
        }


#region Actions
        public Action<float> OnKey;
        public Action        OnKeyDown;
        public Action        OnKeyNegativeDown;
        public Action        OnKeyNegativeUp;
        public Action<float> OnKeyNoDeadZone;
        public Action        OnKeyNoValue;
        public Action        OnKeyPositiveDown;
        public Action        OnKeyPositiveUp;
        public Action        OnKeyUp;
#endregion


    }

    public enum KeyPosition {
        Up,
        Down,
        Held,
        None
    }
}