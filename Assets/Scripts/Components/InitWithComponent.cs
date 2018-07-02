using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class InitWithComponent<T> where T: Component
	{
		public GameObject gameObject;
		public T          ScriptComponent;

		public InitWithComponent(string name)
		{
			gameObject      = new GameObject(name);
			ScriptComponent = gameObject.AddComponent<T>();
		}

		public static implicit operator T(InitWithComponent<T>          fp) => fp.ScriptComponent;
		public static implicit operator GameObject(InitWithComponent<T> fp) => fp.gameObject;
	}
}