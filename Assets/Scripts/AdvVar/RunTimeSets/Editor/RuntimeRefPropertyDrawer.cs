using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaosLib.AdvVar.RuntimeRef.Editor
{
	[CustomPropertyDrawer(typeof(RunTimeRef), true)]
	public class RuntimeRefPropertyDrawer: ObjectReferenceDrawer
	{
		protected override bool AllowFoldout => false;
	}
}
