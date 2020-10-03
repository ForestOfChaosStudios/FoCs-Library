﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: Singleton2D.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Generics {
    [Serializable]
    public class Singleton2D<S>: FoCs2DBehavior where S: FoCs2DBehavior {
        protected static S instance;

        public static bool instanceNull => instance == null;

        public static S Instance {
            get {
                if (instance)
                    return instance;

                instance = FindObjectOfType<S>();

                if (!instance)
                    Debug.LogError(typeof(S) + " is needed in the scene."); //Print error

                return instance;
            }
        }

        public static bool InstanceNull => Instance == null;

        public void DestroyOtherInstances() {
            var others = FindObjectsOfType<S>();

            if (others.Length == 1)
                return;

            for (var i = others.Length - 1; i >= 0; i--) {
                if (Instance == others[1])
                    continue;

                Destroy(others[i]);
            }
        }
    }
}