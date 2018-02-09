using System;
using System.Collections;
using ForestOfChaosLib.GamePhysics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.Screenshot
{
	public class Timelapse
	{
		private TimelapseArgs Args;
		private GameObject obj;
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
			obj = GameObject.Find("Timelapse_OBJ");
			if(obj == null)
				obj = new GameObject("Timelapse_OBJ");
			WaitTime = waitTime;
			Times = times;
			obj.AddComponent<FoCsBehavior>().StartCoroutine(TakeImage());
		}

		public IEnumerator TakeImage()
		{
			bool loop = true;

			while(loop)
			{
				Screenshot.TakeScreenShot(Args);
				ShootsTaken++;
				Args.LoopCount++;
				var waiter = new WaitForSeconds(WaitTime);
				yield return waiter;
				if(Times != 0)
				{
					if(Times == 1)
					{
						yield return waiter;
						Screenshot.TakeScreenShot(Args);
						loop = false;
						Object.Destroy(obj);
						yield break;
					}
					Times--;
				}
			}
		}

		public class TimelapseArgs: ScreenShotArgs
		{
			private DateTime Start;
			public int LoopCount = 0;

			public TimelapseArgs(ScreenShotArgs args, DateTime start): base(args)
			{
				Start = start;
			}

			public override string GetFullFileName()
			{
				if(string.IsNullOrEmpty(fileName))
				{
					var strPath = "";

					strPath = string.Format("{0}/Timelapse[{3:yyyy-MM-dd(hh-mm-ss)}][{1}x{2}]px_Frame_{4}.png", Path, FrameWidth, FrameHeight, Start, LoopCount);

					return strPath;
				}
				return string.Format(fileName, LoopCount);
			}
		}
	}
}