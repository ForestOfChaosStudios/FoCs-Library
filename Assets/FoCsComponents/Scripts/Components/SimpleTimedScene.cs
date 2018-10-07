using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestOfChaosLibrary.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Simple Timed Scene")]
	public class SimpleTimedScene: FoCsBehaviour
	{
		public int   levelNum;
		public float timeLoad = 10;

		public void Start()
		{
			StartCoroutine(LevelLoad());
		}

		private IEnumerator LevelLoad()
		{
			var waiter = new WaitForSeconds(timeLoad);

			yield return waiter;

			SceneManager.LoadScene(levelNum);
		}
	}
}
