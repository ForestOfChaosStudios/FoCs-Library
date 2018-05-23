﻿using UnityEngine;

namespace ForestOfChaosLib.Camera.Effects
{
	[ExecuteInEditMode]
	public class LowerResolutionEffect: CameraEffectBase
	{
		[Range(0, 8)]
		public int DownResAmount;

		public FilterMode FilterMode;

		public override void OnRenderImage(RenderTexture src, RenderTexture dst)
		{
			int width = src.width >> DownResAmount;
			int height = src.height >> DownResAmount;

			var outRT = RenderTexture.GetTemporary(width, height);
			outRT.filterMode = FilterMode;
			Graphics.Blit(src, outRT);
			Graphics.Blit(outRT, dst);
		}
	}
}