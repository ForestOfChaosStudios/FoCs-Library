using System;
using UnityEngine;

namespace ForestOfChaosLib.Generics
{
	[Serializable]
	public class SingletonRigidbody<S>: FoCsRigidbodyBehaviour where S: FoCsRigidbodyBehaviour
	{
		protected static S    instance;
		public static    bool instanceNull => instance == null;

		public static S Instance
		{
			get
			{
				if(instance)
					return instance;

				instance = FindObjectOfType<S>();

				if(!instance)
					Debug.LogError(typeof(S) + " is needed in the scene."); //Print error

				return instance;
			}
		}

		public static bool InstanceNull => Instance == null;

		public void DestroyOtherInstances()
		{
			var others = FindObjectsOfType<S>();

			if(others.Length == 1)
				return;

			for(var i = others.Length - 1; i >= 0; i--)
			{
				if(Instance == others[1])
					continue;

				Destroy(others[i]);
			}
		}
	}
}
