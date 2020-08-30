#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: AdvFolderNameAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using System;

namespace ForestOfChaos.Unity.AdvVar {
    public class AdvFolderNameAttribute: Attribute, IComparable, IComparable<AdvFolderNameAttribute> {

        public enum InternalNames {
            SystemTypes,
            SystemTypeLists,
            Unity,
            UnityLists,
            ForestOfChaos,
            ForestOfChaosLists,
            RunTime,
            Other
        }

        private readonly InternalNames _InternalNames;
        public           string        ToggleName;

        public AdvFolderNameAttribute() {
            ToggleName     = "";
            _InternalNames = InternalNames.Other;
        }

        public AdvFolderNameAttribute(string toggleName) {
            ToggleName     = toggleName;
            _InternalNames = InternalNames.Other;
        }

        public AdvFolderNameAttribute(InternalNames toggleName) {
            ToggleName     = toggleName.ToString();
            _InternalNames = toggleName;
        }

        public int CompareTo(object obj) {
            if (ReferenceEquals(null, obj))
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            if (!(obj is AdvFolderNameAttribute))
                throw new ArgumentException($"Object must be of type {nameof(AdvFolderNameAttribute)}");

            return CompareTo((AdvFolderNameAttribute)obj);
        }

        public int CompareTo(AdvFolderNameAttribute other) {
            if (ReferenceEquals(this, other))
                return 0;

            if (ReferenceEquals(null, other))
                return 1;

            if (other._InternalNames == InternalNames.Other)
                return string.Compare(ToggleName, other.ToggleName, StringComparison.Ordinal);

            return _InternalNames.CompareTo(other._InternalNames);
        }
    }


#region Internal Classes
    public class AdvFolderNameUnityAttribute: AdvFolderNameAttribute {
        public AdvFolderNameUnityAttribute(): base(InternalNames.Unity) { }
    }

    public class AdvFolderNameUnityListsAttribute: AdvFolderNameAttribute {
        public AdvFolderNameUnityListsAttribute(): base(InternalNames.UnityLists) { }
    }

    public class AdvFolderNameSystemAttribute: AdvFolderNameAttribute {
        public AdvFolderNameSystemAttribute(): base(InternalNames.SystemTypes) { }
    }

    public class AdvFolderNameSystemTypeListsAttribute: AdvFolderNameAttribute {
        public AdvFolderNameSystemTypeListsAttribute(): base(InternalNames.SystemTypeLists) { }
    }

    public class AdvFolderNameForestOfChaosAttribute: AdvFolderNameAttribute {
        public AdvFolderNameForestOfChaosAttribute(): base(InternalNames.ForestOfChaos) { }
    }

    public class AdvFolderNameForestOfChaosListsAttribute: AdvFolderNameAttribute {
        public AdvFolderNameForestOfChaosListsAttribute(): base(InternalNames.ForestOfChaosLists) { }
    }

    public class AdvFolderNameRunTimeAttribute: AdvFolderNameAttribute {
        public AdvFolderNameRunTimeAttribute(): base(InternalNames.RunTime) { }
    }
#endregion


}