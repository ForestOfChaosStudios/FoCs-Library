#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvEventListener.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaosLibrary;
using UnityEngine;
using UnityEngine.Events;

namespace ForestOfChaos.Unity.AdvVar.Events {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Adv Event Listener")]
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