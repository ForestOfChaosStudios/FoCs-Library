using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.FoCsUI.Button;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Editor
{
	[CustomEditor(typeof(ButtonComponentBase), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEventBaseDrawer: FoCsEditor
	{
		public override void DrawGUI()
		{
			using(FoCsEditorDisposables.HorizontalScope())
			{
				if(GUILayout.Button("Add Object Name ID"))
				{
					var btn = (ButtonComponentBase)serializedObject.targetObject;
					if(!btn.ButtonGO.name.Contains("_btn"))
						btn.ButtonGO.name += "_btn";
					btn.TextGO.name = btn.ButtonGO.name.Replace("_btn", "") + "_text";
				}
				if(GUILayout.Button("Change Button Text to Button GO Name"))
				{
					var btn = (ButtonComponentBase)serializedObject.targetObject;
					btn.ButtonText = btn.ButtonGO.name.Replace("_btn", "");
				}
			}
		}
	}

	[CustomEditor(typeof(ButtonClickEvent_TMP), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEvent_TMPDrawer: ButtonClickEventBaseDrawer
	{ }

	[CustomEditor(typeof(ButtonClickEvent), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEventDrawer: ButtonClickEventBaseDrawer
	{ }
}