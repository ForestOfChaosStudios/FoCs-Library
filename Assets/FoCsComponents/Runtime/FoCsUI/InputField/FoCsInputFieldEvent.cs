using ForestOfChaosLibrary.Attributes;
using UnityEngine;
using UInputField = UnityEngine.UI.InputField;

namespace ForestOfChaosLibrary.FoCsUI.InputField
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "InputField/InputField (Unity Text)")]
	public class FoCsInputFieldEvent: FoCsInputField
	{
		[NoFoldout] public UInputField InputField;

		public override string InputFieldText
		{
			get { return InputField.text; }
			set { InputField.text = value; }
		}

		public override GameObject InputFieldGO => InputField.gameObject;

		private void Reset()
		{
			InputField = GetComponent<UInputField>();
		}

		public void OnEnable()
		{
			if(InputField)
			{
				InputField.onValueChanged.AddListener(ValueChange);
				InputField.onValidateInput += ValidateInput;
				InputField.onEndEdit.AddListener(EndEdit);
			}
		}

		public void OnDisable()
		{
			if(InputField)
			{
				InputField.onValueChanged.RemoveListener(ValueChange);
				InputField.onValidateInput -= ValidateInput;
				InputField.onEndEdit.RemoveListener(EndEdit);
			}
		}
	}
}
