using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestOfChaosLib.Components
{
	public class SimpleTimedScene: FoCsBehavior
	{
		public int   levelNum;
		public float timeLoad = 10;
		public void  Start() { StartCoroutine(LevelLoad()); }

		private IEnumerator LevelLoad()
		{
			var waiter = new WaitForSeconds(timeLoad);

			yield return waiter;
			SceneManager.LoadScene(levelNum);
		}
	}
}