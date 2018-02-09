using ForestOfChaosLib.ScriptableObjects.Generic;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Colour Array", menuName = ATTRIBUTE_PATH + "Colour Array", order = 0)]
	public class ColourArrayScriptableObject: ArrayScriptableObject<Colour>
	{ }
}