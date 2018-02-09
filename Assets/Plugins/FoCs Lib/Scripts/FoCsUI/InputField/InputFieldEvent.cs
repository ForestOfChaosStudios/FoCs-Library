using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Interfaces;
using UnityEngine;
using UInputField = UnityEngine.UI.InputField;

namespace ForestOfChaosLib.FoCsUI.InputField
{
	public class InputFieldEvent: InputFieldEventBase, IEventListening
	{
		[NoFoldout]
		public InputFieldData MyInputField;

		private void Reset()
		{
			MyInputField.InputField = GetComponentAdvanced<UInputField>();
		}

		public void OnEnable()
		{
			if(MyInputField.InputField)
			{
				MyInputField.InputField.onValueChanged.AddListener(ValueChange);
				MyInputField.InputField.onValidateInput += ValidateInput;
				MyInputField.InputField.onEndEdit.AddListener(EndEdit);
			}
		}

		public void OnDisable()
		{
			if(MyInputField.InputField)
			{
				MyInputField.InputField.onValueChanged.RemoveListener(ValueChange);
				MyInputField.InputField.onValidateInput -= ValidateInput;
				MyInputField.InputField.onEndEdit.RemoveListener(EndEdit);
			}
		}

		public override string InputFieldText
		{
			get { return MyInputField.InputField.text; }
			set { MyInputField.InputField.text = value; }
		}

		public override GameObject InputFieldGO
		{
			get { return MyInputField.InputField.gameObject; }
		}
	}
}