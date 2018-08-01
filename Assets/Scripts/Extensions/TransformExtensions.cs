using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class TransformExtensions
	{
		public static void ResetLocalPosRotScale(this Transform tF)
		{
			tF.localPosition    = Vector3.zero;
			tF.localEulerAngles = Vector3.zero;
			tF.localScale       = Vector3.one;
		}

		public static void ResetPosRotScale(this Transform tF)
		{
			tF.position    = Vector3.zero;
			tF.eulerAngles = Vector3.zero;
			tF.localScale  = Vector3.one;
		}

		public static void DestroyChildren(this Transform tF)
		{
			for(var i = tF.childCount - 1; i >= 0; i--)
				Object.Destroy(tF.GetChild(i).gameObject);
		}

		public static void DestroyImmediateChildren(this Transform tF)
		{
			for(var i = tF.childCount - 1; i >= 0; i--)
				Object.DestroyImmediate(tF.GetChild(i).gameObject);
		}

		public static void SetActiveChildren(this Transform tF, bool active)
		{
			for(var i = tF.childCount - 1; i >= 0; i--)
				tF.GetChild(i).gameObject.SetActive(active);
		}

		public static List<Vector3> TransformDirections(this Transform tF, IEnumerable<Vector3> enumerable)
		{
			var list = new List<Vector3>();

			foreach(var vector3 in enumerable)
				list.Add(tF.TransformDirection(vector3));

			return list;
		}

		public static List<Vector3> TransformPoints(this Transform tF, IEnumerable<Vector3> enumerable)
		{
			var list = new List<Vector3>();

			foreach(var vector3 in enumerable)
				list.Add(tF.TransformPoint(vector3));

			return list;
		}

		public static List<Vector3> TransformVectors(this Transform tF, IEnumerable<Vector3> enumerable)
		{
			var list = new List<Vector3>();

			foreach(var vector3 in enumerable)
				list.Add(tF.TransformVector(vector3));

			return list;
		}

		public static List<Vector3> InverseTransformDirections(this Transform tF, IEnumerable<Vector3> enumerable)
		{
			var list = new List<Vector3>();

			foreach(var vector3 in enumerable)
				list.Add(tF.InverseTransformDirection(vector3));

			return list;
		}

		public static List<Vector3> InverseTransformPoints(this Transform tF, IEnumerable<Vector3> enumerable)
		{
			var list = new List<Vector3>();

			foreach(var vector3 in enumerable)
				list.Add(tF.InverseTransformPoint(vector3));

			return list;
		}

		public static List<Vector3> InverseTransformVectors(this Transform tF, IEnumerable<Vector3> enumerable)
		{
			var list = new List<Vector3>();

			foreach(var vector3 in enumerable)
				list.Add(tF.InverseTransformVector(vector3));

			return list;
		}

		public static void CopyTransform(this Transform t, Transform other)
		{
			t.position = other.position;
			t.rotation = other.rotation;
			t.localScale = other.localScale;
		}
	}
}
