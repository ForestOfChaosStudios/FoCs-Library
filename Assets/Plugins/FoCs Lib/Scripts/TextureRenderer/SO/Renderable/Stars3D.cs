using ForestOfChaosLib.Types;
using ForestOfChaosLib.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ForestOfChaosLib.TextureRenderer
{
	[CreateAssetMenu(fileName = "Stars3D", menuName = "SO/Stars3D", order = 0)]
	public class Stars3D: RenderableScriptableObject, IOnDisable
	{
		public float Speed = 2;
		public float Spread = 100;
		public int TotalNewLength = 42;
		public Colour StarColours;
		public Vertex[] Stars;

		public override void Render(ImageData ImageData)
		{
			if(Stars.Length == 0)
			{
				Stars = new Vertex[TotalNewLength];
				for(int i = 0; i < Stars.Length; i++)
				{
					Stars[i] = new Vertex();
					ResetStar(i);
				}
			}
			ImageData.Clear(Colour.Black);
			for(int i = 0; i < Stars.Length; i++)
			{
				Stars[i].Position.z -= Time.fixedDeltaTime * Speed;

				if(Stars[i].Position.z <= 0)
					ResetStar(i);
				int x = (int)((Stars[i].Position.x / (Stars[i].Position.z * FOV.TanHalfFOV)) * ImageData.HalfWidth + ImageData.HalfWidth);
				int y = (int)((Stars[i].Position.y / (Stars[i].Position.z * FOV.TanHalfFOV)) * ImageData.HalfHeight + ImageData.HalfHeight);

				if(x < 0 || x >= ImageData.Width || y < 0 || y >= ImageData.Height)
					ResetStar(i);
				ImageData.DrawPixel(x, y, StarColours);
			}
		}

		private void ResetStar(int i)
		{
			Stars[i].Position.x = Random.Range(-Spread, Spread);
			Stars[i].Position.y = Random.Range(-Spread, Spread);
			Stars[i].Position.z = Random.Range(0.0f, Spread);
		}

		[ContextMenu("Clear Array")]
		public void OnDisable()
		{
			Stars = new Vertex[0];
		}
	}
}