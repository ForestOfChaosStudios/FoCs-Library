using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.ScreenCap
{
	public class Timelapse
	{
		private        TimelapseArgs Args;
		private static GameObject    obj;
		private static FoCsBehavior  com;
		private        float         WaitTime;
		private        int           Times;
		private        DateTime      Start;
		public         DateTime      TimeRemaining => (Start.AddSeconds(WaitTime * (Times - 1)) - Start.TimeOfDay);
		public         int           ShootsTaken   { get; private set; }
		private        Coroutine     Routine;
		public         bool          Capping = true;

		public Timelapse(float waitTime, int times, ScreenShotArgs myArgs)
		{
			Start = DateTime.Now;
			Args  = new TimelapseArgs(myArgs, Start);

			if(obj == null)
				obj = GameObject.Find("Timelapse_OBJ");

			if(obj == null)
				obj = new GameObject("Timelapse_OBJ");

			if(com == null)
				com = obj.GetComponent<FoCsBehavior>();

			if(com == null)
				com = obj.AddComponent<FoCsBehavior>();

			WaitTime = waitTime;
			Times    = times;
			Routine  = com.StartCoroutine(TakeImage());
		}

		public void Stop()
		{
			Capping = false;
			com.StopCoroutine(Routine);
		}

		public IEnumerator TakeImage()
		{
			while(Capping)
			{
				ScreenCap.TakeScreenShot(Args);
				ShootsTaken++;
				Args.LoopCount++;
				var waiter = new WaitForSeconds(WaitTime);

				yield return waiter;

				if(Times >= 1)
				{
					if(Times == 1)
					{
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