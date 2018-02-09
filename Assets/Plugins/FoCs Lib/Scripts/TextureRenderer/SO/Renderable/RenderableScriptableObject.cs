using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	public abstract class RenderableScriptableObject: ScriptableObject, IRenderable
	{
		public FOVSO FOV;
		public ImageDataScriptableObject ImageDataGlobal;
		public abstract void Render(ImageData ImageData);
	}
}