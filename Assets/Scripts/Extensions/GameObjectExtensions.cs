using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class GameObjectExtensions
	{
		public static void ResetLocalPosRotScale(this GameObject gO)
		{
			gO.transform.ResetLocalPosRotScale();
		}

		public static void ResetPosRotScale(this GameObject gO)
		{
			gO.transform.ResetPosRotScale();
		}

		public static Vector3 GetPosition(this         GameObject gO) => gO.transform.position;
		public static Vector3 GetLocalPosition(this    GameObject gO) => gO.transform.localPosition;
		public static Vector3 GetEulerAngles(this      GameObject gO) => gO.transform.eulerAngles;
		public static Vector3 GetLocalEulerAngles(this GameObject gO) => gO.transform.localEulerAngles;

		public static void SetPosition(this GameObject gO, Vector3 pos)
		{
			gO.transform.position = pos;
		}

		public static void SetLocalPosition(this GameObject gO, Vector3 pos)
		{
			gO.transform.localPosition = pos;
		}

		public static void SetEulerAngles(this GameObject gO, Vector3 angle)
		{
			gO.transform.eulerAngles = angle;
		}

		public static void SetLocalEulerAngles(this GameObject gO, Vector3 angle)
		{
			gO.transform.localEulerAngles = angle;
		}

		public static void InvertActive(this GameObject gO)
		{
			gO.SetActive(!gO.activeInHierarchy);
		}
	}
}
