using ForestOfChaosAdvVar.RuntimeRef;
using ForestOfChaosLibrary.Editor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaosAdvVar.Editor.RuntimeRef
{
	[CustomPropertyDrawer(typeof(RunTimeList), true)]
	public class RuntimeListPropertyDrawer: ObjectReferenceDrawer
	{
		protected override bool AllowFoldout => false;
	}
}
