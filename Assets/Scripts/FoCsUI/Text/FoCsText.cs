using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public abstract class FoCsText: FoCs2DBehavior
	{
		public abstract string Text { get; set; }
		public abstract GameObject TextGO { get; }
	}
}