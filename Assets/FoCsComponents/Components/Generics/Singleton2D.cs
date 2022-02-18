#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: Singleton2D.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;

namespace ForestOfChaos.Unity.Generics {
    [Serializable]
    public class Singleton2D<S>: SingletonBase<S> where S: FoCs2DBehavior { }
}