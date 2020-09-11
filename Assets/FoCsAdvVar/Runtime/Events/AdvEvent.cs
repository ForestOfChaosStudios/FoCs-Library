#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Events {
    [AdvFolderNameForestOfChaos]
    public class AdvEvent: ScriptableObject {
        private readonly List<AdvEventListener> listeners = new List<AdvEventListener>();

        public void Trigger() {
            for (var i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventTriggered();
        }

        public void RegisterListener(AdvEventListener listener) {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnRegisterListener(AdvEventListener listener) {
            listeners.Remove(listener);
        }
    }
}