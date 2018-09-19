using UnityEngine;

namespace ForestOfChaosLibrary.FoCsUI.Text
{
	public abstract class FoCsText: FoCs2DBehavior
	{
		public abstract string     Text   { get; set; }
		public abstract GameObject TextGO { get; }
	}
}
