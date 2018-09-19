using ForestOfChaosAdvVar.RuntimeRef;
using ForestOfChaosLibraryEditor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaosAdvVarEditor.RuntimeRef
{
	[CustomPropertyDrawer(typeof(RunTimeList), true)]
	public class RuntimeListPropertyDrawer: ObjectReferenceDrawer
	{
		protected override bool AllowFoldout => false;
	}
}
