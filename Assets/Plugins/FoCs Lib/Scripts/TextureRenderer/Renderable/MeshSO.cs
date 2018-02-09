using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[CreateAssetMenu(fileName = "New Mesh", menuName = "SO/Mesh", order = 0)]
	public class MeshSO: ScriptableObject
	{
		public List<Vertex> Vertices = new List<Vertex>
									   {
										   //Top
										   new Vertex(-0.5f, 0.5f, 0.5f),
										   new Vertex(0.5f, 0.5f, 0.5f),
										   new Vertex(0.5f, -0.5f, 0.5f),
										   new Vertex(-0.5f, -0.5f, 0.5f),
										   //Bottom
										   new Vertex(-0.5f, 0.5f, -0.5f),
										   new Vertex(0.5f, 0.5f, -0.5f),
										   new Vertex(0.5f, -0.5f, -0.5f),
										   new Vertex(-0.5f, -0.5f, -0.5f)
									   };
	}
}