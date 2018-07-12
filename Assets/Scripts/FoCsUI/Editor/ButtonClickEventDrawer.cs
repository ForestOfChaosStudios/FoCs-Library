using ForestOfChaosLib.Editor;
using ForestOfChaosLib.FoCsUI.Button;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Editor
{
	[CustomEditor(typeof(FoCsButton), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEventBaseDrawer: FoCsEditor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			using(Disposables.HorizontalScope())
			{
				if(GUILayout.Button("Add Object Name ID"))
				{
					var btn = (FoCsButton)serializedObject.targetObject;

					if(!btn.Button.name.Contains("_btn"))
						btn.Button.name += "_btn";

					btn.TextGO.name = btn.Button.name.Replace("_btn", "") + "_text";
				}

				if(GUILayout.Button("Change Button Text to Button GO Name"))
				{
					var btn = (FoCsButton)serializedObject.targetObject;
					btn.Text = btn.Button.name.Replace("_btn", "");
				}
			}
		}
	}

	[CustomEditor(typeof(FoCsButtonClickEvent), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEventDrawer: ButtonClickEventBaseDrawer { }
}