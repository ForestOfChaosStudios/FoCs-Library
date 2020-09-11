#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ComponentExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Extensions {
    public static class ComponentExtensions {
        public static Vector3 GetPosition(this Component mB) => mB.transform.position;

        public static Vector3 GetLocalPosition(this Component mB) => mB.transform.localPosition;

        public static Vector3 GetEulerAngles(this Component mB) => mB.transform.eulerAngles;

        public static Vector3 GetLocalEulerAngles(this Component mB) => mB.transform.localEulerAngles;

        public static void SetPosition(this Component mB, Vector3 pos) {
            mB.transform.position = pos;
        }

        public static void SetLocalPosition(this Component mB, Vector3 pos) {
            mB.transform.localPosition = pos;
        }

        public static void SetEulerAngles(this Component mB, Vector3 angle) {
            mB.transform.eulerAngles = angle;
        }

        public static void SetLocalEulerAngles(this Component mB, Vector3 angle) {
            mB.transform.localEulerAngles = angle;
        }

        public static void InvertActive(this Component mB) {
            mB.gameObject.SetActive(!mB.gameObject.activeInHierarchy);
        }
    }
}