using ForestOfChaosLib.Interfaces;
using ForestOfChaosLib.Components;
using UnityEngine.Events;

namespace ForestOfChaosLib.AdvVar.Events
{
	public class AdvEventListener: FoCsBehavior, IEventListening
	{
		public AdvEvent Event;
		public UnityEvent Response;

		public void OnEnable()
		{
			Event.RegisterListener(this);
		}

		public void OnDisable()
		{
			Event.UnregisterListener(this);
		}

		public void OnEventTriggered()
		{
			Response.Invoke();
		}
	}
}