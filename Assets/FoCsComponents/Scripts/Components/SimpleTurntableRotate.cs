using ForestOfChaosLibrary.Attributes;
using UnityEngine;

namespace ForestOfChaosLibrary.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Simple Turntable Rotate")]
	public class SimpleTurntableRotate: FoCsBehaviour
	{
		public                                             Vector3   RotateAngle;
		public                                             bool      RandomizeAtStart;
		[ConditionalHide("RandomizeAtStart", true)] public Vector3   RotateAngleMax;
		[ConditionalHide("RandomizeAtStart", true)] public bool      RandomizeX = true;
		[ConditionalHide("RandomizeAtStart", true)] public bool      RandomizeY = true;
		[ConditionalHide("RandomizeAtStart", true)] public bool      RandomizeZ = true;
		public                                             Space     TransformSpace;
		[NoObjectFoldout] public                           Transform TransformToMove;

		private void Start()
		{
			if(!TransformToMove)
				TransformToMove = GetComponent<Transform>();

			if(!RandomizeAtStart)
				return;

			RotateAngle = new Vector3
			{
					x = RandomizeX? Random.Range(RotateAngle.x, RotateAngleMax.x) : RotateAngle.x,
					y = RandomizeY? Random.Range(RotateAngle.y, RotateAngleMax.y) : RotateAngle.y,
					z = RandomizeZ? Random.Range(RotateAngle.z, RotateAngleMax.z) : RotateAngle.z
			};
		}

		private void Reset()
		{
			TransformToMove = transform;
		}

		public void Update()
		{
			TransformToMove.Rotate(RotateAngle * Time.deltaTime, TransformSpace);
		}
	}
}
