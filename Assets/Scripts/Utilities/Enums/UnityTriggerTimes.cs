using System;

namespace ForestOfChaosLib.Utilities.Enums
{
	[Flags]
	public enum UnityTriggerTimes
	{
		Start    = 1 << 0,
		OnEnable = 1 << 1,
		Awake    = 1 << 2,
		None     = 1 << 3
	}
}
