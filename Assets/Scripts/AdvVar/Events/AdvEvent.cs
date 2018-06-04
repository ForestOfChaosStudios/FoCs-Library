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

		public void RegisterListener(AdvEventListener listener)
		{
			if(!listeners.Contains(listener))
				listeners.Add(listener);
		}

		public void UnRegisterListener(AdvEventListener listener)
		{
			listeners.Remove(listener);
		}
	}
}
