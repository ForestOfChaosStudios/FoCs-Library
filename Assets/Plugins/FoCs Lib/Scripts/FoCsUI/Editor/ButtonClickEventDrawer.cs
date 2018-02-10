using ForestOfChaosLib.Editor;
using ForestOfChaosLib.FoCsUI.Button;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Editor
{
	[CustomEditor(typeof(ButtonClickEventBase), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEventBaseDrawer: FoCsEditor
	{
		public override void DrawGUI()
		{
			//Horizontal Scope
			////An Indented way of using Unitys Scopes
			using(new GUILayout.HorizontalScope())
			{
				if(GUILayout.Button("Add Object Name ID"))
				{
					var btn = (ButtonClickEventBase)serializedObject.targetObject;
					if(!btn.ButtonGO.name.Contains("_btn"))
						btn.ButtonGO.name += "_btn";
					btn.TextGO.name = btn.ButtonGO.name.Replace("_btn", "") + "_text";
				}
				if(GUILayout.Button("Change Button Text to Button GO Name"))
				{
					var btn = (ButtonClickEventBase)serializedObject.targetObject;
					btn.ButtonText = btn.ButtonGO.name.Replace("_btn", "");
				}
			}
		}
	}

	//#if TextMeshPro_DEFINE
	[CustomEditor(typeof(ButtonClickEvent_TMP), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEvent_TMPDrawer: ButtonClickEventBaseDrawer
	{ }

	//#endif
	[CustomEditor(typeof(ButtonClickEvent), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEventDrawer: ButtonClickEventBaseDrawer
	{ }
}