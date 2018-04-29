using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.ScreenCap
{
	public class Timelapse
	{
		private TimelapseArgs Args;
		private static GameObject obj;
		private float WaitTime;
		private int Times;
		private DateTime Start;

		public DateTime TimeRemaining
		{
			get { return (Start.AddSeconds(WaitTime * (Times - 1)) - Start.TimeOfDay); }
		}

		public int ShootsTaken { get; private set; }

		public Timelapse(float waitTime, int times, ScreenShotArgs myArgs)
		{
			Start = DateTime.Now;
			Args = new TimelapseArgs(myArgs, Start);

			if(obj == null)
				obj = GameObject.Find("Timelapse_OBJ");
			if(obj == null)
				obj = new GameObject("Timelapse_OBJ");

			WaitTime = waitTime;
			Times = times;
			if(obj.GetComponent<FoCsBehavior>())
				obj.GetComponent<FoCsBehavior>().StartCoroutine(TakeImage());
			else
				obj.AddComponent<FoCsBehavior>().StartCoroutine(TakeImage());

		}

		public IEnumerator TakeImage()
		{
			while(true)
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