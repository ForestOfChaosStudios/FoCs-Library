using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.UnityScriptsExtensions
{
	public static class UnityClassExtensions
	{
		public static void ResetLocalPosRotScale(this GameObject gO)
		{
			gO.transform.ResetLocalPosRotScale();
		}

		public static void ResetPosRotScale(this GameObject gO)
		{
			gO.transform.ResetPosRotScale();
		}

		public static void ResetVelocity(this Rigidbody rB)
		{
			rB.velocity = Vector3.zero;
			rB.angularVelocity = Vector3.zero;
		}

		public static Quaternion GetQuaternion(this Vector3 v3)
		{
			return Quaternion.Euler(v3);
		}

		public static Vector3 GetPosition(this GameObject gO)
		{
			return gO.transform.position;
		}

		public static Vector3 GetLocalPosition(this GameObject gO)
		{
			return gO.transform.localPosition;
		}

		public static Vector3 GetEulerAngles(this GameObject gO)
		{
			return gO.transform.eulerAngles;
		}

		public static Vector3 GetLocalEulerAngles(this GameObject gO)
		{
			return gO.transform.localEulerAngles;
		}

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

		public static Vector3 GetPosition(this MonoBehaviour mB)
		{
			return mB.transform.position;
		}

		public static Vector3 GetLocalPosition(this MonoBehaviour mB)
		{
			return mB.transform.localPosition;
		}

		public static Vector3 GetEulerAngles(this MonoBehaviour mB)
		{
			return mB.transform.eulerAngles;
		}

		public static Vector3 GetLocalEulerAngles(this MonoBehaviour mB)
		{
			return mB.transform.localEulerAngles;
		}

		public static void SetPosition(this MonoBehaviour mB, Vector3 pos)
		{
			mB.transform.position = pos;
		}

		public static void SetLocalPosition(this MonoBehaviour mB, Vector3 pos)
		{
			mB.transform.localPosition = pos;
		}

		public static void SetEulerAngles(this MonoBehaviour mB, Vector3 angle)
		{
			mB.transform.eulerAngles = angle;
		}

		public static void SetLocalEulerAngles(this MonoBehaviour mB, Vector3 angle)
		{
			mB.transform.localEulerAngles = angle;
		}

		public static void InvertActive(this MonoBehaviour mB)
		{
			mB.gameObject.SetActive(!mB.gameObject.activeInHierarchy);
		}

		public static void InvertActive(this GameObject gO)
		{
			gO.SetActive(!gO.activeInHierarchy);
		}

		public static void SetParent(this GameObject gO, Transform parent)
		{
			gO.transform.SetParent(parent);
		}

		public static void SetParent(this GameObject gO, MonoBehaviour parent)
		{
			gO.transform.SetParent(parent.transform);
		}

		public static void SetParent(this GameObject gO, GameObject parent)
		{
			gO.transform.SetParent(parent.transform);
		}

		public static void SetParent(this MonoBehaviour mB, Transform parent)
		{
			mB.transform.SetParent(parent);
		}

		public static void SetParent(this MonoBehaviour mB, MonoBehaviour parent)
		{
			mB.transform.SetParent(parent.transform);
		}

		public static void SetParent(this MonoBehaviour mB, GameObject parent)
		{
			mB.transform.SetParent(parent.transform);
		}
	}
}