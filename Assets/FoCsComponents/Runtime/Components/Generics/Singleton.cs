#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: Singleton.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;

namespace ForestOfChaos.Unity.Generics {
    [Serializable]
    public class Singleton<S>: SingletonBase<S> where S: FoCsBehaviour { }
}