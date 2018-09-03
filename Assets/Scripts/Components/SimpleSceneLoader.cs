using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestOfChaosLib.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Simple Scene Loader")]
	public class SimpleSceneLoader: FoCsBehaviour
	{
		public void LoadSceneAsync(int s)
		{
			SceneManager.LoadSceneAsync(s);
		}

		public void LoadSceneAsync(string s)
		{
			SceneManager.LoadSceneAsync(s);
		}

		public void LoadScene(int s)
		{
			SceneManager.LoadScene(s);
		}

		public void LoadScene(string s)
		{
			SceneManager.LoadScene(s);
		}

		public void LoadSceneAsync(int s, LoadSceneMode mode)
		{
			SceneManager.LoadSceneAsync(s, mode);
		}

		public void LoadSceneAsync(string s, LoadSceneMode mode)
		{
			SceneManager.LoadSceneAsync(s, mode);
		}

		public void LoadScene(int s, LoadSceneMode mode)
		{
			SceneManager.LoadScene(s, mode);
		}

		public void LoadScene(string s, LoadSceneMode mode)
		{
			SceneManager.LoadScene(s, mode);
		}
	}
}
