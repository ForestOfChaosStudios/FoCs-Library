#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Events {
    [AdvFolderNameForestOfChaos]
    [CreateAssetMenu(fileName = "New " + nameof(AdvEvent), menuName = "ADV Variables/" + nameof(AdvEvent), order = 0)]
    public class AdvEvent: ScriptableObject {
        private readonly List<AdvEventListener> listeners = new List<AdvEventListener>();

        public void Trigger() {
            for (var i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventTriggered();
        }

        public void RegisterListener(AdvEventListener listener) {
            listeners.AddWithDuplicateCheck(listener);
        }

        public void UnRegisterListener(AdvEventListener listener) {
            listeners.Remove(listener);
        }
    }
}