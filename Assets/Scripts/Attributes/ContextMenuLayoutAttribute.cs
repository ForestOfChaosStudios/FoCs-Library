using System;

namespace ForestOfChaosLib.Attributes
{
	public class ContextMenuLayoutAttribute: Attribute
	{
		public int Row;
		public int Column;
		public int AmountPerLine;

		public ContextMenuLayoutAttribute(int row, int column, int amountPerLine)
		{
			Row = row;
			Column = column;
			AmountPerLine = amountPerLine;
		}
	}
}