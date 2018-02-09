using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[CreateAssetMenu(fileName = "Mesh3D", menuName = "SO/Mesh3D", order = 0)]
	public class Mesh3D: RenderableScriptableObject
	{
		public MeshSO Mesh;
		public Mesh Mosh;
		public Colour RenderColour;
		public Colour BackgroundColour;
		public float RenderScaleSO = 50;
		public float RenderScale = 50;
		public Vector3 RotCounter;
		public Vector3 RotSpeed;
		public bool UseSO = true;
		public Vector3 middle;
		public ScanBuffer ScanBuffer;

		public override void Render(ImageData ImageData)
		{
			RotCounter += RotSpeed * Time.deltaTime;
			//Keeps the number less then 1080 this is a magic number I found that it resets of screen.
			RotCounter.x %= 1080f;
			RotCounter.y %= 1080f;
			RotCounter.z %= 1080f;
			middle.Set(ImageData.HalfWidth, ImageData.HalfHeight, middle.z);
			ScanBuffer.Buffer = new int[ScanBuffer.ImageData.Height * 2];

			var translation = new Matrix4by4().InitTranslation(0, 0, 3);
			var rotation = new Matrix4by4().InitRotation(RotCounter.x, RotCounter.x, RotCounter.x);
			var transform = FOV.Projection.Mul(translation.Mul(rotation));
			if(UseSO)
				DrawMeshSO(transform);
			else
				DrawUnityMesh(transform);
		}

		private void DrawMeshSO(Matrix4by4 transform)
		{
			for(int i = 0; i < Mesh.Vertices.Count - 2; i++)
			{
				ScanBuffer.FillTriangleM((Mesh.Vertices[i] * RenderScaleSO).Transform(transform),
										 (Mesh.Vertices[i + 1] * RenderScaleSO).Transform(transform),
										 (Mesh.Vertices[i + 2] * RenderScaleSO).Transform(transform),
										 RenderColour);
			}
			//Draws the side triangles, this is not cover all the sides
			ScanBuffer.FillTriangleM((Mesh.Vertices[0] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[1] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[4] * RenderScaleSO).Transform(transform),
									 RenderColour);

			ScanBuffer.FillTriangleM((Mesh.Vertices[0] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[4] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[5] * RenderScaleSO).Transform(transform),
									 RenderColour);

			ScanBuffer.FillTriangleM((Mesh.Vertices[3] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[1] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[4] * RenderScaleSO).Transform(transform),
									 RenderColour);

			ScanBuffer.FillTriangleM((Mesh.Vertices[3] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[1] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[4] * RenderScaleSO).Transform(transform),
									 RenderColour);

			ScanBuffer.FillTriangleM((Mesh.Vertices[0] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[1] * RenderScaleSO).Transform(transform),
									 (Mesh.Vertices[4] * RenderScaleSO).Transform(transform),
									 RenderColour);
		}

		private void DrawUnityMesh(Matrix4by4 transform)
		{
			for(int i = 0; i < Mosh.triangles.Length - 2; i += 3)
			{
				ScanBuffer.FillTriangleM(new Vertex((Mosh.vertices[Mosh.triangles[i]] * RenderScale * 0.5f) + (Vector3.forward * middle.z)).Transform(transform),
										 new Vertex((Mosh.vertices[Mosh.triangles[i + 1]] * RenderScale * 0.5f) + (Vector3.forward * middle.z)).Transform(transform),
										 new Vertex((Mosh.vertices[Mosh.triangles[i + 2]] * RenderScale * 0.5f) + (Vector3.forward * middle.z)).Transform(transform),
										 RenderColour);
			}
		}
	}
}