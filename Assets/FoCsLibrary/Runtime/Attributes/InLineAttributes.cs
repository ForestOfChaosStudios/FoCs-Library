#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: InLineAttributes.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class MultiInLineAttribute: PropertyAttribute {
        public int index;
        public int totalAmount;

        public MultiInLineAttribute(int _totalAmount = 1, int _index = 0) {
            index       = _index;
            totalAmount = _totalAmount;
        }
    }

    public class Half10LineAttribute: MultiInLineAttribute {
        public Half10LineAttribute(): base(2) { }
    }

    public class Half01LineAttribute: MultiInLineAttribute {
        public Half01LineAttribute(): base(2, 1) { }
    }

    public class Third100LineAttribute: MultiInLineAttribute {
        public Third100LineAttribute(): base(3) { }
    }

    public class Third010LineAttribute: MultiInLineAttribute {
        public Third010LineAttribute(): base(3, 1) { }
    }

    public class Third001LineAttribute: MultiInLineAttribute {
        public Third001LineAttribute(): base(3, 2) { }
    }
}