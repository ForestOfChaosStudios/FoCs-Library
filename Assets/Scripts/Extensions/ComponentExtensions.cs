using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class ComponentExtensions
	{
		public static Vector3 GetPosition(this         Component mB) => mB.transform.position;
		public static Vector3 GetLocalPosition(this    Component mB) => mB.transform.localPosition;
		public static Vector3 GetEulerAngles(this      Component mB) => mB.transform.eulerAngles;
		public static Vector3 GetLocalEulerAngles(this Component mB) => mB.transform.localEulerAngles;

		public static void SetPosition(this Component mB, Vector3 pos)
		{
			mB.transform.position = pos;
		}

		public static void SetLocalPosition(this Component mB, Vector3 pos)
		{
			mB.transform.localPosition = pos;
		}

		public static void SetEulerAngles(this Component mB, Vector3 angle)
		{
			mB.transform.eulerAngles = angle;
		}

		public static void SetLocalEulerAngles(this Component mB, Vector3 angle)
		{
			mB.transform.localEulerAngles = angle;
		}

		public static void InvertActive(this Component mB)
		{
			mB.gameObject.SetActive(!mB.gameObject.activeInHierarchy);
		}
	}
}