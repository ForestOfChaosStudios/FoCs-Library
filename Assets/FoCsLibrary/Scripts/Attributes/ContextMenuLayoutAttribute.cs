using System;

namespace ForestOfChaosLibrary.Attributes
{
	public class ContextMenuLayoutAttribute: Attribute
	{
		public int AmountPerLine;
		public int Column;
		public int Row;

		public ContextMenuLayoutAttribute(int row, int column, int amountPerLine)
		{
			Row           = row;
			Column        = column;
			AmountPerLine = amountPerLine;
		}
	}
}
