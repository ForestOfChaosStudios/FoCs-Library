using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Events
{
	[AdvFolderNameForestOfChaos]
	public class AdvEvent: ScriptableObject
	{
		private readonly List<AdvEventListener> listeners = new List<AdvEventListener>();

		public void Trigger()
		{
			for(var i = listeners.Count - 1; i >= 0; i--)
				listeners[i].OnEventTriggered();
		}

		public void RegisterListener(AdvEventListener listner)
		{
			if(!listeners.Contains(listner))
				listeners.Add(listner);
		}

		public void UnregisterListener(AdvEventListener listner)
		{
			listeners.Remove(listner);
		}
	}
}