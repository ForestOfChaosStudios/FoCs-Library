using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Vector4 Array", menuName = ATTRIBUTE_PATH + "Vector 4 Array", order = 0)]
	public class Vector4ArrayScriptableObject: ArrayScriptableObject<Vector4>
	{ }
}