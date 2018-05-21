using UnityEngine.SceneManagement;

namespace ForestOfChaosLib.Components
{
	public class SimpleSceneLoader: FoCsBehavior
	{
		public static void LoadSceneAsync(int s)
		{
			SceneManager.LoadSceneAsync(s);
		}

		public static void LoadSceneAsync(string s)
		{
			SceneManager.LoadSceneAsync(s);
		}

		public static void LoadScene(int s)
		{
			SceneManager.LoadScene(s);
		}

		public static void LoadScene(string s)
		{
			SceneManager.LoadScene(s);
		}

		public static void LoadSceneAsync(int s, LoadSceneMode mode)
		{
			SceneManager.LoadSceneAsync(s, mode);
		}

		public static void LoadSceneAsync(string s, LoadSceneMode mode)
		{
			SceneManager.LoadSceneAsync(s, mode);
		}

		public static void LoadScene(int s, LoadSceneMode mode)
		{
			SceneManager.LoadScene(s, mode);
		}

		public static void LoadScene(string s, LoadSceneMode mode)
		{
			SceneManager.LoadScene(s, mode);
		}
	}
}