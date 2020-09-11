#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ContextMenuLayoutAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;

namespace ForestOfChaos.Unity.Attributes {
    public class ContextMenuLayoutAttribute: Attribute {
        public int AmountPerLine;
        public int Column;
        public int Row;

        public ContextMenuLayoutAttribute(int row, int column, int amountPerLine) {
            Row           = row;
            Column        = column;
            AmountPerLine = amountPerLine;
        }
    }
}