using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	public class Matrix4by4
	{
		private float[,] m;

		public Matrix4by4()
		{
			m = new float[4, 4];
		}

		public Matrix4by4 InitIdentity()
		{
			m[0, 0] = 1;
			m[0, 1] = 0;
			m[0, 2] = 0;
			m[0, 3] = 0;
			m[1, 0] = 0;
			m[1, 1] = 1;
			m[1, 2] = 0;
			m[1, 3] = 0;
			m[2, 0] = 0;
			m[2, 1] = 0;
			m[2, 2] = 1;
			m[2, 3] = 0;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[3, 3] = 1;

			return this;
		}

		public Matrix4by4 InitScreenSpaceTransform(float halfWidth, float halfHeight)
		{
			m[0, 0] = halfWidth;
			m[0, 1] = 0;
			m[0, 2] = 0;
			m[0, 3] = halfWidth;
			m[1, 0] = 0;
			m[1, 1] = -halfHeight;
			m[1, 2] = 0;
			m[1, 3] = halfHeight;
			m[2, 0] = 0;
			m[2, 1] = 0;
			m[2, 2] = 1;
			m[2, 3] = 0;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[3, 3] = 1;

			return this;
		}

		public Matrix4by4 InitTranslation(float x, float y, float z)
		{
			m[0, 0] = 1;
			m[0, 1] = 0;
			m[0, 2] = 0;
			m[0, 3] = x;
			m[1, 0] = 0;
			m[1, 1] = 1;
			m[1, 2] = 0;
			m[1, 3] = y;
			m[2, 0] = 0;
			m[2, 1] = 0;
			m[2, 2] = 1;
			m[2, 3] = z;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[3, 3] = 1;

			return this;
		}

		public Matrix4by4 InitRotation(float x, float y, float z, float angle)
		{
			float sin = Mathf.Sin(angle);
			float cos = Mathf.Cos(angle);

			m[0, 0] = cos + x * x * (1 - cos);
			m[0, 1] = x * y * (1 - cos) - z * sin;
			m[0, 2] = x * z * (1 - cos) + y * sin;
			m[0, 3] = 0;
			m[1, 0] = y * x * (1 - cos) + z * sin;
			m[1, 1] = cos + y * y * (1 - cos);
			m[1, 2] = y * z * (1 - cos) - x * sin;
			m[1, 3] = 0;
			m[2, 0] = z * x * (1 - cos) - y * sin;
			m[2, 1] = z * y * (1 - cos) + x * sin;
			m[2, 2] = cos + z * z * (1 - cos);
			m[2, 3] = 0;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[3, 3] = 1;

			return this;
		}

		public Matrix4by4 InitRotation(float x, float y, float z)
		{
			Matrix4by4 rx = new Matrix4by4();
			Matrix4by4 ry = new Matrix4by4();
			Matrix4by4 rz = new Matrix4by4();

			rz.m[0, 0] = Mathf.Cos(z);
			rz.m[0, 1] = -Mathf.Sin(z);
			rz.m[0, 2] = 0;
			rz.m[0, 3] = 0;
			rz.m[1, 0] = Mathf.Sin(z);
			rz.m[1, 1] = Mathf.Cos(z);
			rz.m[1, 2] = 0;
			rz.m[1, 3] = 0;
			rz.m[2, 0] = 0;
			rz.m[2, 1] = 0;
			rz.m[2, 2] = 1;
			rz.m[2, 3] = 0;
			rz.m[3, 0] = 0;
			rz.m[3, 1] = 0;
			rz.m[3, 2] = 0;
			rz.m[3, 3] = 1;

			rx.m[0, 0] = 1;
			rx.m[0, 1] = 0;
			rx.m[0, 2] = 0;
			rx.m[0, 3] = 0;
			rx.m[1, 0] = 0;
			rx.m[1, 1] = Mathf.Cos(x);
			rx.m[1, 2] = -Mathf.Sin(x);
			rx.m[1, 3] = 0;
			rx.m[2, 0] = 0;
			rx.m[2, 1] = Mathf.Sin(x);
			rx.m[2, 2] = Mathf.Cos(x);
			rx.m[2, 3] = 0;
			rx.m[3, 0] = 0;
			rx.m[3, 1] = 0;
			rx.m[3, 2] = 0;
			rx.m[3, 3] = 1;

			ry.m[0, 0] = Mathf.Cos(y);
			ry.m[0, 1] = 0;
			ry.m[0, 2] = -Mathf.Sin(y);
			ry.m[0, 3] = 0;
			ry.m[1, 0] = 0;
			ry.m[1, 1] = 1;
			ry.m[1, 2] = 0;
			ry.m[1, 3] = 0;
			ry.m[2, 0] = Mathf.Sin(y);
			ry.m[2, 1] = 0;
			ry.m[2, 2] = Mathf.Cos(y);
			ry.m[2, 3] = 0;
			ry.m[3, 0] = 0;
			ry.m[3, 1] = 0;
			ry.m[3, 2] = 0;
			ry.m[3, 3] = 1;

			m = rz.Mul(ry.Mul(rx)).m;

			return this;
		}

		public Matrix4by4 InitScale(float x, float y, float z)
		{
			m[0, 0] = x;
			m[0, 1] = 0;
			m[0, 2] = 0;
			m[0, 3] = 0;
			m[1, 0] = 0;
			m[1, 1] = y;
			m[1, 2] = 0;
			m[1, 3] = 0;
			m[2, 0] = 0;
			m[2, 1] = 0;
			m[2, 2] = z;
			m[2, 3] = 0;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[3, 3] = 1;

			return this;
		}

		public Matrix4by4 InitPerspective(float fov, float aspectRatio, float zNear, float zFar)
		{
			float tanHalfFOV = Mathf.Tan(fov / 2);
			float zRange = zNear - zFar;

			m[0, 0] = 1.0f / (tanHalfFOV * aspectRatio);
			m[0, 1] = 0;
			m[0, 2] = 0;
			m[0, 3] = 0;
			m[1, 0] = 0;
			m[1, 1] = 1.0f / tanHalfFOV;
			m[1, 2] = 0;
			m[1, 3] = 0;
			m[2, 0] = 0;
			m[2, 1] = 0;
			m[2, 2] = (-zNear - zFar) / zRange;
			m[2, 3] = 2 * zFar * zNear / zRange;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 1;
			m[3, 3] = 0;

			return this;
		}

		public Matrix4by4 InitRotation(Vector4 forward, Vector4 up)
		{
			Vector4 f = forward.normalized;

			Vector4 r = up.normalized;
			r = Vector3.Cross(r, f);

			Vector4 u = Vector3.Cross(f, r);

			return InitRotation(f, u, r);
		}

		public Matrix4by4 InitRotation(Vector4 forward, Vector4 up, Vector4 right)
		{
			Vector4 f = forward;
			Vector4 r = right;
			Vector4 u = up;

			m[0, 0] = r.x;
			m[0, 1] = r.y;
			m[0, 2] = r.z;
			m[0, 3] = 0;
			m[1, 0] = u.x;
			m[1, 1] = u.y;
			m[1, 2] = u.z;
			m[1, 3] = 0;
			m[2, 0] = f.x;
			m[2, 1] = f.y;
			m[2, 2] = f.z;
			m[2, 3] = 0;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[3, 3] = 1;

			return this;
		}

		public Vector4 Transform(Vector4 r)
		{
			return new Vector4(m[0, 0] * r.x + m[0, 1] * r.y + m[0, 2] * r.z + m[0, 3] * r.w,
							   m[1, 0] * r.x + m[1, 1] * r.y + m[1, 2] * r.z + m[1, 3] * r.w,
							   m[2, 0] * r.x + m[2, 1] * r.y + m[2, 2] * r.z + m[2, 3] * r.w,
							   m[3, 0] * r.x + m[3, 1] * r.y + m[3, 2] * r.z + m[3, 3] * r.w);
		}

		public Matrix4by4 Mul(Matrix4by4 r)
		{
			Matrix4by4 res = new Matrix4by4();

			for(int i = 0; i < 4; i++)
			{
				for(int j = 0; j < 4; j++)
				{
					res.Set(i, j, m[i, 0] * r.Get(0, j) + m[i, 1] * r.Get(1, j) + m[i, 2] * r.Get(2, j) + m[i, 3] * r.Get(3, j));
				}
			}

			return res;
		}

		public float Get(int x, int y)
		{
			return m[x, y];
		}

		public void SetM(float[,] m)
		{
			this.m = m;
		}

		public void Set(int x, int y, float value)
		{
			m[x, y] = value;
		}
	}
}