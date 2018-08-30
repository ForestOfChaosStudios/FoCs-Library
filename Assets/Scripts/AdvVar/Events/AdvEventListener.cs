using UnityEngine;
using UnityEngine.Events;

namespace ForestOfChaosLib.AdvVar.Events
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
