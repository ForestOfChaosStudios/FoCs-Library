#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: BaseAddToRunTimeSet.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    public abstract class BaseAddToRunTimeSet<T>: FoCsBehaviour {
        public RunTimeList<T> Set;

        public abstract T Value { get; }

        public void OnEnable() {
            if (Set)
                Set.Add(Value);
        }

        public void OnDisable() {
            if (Set)
                Set.Remove(Value);
        }
    }
}