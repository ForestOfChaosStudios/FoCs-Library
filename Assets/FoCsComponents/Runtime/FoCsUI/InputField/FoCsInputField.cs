#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsInputField.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.FoCsUI.InputField {
    public abstract class FoCsInputField: FoCsBehaviour {
        /// <summary>
        ///     May not be called
        /// </summary>
        public Action<string> OnDeselect;

        public Action<string> OnEndEdit;

        /// <summary>
        ///     May not be called
        /// </summary>
        public Action<string> OnSubmit;

        public Func<string, int, char, char> OnValidateInput;
        public Action<string>                OnValueChange;

        public abstract string InputFieldText { get; set; }

        public abstract GameObject InputFieldGO { get; }

        protected void ValueChange(string arg0) {
            OnValueChange.Trigger(arg0);
        }

        protected void EndEdit(string arg0) {
            OnEndEdit.Trigger(arg0);
        }

        protected void Submit(string arg0) {
            OnSubmit.Trigger(arg0);
        }

        protected void Deselect(string arg0) {
            OnDeselect.Trigger(arg0);
        }

        protected char ValidateInput(string text, int charIndex, char addedChar) {
            if (OnValidateInput != null)
                return OnValidateInput(text, charIndex, addedChar);

            return addedChar;
        }
    }
}