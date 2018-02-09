namespace ForestOfChaosLib.TextureRenderer
{
	[System.Serializable]
	public abstract class Renderable: IRenderable
	{
		public abstract void Render(ImageData ImageData);
	}

	public interface IRenderable
	{
		void Render(ImageData ImageData);
	}
}