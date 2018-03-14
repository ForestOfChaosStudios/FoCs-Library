using System;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public abstract class ImageComponentBase: FoCs2DBehavior
	{
		public abstract UImage Image { get; }
		public abstract string ImageText { get; set; }
		public abstract GameObject ImageGO { get; }
		public abstract GameObject TextGO { get; }

		public Action onMouseClick;
	}
}