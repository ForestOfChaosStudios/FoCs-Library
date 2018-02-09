using ForestOfChaosLib.ScriptableObjects;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[CreateAssetMenu(fileName = "FOV", menuName = "SO/FOV", order = 0)]
	public class FOVSO: ScriptableObject
	{
		public ImageDataScriptableObject ImageDataGlobal;
		public float FOV = 70;
		public float zNear = 0.1f;
		public float zFar = 1000f;

		public float TanHalfFOV
		{
			get { return Mathf.Tan((FOV / 2) * Mathf.Deg2Rad) * Mathf.Rad2Deg; }
		}

		public Matrix4by4 Projection
		{
			get { return new Matrix4by4().InitPerspective(Mathf.Deg2Rad * FOV, (float)ImageDataGlobal.Data.Width / (float)ImageDataGlobal.Data.Height, zNear, zFar); }
		}
	}
}