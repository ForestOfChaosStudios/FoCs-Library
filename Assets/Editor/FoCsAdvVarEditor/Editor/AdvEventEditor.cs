using ForestOfChaosAdvVar.Events;
using ForestOfChaosLibraryEditor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVarEditor
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
