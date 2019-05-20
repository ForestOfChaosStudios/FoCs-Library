using System;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLibrary.FoCsUI.Image
{
	public abstract class FoCsImage: FoCs2DBehavior
	{
		public          UImage     Image;
		public          Action     onMouseClick;
		public abstract string     Text   { get; set; }
		public abstract GameObject TextGO { get; }
	}
}
