#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SingletonRigidbody.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;

namespace ForestOfChaos.Unity.Generics {
    [Serializable]
    public class SingletonRigidbody<S>: SingletonBase<S> where S: FoCsRigidbodyBehaviour { }
}