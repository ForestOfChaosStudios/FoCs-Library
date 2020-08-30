#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: FoCsInputFieldEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using ForestOfChaosLibrary.Attributes;
using UnityEngine;
using UInputField = UnityEngine.UI.InputField;

namespace ForestOfChaosLibrary.FoCsUI.InputField {
    [AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "InputField/InputField (Unity Text)")]
    public class FoCsInputFieldEvent: FoCsInputField {
        [NoFoldout]
        public UInputField InputField;

        public override string InputFieldText {
            get => InputField.text;
            set => InputField.text = value;
        }

        public override GameObject InputFieldGO => InputField.gameObject;

        private void Reset() {
            InputField = GetComponent<UInputField>();
        }

        public void OnEnable() {
            if (InputField) {
                InputField.onValueChanged.AddListener(ValueChange);
                InputField.onValidateInput += ValidateInput;
                InputField.onEndEdit.AddListener(EndEdit);
            }
        }

        public void OnDisable() {
            if (InputField) {
                InputField.onValueChanged.RemoveListener(ValueChange);
                InputField.onValidateInput -= ValidateInput;
                InputField.onEndEdit.RemoveListener(EndEdit);
            }
        }
    }
}