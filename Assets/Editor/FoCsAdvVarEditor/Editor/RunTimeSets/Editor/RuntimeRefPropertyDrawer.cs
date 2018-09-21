using ForestOfChaosAdvVar.RuntimeRef;
using ForestOfChaosLibrary.Editor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaosAdvVar.Editor.RuntimeRef
{
	[CustomPropertyDrawer(typeof(RunTimeRef), true)]
	public class RuntimeRefPropertyDrawer: ObjectReferenceDrawer
	{
		protected override bool AllowFoldout => false;
	}
}
