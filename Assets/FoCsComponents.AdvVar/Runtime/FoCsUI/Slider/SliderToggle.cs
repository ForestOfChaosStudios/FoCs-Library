#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components.AdvVar
//       File: SliderToggle.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.Attributes;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ForestOfChaos.Unity.FoCsUI.Slider {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Slider/Toggle")]
    public class SliderToggle: FoCsSlider, IPointerClickHandler {
        public Action<bool> OnToggle;

        [SerializeField]
        [GetSetter("Toggled")]
        private bool toggled;

        public bool Toggled {
            get => toggled;
            set {
                toggled = value;
                Toggle(toggled);
            }
        }

        protected override void OnEnable() {
            base.OnEnable();
            slider.minValue = 0;
            slider.maxValue = 1;
        }

        public void OnPointerDown(PointerEventData eventData) {
            Toggle();
            Debug.Log(nameof(OnPointerDown));
        }

        private void Toggle() {
            toggled = !toggled;
            OnToggle.Trigger(toggled);
            slider.value = toggled? 1 : 0;
        }

        private void Toggle(bool val) {
            OnToggle.Trigger(val);
            slider.value = val? 1 : 0;
        }

        public void OnPointerClick(PointerEventData eventData) {
            Toggle();
        }
    }
}