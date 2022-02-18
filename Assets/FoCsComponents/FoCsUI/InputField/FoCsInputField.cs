#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsInputField.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
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
            OnValueChange?.Invoke(arg0);
        }

        protected void EndEdit(string arg0) {
            OnEndEdit?.Invoke(arg0);
        }

        protected void Submit(string arg0) {
            OnSubmit?.Invoke(arg0);
        }

        protected void Deselect(string arg0) {
            OnDeselect?.Invoke(arg0);
        }

        protected char ValidateInput(string text, int charIndex, char addedChar) {
            if (OnValidateInput != null)
                return OnValidateInput(text, charIndex, addedChar);

            return addedChar;
        }
    }
}