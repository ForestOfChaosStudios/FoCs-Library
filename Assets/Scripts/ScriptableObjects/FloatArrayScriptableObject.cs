using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Float Array", menuName = ATTRIBUTE_PATH + "Float Array", order = 0)]
	public class FloatArrayScriptableObject: ArrayScriptableObject<float>
	{ }
}