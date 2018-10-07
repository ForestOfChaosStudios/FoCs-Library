using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLibrary.Utilities
{
	public static class PrimitiveHelper
	{
		private static readonly Dictionary<PrimitiveType, Mesh> primitiveMeshes = new Dictionary<PrimitiveType, Mesh>();

		public static GameObject CreatePrimitive(PrimitiveType type, bool withCollider)
		{
			var go = GameObject.CreatePrimitive(type);

			if(withCollider)
				return go;

			Object.Destroy(go.GetComponent<Collider>());

			return go;
		}

		public static Mesh GetPrimitiveMesh(PrimitiveType type)
		{
			if(!primitiveMeshes.ContainsKey(type))
				CreatePrimitiveMesh(type);

			return primitiveMeshes[type];
		}

		private static Mesh CreatePrimitiveMesh(PrimitiveType type)
		{
			var gameObject = GameObject.CreatePrimitive(type);
			var mesh       = gameObject.GetComponent<MeshFilter>().sharedMesh;
			Object.Destroy(gameObject);
			primitiveMeshes[type] = mesh;

			return mesh;
		}
	}
}
