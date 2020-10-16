#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Rigidbody2DExtension.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Extensions {
    public static class Rigidbody2DExtension {
        public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius) {
            var dir     = body.transform.position - explosionPosition;
            var wearoff = 1                       - (dir.magnitude / explosionRadius);
            body.AddForce(dir.normalized * explosionForce * wearoff);
        }

        public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier) {
            var dir       = body.transform.position - explosionPosition;
            var wearoff   = 1                       - (dir.magnitude / explosionRadius);
            var baseForce = dir.normalized * explosionForce * wearoff;
            body.AddForce(baseForce);
            var upliftWearoff = 1 - (upliftModifier / explosionRadius);
            var upliftForce   = Vector2.up * explosionForce * upliftWearoff;
            body.AddForce(upliftForce);
        }
    }
}