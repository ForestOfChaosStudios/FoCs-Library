using ForestOfChaosLib.Attributes;
using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.InputField
{
	public class InputFieldEvent_TMP: InputFieldEventBase
	{
		[NoFoldout]
		public InputFieldData_TMP MyInputField;

		private void Reset()
		{
			MyInputField.InputField = GetComponentAdvanced<TMP_InputField>();
		}

		public void OnEnable()
		{
			if(MyInputField.InputField)
			{
				MyInputField.InputField.onValueChanged.AddListener(ValueChange);
				MyInputField.InputField.onSubmit.AddListener(Submit);
				MyInputField.InputField.onDeselect.AddListener(Deselect);
				MyInputField.InputField.onValidateInput += ValidateInput;
				MyInputField.InputField.onEndEdit.AddListener(EndEdit);
			}
		}

		public void OnDisable()
		{
			if(MyInputField.InputField)
			{
				MyInputField.InputField.onValueChanged.RemoveListener(ValueChange);
				MyInputField.InputField.onSubmit.RemoveListener(Submit);
				MyInputField.InputField.onDeselect.RemoveListener(Deselect);
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