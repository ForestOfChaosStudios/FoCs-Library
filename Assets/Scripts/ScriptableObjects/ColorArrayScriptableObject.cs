using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Color Array", menuName = ATTRIBUTE_PATH + "Color Array", order = 0)]
	public class ColorArrayScriptableObject: ArrayScriptableObject<Color>
	{ }
}