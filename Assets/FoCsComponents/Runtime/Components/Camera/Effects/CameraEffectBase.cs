using UnityEngine;

namespace ForestOfChaosLibrary.Components.Camera.Effects
{
	public abstract class CameraEffectBase: FoCsBehaviour
	{
		public abstract void OnRenderImage(RenderTexture src, RenderTexture dst);
	}
}
