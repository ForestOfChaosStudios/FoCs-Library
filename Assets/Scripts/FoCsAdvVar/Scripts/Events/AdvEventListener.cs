using ForestOfChaosLibrary;
using UnityEngine;
using UnityEngine.Events;

namespace ForestOfChaosAdvVar.Events
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Adv Event Listener")]
	public class AdvEventListener: FoCsBehaviour
	{
		public AdvEvent   Event;
		public UnityEvent Response;

		public void OnEnable()
		{
			Event.RegisterListener(this);
		}

		public void OnDisable()
		{
			Event.UnRegisterListener(this);
		}

		public void OnEventTriggered()
		{
			Response.Invoke();
		}
	}
}
