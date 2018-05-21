using System;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public abstract class FoCsImage: FoCs2DBehavior
	{
		public UImage Image;
		public abstract string Text { get; set; }
		public abstract GameObject TextGO { get; }

		public Action onMouseClick;
	}
}