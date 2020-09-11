#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsInputFieldEventTmp.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


#if TMP
using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.InputField
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "InputField/InputField (TextMesh Pro)")]
	public class FoCsInputFieldEventTmp: FoCsInputField
	{
		public TMP_InputField InputField;
		public override string InputFieldText
		{
			get { return InputField.text; }
			set { InputField.text = value; }
		}
		public override GameObject InputFieldGO => InputField.gameObject;

		private void Reset()
		{
			InputField = GetComponentAdvanced<TMP_InputField>();
		}

		public void OnEnable()
		{
			if(InputField)
			{
				InputField.onValueChanged.AddListener(ValueChange);
				InputField.onSubmit.AddListener(Submit);
				InputField.onDeselect.AddListener(Deselect);
				InputField.onValidateInput += ValidateInput;
				InputField.onEndEdit.AddListener(EndEdit);
			}
		}

		public void OnDisable()
		{
			if(InputField)
			{
				InputField.onValueChanged.RemoveListener(ValueChange);
				InputField.onSubmit.RemoveListener(Submit);
				InputField.onDeselect.RemoveListener(Deselect);
				InputField.onValidateInput -= ValidateInput;
				InputField.onEndEdit.RemoveListener(EndEdit);
			}
		}
	}
}
#endif