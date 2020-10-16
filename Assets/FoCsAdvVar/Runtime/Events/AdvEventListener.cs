#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvEventListener.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;
using UnityEngine.Events;

namespace ForestOfChaos.Unity.AdvVar.Events {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + nameof(AdvEventListener))]
    public class AdvEventListener: FoCsBehaviour {
        public AdvEvent   Event;
        public UnityEvent Response;

        public void OnEnable() {
            Event.RegisterListener(this);
        }

        public void OnDisable() {
            Event.UnRegisterListener(this);
        }

        public void OnEventTriggered() {
            Response.Invoke();
        }
    }
}