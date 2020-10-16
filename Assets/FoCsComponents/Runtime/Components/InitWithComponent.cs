#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: InitWithComponent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    public class InitWithComponent<T> where T: Component {
        public GameObject gameObject;
        public T          ScriptComponent;

        public InitWithComponent(string name) {
            gameObject      = new GameObject(name);
            ScriptComponent = gameObject.AddComponent<T>();
        }

        public static implicit operator T(InitWithComponent<T> fp) => fp.ScriptComponent;

        public static implicit operator GameObject(InitWithComponent<T> fp) => fp.gameObject;
    }
}