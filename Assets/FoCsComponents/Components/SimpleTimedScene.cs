#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SimpleTimedScene.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Simple Timed Scene")]
    public class SimpleTimedScene: FoCsBehaviour {
        public int   levelNum;
        public float timeLoad = 10;

        public void Start() {
            StartCoroutine(LevelLoad());
        }

        private IEnumerator LevelLoad() {
            var waiter = new WaitForSeconds(timeLoad);

            yield return waiter;

            SceneManager.LoadScene(levelNum);
        }
    }
}