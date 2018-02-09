using ForestOfChaosLib.Attributes;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class ImageEvent: ImageEventBase
	{
		[NoFoldout(true)]
		public ImageText myImage;

		public override UImage Image
		{
			get { return myImage.Image; }
		}

		public override string ImageText
		{
			get { return myImage.Text.text; }
			set { myImage.Text.text = value; }
		}

		public override GameObject ImageGO
		{
			get { return Image.gameObject; }
		}

		public override GameObject TextGO
		{
			get { return myImage.Text.gameObject; }
		}
	}
}