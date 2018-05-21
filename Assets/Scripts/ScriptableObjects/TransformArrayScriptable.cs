using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Transform Array", menuName = ATTRIBUTE_PATH + "Transform Array", order = 0)]
	public class TransformArrayScriptable: ArrayScriptableObject<Transform>
	{ }
}