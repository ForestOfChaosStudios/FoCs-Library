using System;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[Serializable]
	public struct Vertex
	{
		public float X
		{
			get { return Position.x; }
			set { Position.x = value; }
		}

		public float Y
		{
			get { return Position.y; }
			set { Position.y = value; }
		}

		public float Z
		{
			get { return Position.z; }
			set { Position.z = value; }
		}

		/// <summary>
		/// Mainly used for a depth value
		/// </summary>
		public float W
		{
			get { return Position.w; }
			set { Position.w = value; }
		}

		public Vector4 Position;

		public Vertex(Vector4 position)
		{
			Position = position;
		}

		public Vertex(float x, float y, float z, float w = 1)
		{
			Position = new Vector4(x, y, z, w);
		}

		public Vertex Transform(Matrix4by4 transfrom)
		{
			return new Vertex(transfrom.Transform(Position));
		}

		public Vertex PerspectiveDivide()
		{
			return new Vertex(Position.x / Position.w, Position.y / Position.w, Position.z / Position.w, Position.w);
		}

		public static Vertex operator -(Vertex a)
		{
			return new Vertex(-a.X, -a.Y, -a.Z);
		}

		public static Vertex operator +(Vertex a)
		{
			return new Vertex(+a.X, +a.Y, +a.Z);
		}

		public static Vertex operator *(Vertex a, int d)
		{
			return new Vertex(a.X * d, a.Y * d, a.Z * d);
		}

		public static Vertex operator *(Vertex a, float d)
		{
			return new Vertex(a.X * d, a.Y * d, a.Z * d);
		}

		public static Vertex operator *(Vertex a, Vertex b)
		{
			return new Vertex(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
		}

		public static Vertex operator +(Vertex a, int d)
		{
			return new Vertex(a.X + d, a.Y + d, a.Z + d);
		}

		public static Vertex operator +(Vertex a, float d)
		{
			return new Vertex(a.X + d, a.Y + d, a.Z + d);
		}

		public static Vertex operator +(Vertex a, Vertex b)
		{
			return new Vertex(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public static Vertex operator -(Vertex a, int d)
		{
			return new Vertex(a.X - d, a.Y - d, a.Z - d);
		}

		public static Vertex operator -(Vertex a, float d)
		{
			return new Vertex(a.X - d, a.Y - d, a.Z - d);
		}

		public static Vertex operator -(Vertex a, Vertex b)
		{
			return new Vertex(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		public static Vertex operator /(Vertex a, int d)
		{
			return new Vertex(a.X / d, a.Y / d, a.Z / d);
		}

		public static Vertex operator /(Vertex a, float d)
		{
			return new Vertex(a.X / d, a.Y / d, a.Z / d);
		}

		public static Vertex operator /(Vertex a, Vertex b)
		{
			return new Vertex(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
		}

		public static implicit operator Vertex(Vector3 pos)
		{
			return new Vertex(pos);
		}

		public static implicit operator Vector3(Vertex pos)
		{
			return new Vector3(pos.X, pos.Y, pos.Z);
		}

		public static implicit operator Vertex(int pos)
		{
			return new Vertex(Vector4.one * pos);
		}

		public static implicit operator Vertex(float pos)
		{
			return new Vertex(Vector4.one * pos);
		}
	}
}