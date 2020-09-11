#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SimpleSceneLoader.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestOfChaosLibrary.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Simple Scene Loader")]
    public class SimpleSceneLoader: FoCsBehaviour {
        public void LoadSceneAsync(int s) {
            SceneManager.LoadSceneAsync(s);
        }

        public void LoadSceneAsync(string s) {
            SceneManager.LoadSceneAsync(s);
        }

        public void LoadScene(int s) {
            SceneManager.LoadScene(s);
        }

        public void LoadScene(string s) {
            SceneManager.LoadScene(s);
        }

        public void LoadSceneAsync(int s, LoadSceneMode mode) {
            SceneManager.LoadSceneAsync(s, mode);
        }

        public void LoadSceneAsync(string s, LoadSceneMode mode) {
            SceneManager.LoadSceneAsync(s, mode);
        }

        public void LoadScene(int s, LoadSceneMode mode) {
            SceneManager.LoadScene(s, mode);
        }

        public void LoadScene(string s, LoadSceneMode mode) {
            SceneManager.LoadScene(s, mode);
        }
    }
}