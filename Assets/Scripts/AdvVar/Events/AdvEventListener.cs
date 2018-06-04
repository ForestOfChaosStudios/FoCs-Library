using UnityEngine.Events;

namespace ForestOfChaosLib.AdvVar.Events
{
	public class AdvEventListener: FoCsBehavior
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
