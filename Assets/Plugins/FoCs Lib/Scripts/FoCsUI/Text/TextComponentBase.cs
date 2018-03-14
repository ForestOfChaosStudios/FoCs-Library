using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public abstract class TextComponentBase: FoCs2DBehavior
	{
		public abstract string TextData { get; set; }
		public abstract GameObject TextGO { get; }
	}
}