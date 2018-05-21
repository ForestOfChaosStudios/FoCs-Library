using ForestOfChaosLib.Components;
using UnityEngine;

namespace ForestOfChaosLib.Camera.Effects
{
	public abstract class CameraEffectBase: FoCsBehavior
	{
		public abstract void OnRenderImage(RenderTexture src, RenderTexture dst);
	}
}