using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Vector2 Array", menuName = ATTRIBUTE_PATH + "Vector 2 Array", order = 0)]
	public class Vector2ArrayScriptableObject: ArrayScriptableObject<Vector2>
	{ }
}