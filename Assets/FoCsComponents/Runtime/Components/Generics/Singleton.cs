using System;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaosLibrary.Generics
{
	[Serializable]
	public class Singleton<S>: FoCsBehaviour where S: FoCsBehaviour
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

				if(instance)
					return instance;

				if(Application.isPlaying)
					CreateInstance();
				else
					Debug.LogError($"Unable to create: {typeof(S)}. One Should be added to scene."); //Print error

				return instance;
			}
		}

		public static bool InstanceNull => Instance == null;

		public static GameObject CreateInstance()
		{
			var go = new GameObject($"{typeof(S)} Instance", typeof(S));
			go.transform.ResetLocalPosRotScale();

			return go;
		}

		public static GameObject CreateInstance(string name)
		{
			var go = new GameObject(name, typeof(S));
			go.transform.ResetLocalPosRotScale();

			return go;
		}

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
