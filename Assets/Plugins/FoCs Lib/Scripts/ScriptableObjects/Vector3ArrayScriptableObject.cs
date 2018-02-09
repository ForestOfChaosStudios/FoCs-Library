using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Vector3 Array", menuName = ATTRIBUTE_PATH + "Vector 3 Array", order = 0)]
	public class Vector3ArrayScriptableObject: ArrayScriptableObject<Vector3>
	{ }
}