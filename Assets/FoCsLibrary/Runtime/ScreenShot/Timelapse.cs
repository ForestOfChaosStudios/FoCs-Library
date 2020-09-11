#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Timelapse.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLibrary.ScreenCap {
    public class Timelapse {
        private static   GameObject    obj;
        private static   FoCsBehaviour com;
        private readonly TimelapseArgs Args;
        private readonly Coroutine     Routine;
        private readonly DateTime      Start;
        private readonly float         WaitTime;
        public           bool          Capping = true;
        private          int           Times;

        public DateTime TimeRemaining => Start.AddSeconds(WaitTime * (Times - 1)) - Start.TimeOfDay;

        public int ShootsTaken { get; private set; }

        public Timelapse(float waitTime, int times, ScreenShotArgs myArgs) {
            Start = DateTime.Now;
            Args  = new TimelapseArgs(myArgs, Start);

            if (obj == null)
                obj = GameObject.Find("Timelapse_OBJ");

            if (obj == null)
                obj = new GameObject("Timelapse_OBJ");

            if (com == null)
                com = obj.GetComponent<FoCsBehaviour>();

            if (com == null)
                com = obj.AddComponent<FoCsBehaviour>();

            WaitTime = waitTime;
            Times    = times;
            Routine  = com.StartCoroutine(TakeImage());
        }

        public void Stop() {
            Capping = false;
            com.StopCoroutine(Routine);
        }

        public IEnumerator TakeImage() {
            while (Capping) {
                ScreenCap.TakeScreenShot(Args);
                ShootsTaken++;
                Args.LoopCount++;
                var waiter = new WaitForSeconds(WaitTime);

                yield return waiter;

                if (Times >= 1) {
                    if (Times == 1) {
                        yield return waiter;

                        ScreenCap.TakeScreenShot(Args);
                        Object.Destroy(obj);

                        yield break;
                    }

                    Times--;
                }
            }
        }
    }
}