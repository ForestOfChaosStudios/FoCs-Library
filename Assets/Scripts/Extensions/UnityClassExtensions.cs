using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class UnityClassExtensions
	{
		public static void SetParent(this GameObject gO, Transform parent)
		{
			gO.transform.SetParent(parent);
		}

		public static void SetParent(this GameObject gO, Component parent)
		{
			gO.transform.SetParent(parent.transform);
		}

		public static void SetParent(this GameObject gO, GameObject parent)
		{
			gO.transform.SetParent(parent.transform);
		}

		public static void SetParent(this Component mB, Transform parent)
		{
			mB.transform.SetParent(parent);
		}

		public static void SetParent(this Component mB, Component parent)
		{
			mB.transform.SetParent(parent.transform);
		}

		public static void SetParent(this Component mB, GameObject parent)
		{
			mB.transform.SetParent(parent.transform);
		}
	}
}
