using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.MeshHelpers
{
	public static class PrimitiveHelper
	{
		private static Dictionary<PrimitiveType, Mesh> primitiveMeshes = new Dictionary<PrimitiveType, Mesh>();

		public static GameObject CreatePrimitive(PrimitiveType type, bool withCollider)
		{
			var go = GameObject.CreatePrimitive(type);
			if(withCollider)
			{
				return go;
			}

			Object.Destroy(go.GetComponent<Collider>());

			return go;
		}

		public static Mesh GetPrimitiveMesh(PrimitiveType type)
		{
			if(!PrimitiveHelper.primitiveMeshes.ContainsKey(type))
				PrimitiveHelper.CreatePrimitiveMesh(type);

			return PrimitiveHelper.primitiveMeshes[type];
		}

		private static Mesh CreatePrimitiveMesh(PrimitiveType type)
		{
			GameObject gameObject = GameObject.CreatePrimitive(type);
			Mesh mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			GameObject.Destroy(gameObject);

			PrimitiveHelper.primitiveMeshes[type] = mesh;
			return mesh;
		}
	}
}