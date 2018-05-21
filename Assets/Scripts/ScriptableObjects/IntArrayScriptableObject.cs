using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Int Array", menuName = ATTRIBUTE_PATH + "Int Array", order = 0)]
	public class IntArrayScriptableObject: ArrayScriptableObject<int>
	{ }
}