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

		/// <inheritdoc />
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var prop = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				var owner = GetOwner(property);
				FoCsGUI.Label(position.Edit(RectEdit.SetHeight(SingleLine)), prop.content);

				using(FoCsEditor.Disposables.Indent())
				{
					var Position = property.FindPropertyRelative("Position");
					var Scale    = property.FindPropertyRelative("Scale");
					var Rotation = property.FindPropertyRelative("Rotation");

					using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, position.Edit(RectEdit.SetHeight(SingleLine - 2), RectEdit.DivideWidth(2), RectEdit.AddX(position.width * 0.5f))))
					{
						var                  copyBtn = FoCsGUI.Button(horizontalScope.GetNext(), CopyContent);
						var                  isType  = CopyPasteUtility.IsTypeInBuffer(owner);
						FoCsGUI.GUIEventBool pasteBtn;

						using(FoCsEditor.Disposables.ColorChanger(isType? GUI.color : Color.red))
						{
							pasteBtn = FoCsGUI.Button(horizontalScope.GetNext(), PasteContent);
						}

						if(copyBtn)
						{
							CopyPasteUtility.Copy(GetOwner(property));
						}
						else if(pasteBtn)
						{
							var tD = CopyPasteUtility.Paste<TransformData>();
							Position.vector3Value    = tD.Position;
							Scale.vector3Value       = tD.Scale;
							Rotation.quaternionValue = tD.Rotation;
						}
					}

					using(var vertScope = FoCsEditor.Disposables.RectVerticalScope(3, position.Edit(RectEdit.SetHeight(SingleLine * 3), RectEdit.AddY(SingleLine))))
					{
						FoCsGUI.PropertyField(vertScope.GetNext(), Position);
						FoCsGUI.PropertyField(vertScope.GetNext(), Scale);
						FoCsGUI.PropertyField(vertScope.GetNext(), Rotation);
					}
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