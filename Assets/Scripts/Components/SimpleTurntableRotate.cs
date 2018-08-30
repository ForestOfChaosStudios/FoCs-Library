using UnityEngine;

namespace ForestOfChaosLib.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Simple Turntable Rotate")]
	public class SimpleTurntableRotate: FoCsBehaviour
	{
		public Vector3   rotateAngle;
		public Space     transformSpace;
		public Transform transformToMove;

		private void Start()
		{
			if(!transformToMove)
				transformToMove = GetComponent<Transform>();
		}

		private void Reset()
		{
			transformToMove = transform;
		}

		public void Update()
		{
			transformToMove.Rotate(rotateAngle * Time.deltaTime, transformSpace);
		}
	}
}
