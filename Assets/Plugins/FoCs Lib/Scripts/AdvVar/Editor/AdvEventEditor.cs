using ForestOfChaosLib.AdvVar.Events;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	[CustomEditor(typeof(AdvEvent))]
	public class AdvEventEditor: FoCsEditor<AdvEvent>
	{
		public override void DrawGUI()
		{
			using(FoCsEditorDisposables.DisabledScope(!Application.isPlaying))
			{
				var @event = FoCsGUILayout.Button("Trigger Event");
				if(@event.AsButtonLeftClick)
					Target.Trigger();
			}
		}
	}
}