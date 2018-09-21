using ForestOfChaosAdvVar.Events;
using ForestOfChaosLibrary.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVar.Editor
{
	[CustomEditor(typeof(AdvEvent))]
	public class AdvEventEditor: FoCsEditor<AdvEvent>
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			using(Disposables.DisabledScope(!Application.isPlaying))
			{
				var @event = FoCsGUI.Layout.Button("Trigger Event");

				if(@event)
					Target.Trigger();
			}
		}
	}
}
