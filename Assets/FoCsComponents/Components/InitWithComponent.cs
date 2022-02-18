#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: InitWithComponent.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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