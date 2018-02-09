using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "GameObject Array", menuName = ATTRIBUTE_PATH + "GameObject Array", order = 0)]
	public class GameObjectArrayScriptable: ArrayScriptableObject<GameObject>
	{ }
}