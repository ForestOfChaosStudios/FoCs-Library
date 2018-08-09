using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaosLib.AdvVar.RuntimeRef.Editor
{
	[CustomPropertyDrawer(typeof(RunTimeList), true)]
	public class RuntimeListPropertyDrawer: ObjectReferenceDrawer
	{
		protected override bool AllowFoldout => false;
	}
}