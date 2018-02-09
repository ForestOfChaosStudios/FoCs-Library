using System;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[Serializable]
	public class ImageData
	{
		[Half10Line]
		public int Width = 32;

		[Half01Line]
		public int Height = 32;

		public float HalfWidth
		{
			get
			{
				if(Buffer.Length == 0)
					InitBuffer();
				return Width * 0.5f;
			}
		}

		public float HalfHeight
		{
			get
			{
				if(Buffer.Length == 0)
					InitBuffer();
				return Height * 0.5f;
			}
		}

		public TextureFormat TexFormat = TextureFormat.ARGB32;

		public int Channels
		{
			get { return 4; }
		}

		[ImageDataArray]
		public byte[] Buffer;

		public int Size
		{
			get
			{
				if(Buffer.Length == 0)
					InitBuffer();
				return Width * Height;
			}
		}

		public int FullSize
		{
			get
			{
				if(Buffer.Length == 0)
					InitBuffer();
				return Width * Height * Channels;
			}
		}

		public ImageData(int x, int y)
		{
			Width = x;
			Height = y;
			InitBuffer();
		}

		public void InitBuffer()
		{
			Buffer = new byte[Width * Height * Channels];
		}

		public void Clear()
		{
			SetAllPixels(255, 255, 255);
		}

		public void Clear(Colour col)
		{
			SetAllPixels(col);
		}

		public void DrawPixel(int x, int y, byte r, byte g, byte b, byte a = 255, bool overflow = false)
		{
			DrawPixelMaster(x, y, r, g, b, a, overflow);
		}

		public void DrawPixel(int x, int y, Colour colour, bool overflow = false)
		{
			DrawPixelMaster(x, y, colour.R, colour.G, colour.B, colour.A, overflow);
		}

		public void DrawPixel(float x, float y, Colour colour, bool overflow = false)
		{
			DrawPixelMaster((int)x, (int)y, colour.R, colour.G, colour.B, colour.A, overflow);
		}

		private void DrawPixelMaster(int x, int y, byte r, byte g, byte b, byte a, bool overflow = false)
		{
			var index = ((x * Width) + y) * Channels;
			if(overflow)
			{
				if(x > Width)
				{
					x -= Width;
				}
				else if(x < 0)
				{
					x += Width;
				}

				if(y > Height)
				{
					y -= Height;
				}
				else if(y < 0)
				{
					y += Height;
				}
				index = ((x * Width) + y) * Channels;
			}

			if((index > FullSize - 1) || (index < 0))
				return;
			Buffer[index] = a;
			Buffer[index + 1] = r;
			Buffer[index + 2] = g;
			Buffer[index + 3] = b;
		}

		public void DrawIndexedPixel(int index, byte r, byte g, byte b, byte a = 255)
		{
			index = index * 4;
			if((index > FullSize - 1) || (index < 0))
				return;
			Buffer[index] = a;
			Buffer[index + 1] = r;
			Buffer[index + 2] = g;
			Buffer[index + 3] = b;
		}

		public void DrawRawIndexedPixel(int index, byte r, byte g, byte b, byte a = 255)
		{
			if((index > FullSize - 1) || (index < 0))
				return;
			index -= index % 4;

			Buffer[index] = a;
			Buffer[index + 1] = r;
			Buffer[index + 2] = g;
			Buffer[index + 3] = b;
		}

		public void SetAllPixels(Colour colour)
		{
			for(var i = 0; i < Buffer.Length; i += 4)
				DrawRawIndexedPixel(i, colour);
		}

		public void SetAllPixels(byte r, byte g, byte b, byte a = 255)
		{
			for(var i = 0; i < Buffer.Length; i += 4)
				DrawRawIndexedPixel(i, r, g, b, a);
		}

		public void DrawIndexedPixel(int index, Colour colour)
		{
			DrawIndexedPixel(index, colour.R, colour.G, colour.B, colour.A);
		}

		public void DrawRawIndexedPixel(int index, Colour colour)
		{
			DrawRawIndexedPixel(index, colour.R, colour.G, colour.B, colour.A);
		}
	}
}