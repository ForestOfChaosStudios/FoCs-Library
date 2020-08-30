#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components.AdvVar
//       File: FoCsSlider.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;
using USlider = UnityEngine.UI.Slider;

namespace ForestOfChaosLibrary.FoCsUI.Slider {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Slider/Slider")]
    public class FoCsSlider: FoCsBehaviour {
        public Action<float>  OnValueChanged;
        public FloatReference ReferencedFloat;
        public USlider        slider;

        public float Value {
            get => slider.value;
            set => slider.value = value;
        }

        protected virtual void OnEnable() {
            if (slider == null)
                slider = GetComponent<USlider>();

            if (slider != null) {
                slider.onValueChanged.AddListener(ValueChanged);

                if (ReferencedFloat)
                    slider.value = ReferencedFloat.Value;
            }
        }

        protected virtual void OnDisable() {
            if (slider != null)
                slider.onValueChanged.RemoveListener(ValueChanged);
        }

        public void ValueChanged(float value) {
            OnValueChanged.Trigger(value);

            if (ReferencedFloat)
                ReferencedFloat.Value = value;
        }

        private void Reset() {
            slider = GetComponentInChildren<USlider>();
        }
    }
}