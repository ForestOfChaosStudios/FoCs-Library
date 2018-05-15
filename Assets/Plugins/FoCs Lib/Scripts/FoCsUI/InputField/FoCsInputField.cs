using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.InputField
{
	public abstract class FoCsInputField: FoCsBehavior
	{
		public abstract string InputFieldText { get; set; }
		public abstract GameObject InputFieldGO { get; }

		public Action<string> OnValueChange;
		public Action<string> OnEndEdit;
		public Func<string, int, char, char> OnValidateInput;
		/// <summary>
		/// May not be called
		/// </summary>
		public Action<string> OnSubmit;
		/// <summary>
		/// May not be called
		/// </summary>
		public Action<string> OnDeselect;

		protected void ValueChange(string arg0)
		{
			OnValueChange.Trigger(arg0);
		}

		protected void EndEdit(string arg0)
		{
			OnEndEdit.Trigger(arg0);
		}

		protected void Submit(string arg0)
		{
			OnSubmit.Trigger(arg0);
		}

		protected void Deselect(string arg0)
		{
			OnDeselect.Trigger(arg0);
		}

		protected char ValidateInput(string text, int charIndex, char addedChar)
		{
			if(OnValidateInput != null)
				return OnValidateInput(text, charIndex, addedChar);
			return addedChar;
		}
	}
}