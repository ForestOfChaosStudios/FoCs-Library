using ForestOfChaosLib.AdvVar.Events;
using ForestOfChaosLib.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	[CustomEditor(typeof(AdvEvent))]
	public class AdvEventEditor: FoCsEditor<AdvEvent>
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			using(Disposables.DisabledScope(!Application.isPlaying))
			{
				var @event = FoCsGUI.AutoRect.Button("Trigger Event");
				if(@event.LeftClick)
					Target.Trigger();
			}
		}
	}
}