using UnityEditor;

namespace ForestOfChaosLibrary.Editor
{
	public interface IPropertyLayoutHandler
	{
		void HandleProperty(SerializedProperty  property);
		float PropertyHeight(SerializedProperty property);
		bool IsValidProperty(SerializedProperty property);
		void DrawAfterEditor(SerializedProperty serializedProperty);
	}
}
