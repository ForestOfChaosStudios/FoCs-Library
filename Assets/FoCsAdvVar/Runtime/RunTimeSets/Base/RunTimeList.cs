#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: RunTimeList.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    public abstract class RunTimeList<T>: RunTimeList {
        [NonSerialized]
        public List<T> Items = new List<T>();

        public override int Count => Items.Count;

        public void Add(T t) {
            if (!Items.Contains(t) && (t != null))
                Items.Add(t);
        }

        public void Remove(T t) {
            Items.Remove(t);
        }
    }

    public abstract class RunTimeList: ScriptableObject {
        public abstract int Count { get; }
    }
}