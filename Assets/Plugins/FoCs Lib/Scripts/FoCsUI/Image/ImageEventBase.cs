using System;
using ForestOfChaosLib.Components;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public abstract class ImageEventBase: FoCs2DBehavior
	{
		public abstract UImage Image { get; }
		public abstract string ImageText { get; set; }
		public abstract GameObject ImageGO { get; }
		public abstract GameObject TextGO { get; }

		public Action onMouseClick;
	}
}