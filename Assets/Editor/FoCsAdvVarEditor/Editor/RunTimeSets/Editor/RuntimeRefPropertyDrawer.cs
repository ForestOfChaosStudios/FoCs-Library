using ForestOfChaosAdvVar.RuntimeRef;
using ForestOfChaosLibraryEditor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaosAdvVarEditor.RuntimeRef
{
	[CustomPropertyDrawer(typeof(RunTimeRef), true)]
	public class RuntimeRefPropertyDrawer: ObjectReferenceDrawer
	{
		protected override bool AllowFoldout => false;
	}
}
