using System;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[Serializable]
	public class Star
	{
		public Vector3 Position;
		public Colour Colour;

		public Star()
		{
			Position = Vector3.zero;
			Colour = Colour.White;
		}

		public Star(Vector3 pos)
		{
			Position = pos;
			Colour = Colour.White;
		}

		public Star(Vector3 pos, Colour colour)
		{
			Position = pos;
			Colour = colour;
		}
	}
}