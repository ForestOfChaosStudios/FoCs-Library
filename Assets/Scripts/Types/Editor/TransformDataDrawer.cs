using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Types;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Editor
{
	[CustomPropertyDrawer(typeof(TransformData))]
	public class TransformDataDrawer: FoCsPropertyDrawer<TransformData>
	{
		private static readonly GUIContent CopyContent  = new GUIContent("Copy",  "Copies a new TransformData");
		private static readonly GUIContent PasteContent = new GUIContent("Paste", "Pastes the TransformData");
		private static readonly GUIContent ResetContent = new GUIContent("Reset", "Resets the TransformData to TransformData.Empty");

		/// <inheritdoc />
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var prop = Disposables.PropertyScope(position, label, property))
			{
				var owner = GetOwner(property);
				FoCsGUI.Label(position.Edit(RectEdit.SetHeight(SingleLine)), prop.content);
				DoDragDrop(position.Edit(RectEdit.MultiplyWidth(0.5f)), property);

				using(Disposables.Indent())
				{
					var Position = property.FindPropertyRelative("Position");
					var Rotation = property.FindPropertyRelative("Rotation");
					var Scale    = property.FindPropertyRelative("Scale");

					using(var horizontalScope = Disposables.RectHorizontalScope(5, position.Edit(RectEdit.SetHeight(SingleLine - 2), RectEdit.DivideWidth(2), RectEdit.AddX(position.width * 0.5f))))
					{
						var                  copyBtn = FoCsGUI.Button(horizontalScope.GetNext(2), CopyContent);
						var                  isType  = CopyPasteUtility.IsTypeInBuffer(owner);
						FoCsGUI.GUIEventBool pasteBtn;

						using(Disposables.ColorChanger(isType? GUI.color : Color.red))
							pasteBtn = FoCsGUI.Button(horizontalScope.GetNext(2), PasteContent);

						var resetBtn = FoCsGUI.Button(horizontalScope.GetNext(1), ResetContent);

						if(copyBtn)
							CopyPasteUtility.Copy(GetOwner(property));
						else if(pasteBtn)
						{
							var tD = CopyPasteUtility.Paste<TransformData>();
							Undo.RecordObject(property.serializedObject.targetObject, "Paste TD");
							Position.vector3Value    = tD.Position;
							Scale.vector3Value       = tD.Scale;
							Rotation.quaternionValue = tD.Rotation;
						}
						else if(resetBtn)
						{
							Undo.RecordObject(property.serializedObject.targetObject, "Reset TD");
							var tD = TransformData.Empty;
							Position.vector3Value    = tD.Position;
							Scale.vector3Value       = tD.Scale;
							Rotation.quaternionValue = tD.Rotation;
						}
					}

					using(var vertScope = Disposables.RectVerticalScope(3, position.Edit(RectEdit.SetHeight(SingleLine * 3), RectEdit.AddY(SingleLine))))
					{
						FoCsGUI.PropertyField(vertScope.GetNext(), Position);
						FoCsGUI.PropertyField(vertScope.GetNext(), Rotation);
						FoCsGUI.PropertyField(vertScope.GetNext(), Scale);
					}
				}
			}
		}

		private void DoDragDrop(Rect pos, SerializedProperty property)
		{
			if(DragAndDrop.objectReferences.IsNullOrEmpty())
				return;

			pos = pos.Edit(RectEdit.SetHeight(SingleLine));
			var @event    = Event.current;
			var obj       = DragAndDrop.objectReferences[0];
			var go        = obj as GameObject;
			var transform = obj as Transform;
			var component = obj as Component;

			if(@event.type == EventType.Repaint)
			{
				if(go || transform || component)
				{
					using(Disposables.ColorChanger(Color.green))
						FoCsGUI.Styles.Unity.Box.Draw(pos, false, false, false, false);
				}
				else
				{
					using(Disposables.ColorChanger(Color.red))
						FoCsGUI.Styles.Unity.Box.Draw(pos, false, false, false, false);
				}
			}

			if(pos.Contains(@event.mousePosition))
			{
				if((@event.type == EventType.DragUpdated) || (@event.type == EventType.DragPerform))
				{
					DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

					if(@event.type == EventType.DragPerform)
					{
						if(DragAndDrop.objectReferences.IsNullOrEmpty())
							return;

						var tD = TransformData.Empty;

						if(go)
							tD = new TransformData(go);
						else if(transform)
							tD = new TransformData(transform);
						else if(component)
							tD = new TransformData(component);
						else
							return;

						var Position = property.FindPropertyRelative("Position");
						var Rotation = property.FindPropertyRelative("Rotation");
						var Scale    = property.FindPropertyRelative("Scale");
						Position.vector3Value    = tD.Position;
						Scale.vector3Value       = tD.Scale;
						Rotation.quaternionValue = tD.Rotation;
						property.serializedObject.ApplyModifiedProperties();
						DragAndDrop.AcceptDrag();
					}

					@event.Use();
				}
			}
		}

		/// <inheritdoc />
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return SingleLine * 4;
		}
	}
}
