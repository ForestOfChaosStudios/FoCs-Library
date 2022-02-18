#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SingletonBase.cs
//    Created: 2020/10/11
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Generics {
    /// <summary>
    ///     Generally you shouldn't use this, this is used as a base for all of the other Singleton classes
    /// </summary>
    /// <typeparam name="S">the type to have a single instance of</typeparam>
    public class SingletonBase<S>: MonoBehaviour where S: MonoBehaviour {
        protected static S instance;

        public static bool InstanceNull => instance == null;

        public static S Instance {
            get {
                if (instance)
                    return instance;

                instance = FindObjectOfType<S>();

                if (instance)
                    return instance;

                if (Application.isPlaying)
                    CreateInstance();
                else
                    Debug.LogError($"Unable to create: {typeof(S)}. One Should be added to scene."); //Print error

                return instance;
            }
        }

        public static GameObject CreateInstance() {
            var go = new GameObject($"{typeof(S)} Instance", typeof(S));
            go.transform.ResetLocalPosRotScale();

            return go;
        }

        public static GameObject CreateInstance(string name) {
            var go = new GameObject(name, typeof(S));
            go.transform.ResetLocalPosRotScale();

            return go;
        }

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