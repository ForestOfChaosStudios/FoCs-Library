using ForestOfChaosLib.Generics;
using ForestOfChaosLib.Types;
using ForestOfChaosLib.Interfaces;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	public class TextureMaker: Singleton<TextureMaker>, IStart, IOnDisable
	{
		public Texture2D Texture;

		public ImageDataScriptableObject ImageData;
		public Colour DefualtColour = new Colour(128, 64, 255);
		public Colour ScrollColour = new Colour();
		public float persp = 50;
		public RenderableScriptableObject RenderableScriptableObject;
		public RenderableScriptableObject[] RenderableScriptableObjectArray;

		public int rawIndex = 3;

		public void Start()
		{
			ImageData.Data.InitBuffer();

			Texture = new Texture2D(ImageData.Data.Width, ImageData.Data.Height, ImageData.Data.TexFormat, false) {filterMode = FilterMode.Point};
			DisplayTexture();
		}

		private void DisplayTexture()
		{
			if(GetComponent<Renderer>())
				GetComponent<Renderer>().material.mainTexture = Texture;
			if(GetComponent<UnityEngine.UI.RawImage>())
				GetComponent<UnityEngine.UI.RawImage>().texture = Texture;
		}

		public int index = 0;
		public int lastIndex = 0;
		public float moveXSpeed = 2;
		public float moveYSpeed = 2;
		public float moveZSpeed = 2;

		public void Update()
		{
			//RenderableScriptableObject.Render(ImageData);
			foreach(var renderable in RenderableScriptableObjectArray)
			{
				renderable.Render(ImageData);
			}

			Texture.LoadRawTextureData(ImageData.Data.Buffer);
			Texture.Apply();
		}

		private bool IsInBounds(Vector3 num)
		{
			return num.x >= 0 && num.x < ImageData.Data.Width && num.y >= 0 && num.y < ImageData.Data.Height && num.z >= 0 && num.z < 256;
		}

		private void DoThingWItPix()
		{
			lastIndex = index;

			ImageData.Data.DrawIndexedPixel(lastIndex, DefualtColour);
			ImageData.Data.DrawIndexedPixel(index++, ScrollColour);

			if(index >= ImageData.Data.Size)
				index = 0;
		}

		private void DiscoPrint()
		{
			lastIndex = index;
			index = (int)Mathf.PingPong(Time.time, ImageData.Data.Size);

			DefualtColour.R += (byte)Mathf.PingPong(Time.time + Time.deltaTime + 3, 255);
			DefualtColour.G += (byte)Mathf.PingPong(Time.time, 255);
			DefualtColour.B += (byte)Mathf.PingPong(Time.time + Time.deltaTime * 6, 255);

			//if (index == 0) ImageData.DrawIndexedPixel(ImageData.Size - 1, DefualtColour);
			ImageData.Data.DrawIndexedPixel(lastIndex, DefualtColour);

			ImageData.Data.DrawIndexedPixel(index++, ScrollColour);

			if(index >= ImageData.Data.Size)
				index = 0;
		}

		public void OnDisable()
		{
			ImageData.Data.Buffer = new byte[0];
		}
	}
}