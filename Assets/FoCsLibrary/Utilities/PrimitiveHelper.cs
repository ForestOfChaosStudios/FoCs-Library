#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: PrimitiveHelper.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.Utilities {
    public static class PrimitiveHelper {
        private static readonly Dictionary<PrimitiveType, Mesh> primitiveMeshes = new Dictionary<PrimitiveType, Mesh>();

        public static GameObject CreatePrimitive(PrimitiveType type, bool withCollider) {
            var go = GameObject.CreatePrimitive(type);

            if (withCollider)
                return go;

            Object.Destroy(go.GetComponent<Collider>());

            return go;
        }

        public static Mesh GetPrimitiveMesh(PrimitiveType type) {
            if (!primitiveMeshes.ContainsKey(type))
                primitiveMeshes[type] = CreatePrimitiveMesh(type);

            return primitiveMeshes[type];
        }

        private static Mesh CreatePrimitiveMesh(PrimitiveType type) {
            var gameObject = GameObject.CreatePrimitive(type);
            var mesh       = gameObject.GetComponent<MeshFilter>().sharedMesh;
            Object.DestroyImmediate(gameObject);

            return mesh;
        }
    }
}