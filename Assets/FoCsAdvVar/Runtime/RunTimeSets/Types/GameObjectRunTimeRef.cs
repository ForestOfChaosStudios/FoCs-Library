using System;
using UnityEngine;

namespace ForestOfChaosAdvVar.RuntimeRef
{
	[Serializable]
	[AdvFolderNameRunTime]
	public class GameObjectRunTimeRef: RunTimeRef<GameObject>
	{
		/// <inheritdoc />
		public override void FillReference(MonoBehaviour self)
		{
			Reference = self.gameObject;
		}
	}
}
