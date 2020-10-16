#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvFolderNameAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;

namespace ForestOfChaos.Unity.AdvVar {
    public class AdvFolderNameAttribute: Attribute, IComparable, IComparable<AdvFolderNameAttribute> {
        private const int USER_OFFSET = 20;

        private readonly int    Order;
        public readonly  string ToggleName;

        public AdvFolderNameAttribute() {
            ToggleName = "Other";
            Order      = USER_OFFSET;
        }

        public AdvFolderNameAttribute(string toggleName, int order) {
            ToggleName = toggleName;
            Order      = order + USER_OFFSET;
        }

        public int CompareTo(object obj) {
            if (obj is null)
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            if (!(obj is AdvFolderNameAttribute))
                throw new ArgumentException($"Object must be of type {nameof(AdvFolderNameAttribute)}");

            return CompareTo((AdvFolderNameAttribute)obj);
        }

        public int CompareTo(AdvFolderNameAttribute other) {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            var order = Order.CompareTo(other.Order);

            return order == 0? string.Compare(ToggleName, other.ToggleName, StringComparison.Ordinal) : order;
        }
    }

#region Pre Built Classes
    public class AdvFolderNameSystemAttribute: AdvFolderNameAttribute {
        public AdvFolderNameSystemAttribute(): base("SystemTypes", 0 - 20) { }
    }

    public class AdvFolderNameUnityAttribute: AdvFolderNameAttribute {
        public AdvFolderNameUnityAttribute(): base("Unity", 1 - 20) { }
    }

    public class AdvFolderNameForestOfChaosAttribute: AdvFolderNameAttribute {
        public AdvFolderNameForestOfChaosAttribute(): base("ForestOfChaos", 3 - 20) { }
    }

    public class AdvFolderNameUnityListsAttribute: AdvFolderNameAttribute {
        public AdvFolderNameUnityListsAttribute(): base("UnityLists", 4 - 20) { }
    }

    public class AdvFolderNameSystemTypeListsAttribute: AdvFolderNameAttribute {
        public AdvFolderNameSystemTypeListsAttribute(): base("SystemTypeLists", 5 - 20) { }
    }

    public class AdvFolderNameForestOfChaosListsAttribute: AdvFolderNameAttribute {
        public AdvFolderNameForestOfChaosListsAttribute(): base("ForestOfChaosLists", 6 - 20) { }
    }

    public class AdvFolderNameRunTimeAttribute: AdvFolderNameAttribute {
        public AdvFolderNameRunTimeAttribute(): base("RunTime", 7 - 20) { }
    }
#endregion

}