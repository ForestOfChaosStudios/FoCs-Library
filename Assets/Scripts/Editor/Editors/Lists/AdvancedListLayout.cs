using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		public class AdvancedListLayout
		{
			private const float DRAG_HANDLE_WIDTH        = 12f;
			private const float ANIMBOOL_ANIMATION_SPEED = 1f;

			//TODO: change from requiring a Serialized property to most likely an interface based design
			public SerializedProperty   Property;
			public ListOptions          Options;
			public ListDrawingCallbacks DrawingCallbacks;
			public AnimBool             IsExpandingAnimBool;
			public bool                 IsAnimating => IsExpandingAnimBool.isAnimating;
			public AdvancedListLayout(SerializedProperty property): this(property, ListOptions.Default) { }
			public AdvancedListLayout(SerializedProperty property, ListOptions          options): this(property, options, ListDrawingCallbacks.Default) { }
			public AdvancedListLayout(SerializedProperty property, ListDrawingCallbacks drawingCallbacks): this(property, ListOptions.Default, drawingCallbacks) { }

			public AdvancedListLayout(SerializedProperty property, ListOptions options, ListDrawingCallbacks drawingCallbacks)
			{
				Options             = options;
				Property            = property;
				DrawingCallbacks    = drawingCallbacks;
				IsExpandingAnimBool = new AnimBool(Property.isExpanded) {speed = ANIMBOOL_ANIMATION_SPEED};
			}

			private static void InternalDraw(AdvancedListLayout list, bool isExpanded)
			{
				list.IsExpandingAnimBool.target = list.Property.isExpanded;

				using(Disposables.VerticalScope())
				{
					using(Disposables.IndentOnlyIfLessThenIndent(1))
					{
						if(list.Options.DisplayHeader && list.IsExpandingAnimBool.isAnimating)
							list.DrawHeader();

						using(var fade = Disposables.FadeGroupScope(list.IsExpandingAnimBool.faded))
						{
							if(fade.visible)
							{
								if(list.Options.DisplayHeader && !list.IsExpandingAnimBool.isAnimating)
									list.DrawHeader();

								using(Disposables.VerticalScope())
									list.DrawElements();

								if(list.Options.DisplayFooter)
									list.DrawFooter();
							}
							else
							{
								if(list.Options.DisplayHeader && !list.IsExpandingAnimBool.isAnimating)
									list.DrawHeader();
							}
						}
					}
				}
			}

			public void Draw()
			{
				InternalDraw(this, Property.isExpanded);
			}

			public void Draw(bool forceOpen)
			{
				InternalDraw(this, forceOpen);
			}

			public void DrawHeader()
			{
				using(Disposables.HorizontalScope(ListStyles.HeaderBackground))
					IsExpandingAnimBool.target = Property.isExpanded = FoCsGUI.Layout.Foldout(Property.isExpanded, GetHeaderText());
			}

			public void DrawElements()
			{
				using(Disposables.VerticalScope())
				{
					if(Property.arraySize == 0)
					{
						var pos = FoCsGUI.Layout.GetControlRect(true, DrawingCallbacks.EmptyHeight());
						DrawingCallbacks.DrawEmptyElement(pos);
					}
					else
					{
						for(var i = 0; i < Property.arraySize; i++)
						{
							var element = Property.GetArrayElementAtIndex(i);
							var pos     = FoCsGUI.Layout.GetControlRect(true, DrawingCallbacks.PropertyHeight(i, element));
							DrawFullElement(pos, i, element);
						}
					}
				}
			}

			public void DrawFooter()
			{
				using(Disposables.HorizontalScope(ListStyles.FooterBackground))
					FoCsGUI.Layout.Label("Footer");
			}

			private string GetHeaderText()
			{
				if(Property.displayName.Length >= 20)
					return $"{Property.displayName}[{Property.arraySize}]";

				if(Property.displayName.Length >= 10)
					return $"{Property.displayName}\t[{Property.arraySize}]";

				return $"{Property.displayName}\t\t[{Property.arraySize}]";
			}

			private void DrawFullElement(Rect pos, int i, SerializedProperty element)
			{
				if(Options.Reorderable)
				{
					ListStyles.ElementBackground.DrawChecked(pos);
					DoDrawHandle(pos.Edit(RectEdit.SetWidth(DRAG_HANDLE_WIDTH), RectEdit.SetX(16 * EditorGUI.indentLevel)));
					DrawingCallbacks.DrawElement?.Invoke(pos.Edit(RectEdit.ChangeX(DRAG_HANDLE_WIDTH)), i, element);
				}
				else
					DrawingCallbacks.DrawElement?.Invoke(pos, i, element);
			}

			private static void DoDrawHandle(Rect pos)
			{
				ListStyles.HandleBackground.DrawChecked(pos);
				ListStyles.Handle.DrawChecked(pos.Edit(RectEdit.AddY(6)));
			}

			public float GetTotalHeight()
			{
				var retVal = 0f;

				if(Options.DisplayHeader)
					retVal += FoCsGUI.SingleLine;

				if(Property.arraySize == 0)
					retVal += DrawingCallbacks.EmptyHeight();
				else
				{
					for(var i = 0; i < Property.arraySize; i++)
						retVal += DrawingCallbacks.PropertyHeight(i, Property.GetArrayElementAtIndex(i));
				}

				if(Options.DisplayFooter)
					retVal += FoCsGUI.SingleLine;

				return retVal;
			}

			public class ListStyles
			{
				static ListStyles()
				{
					HeaderBackground            = new GUIStyle(FoCsGUI.Styles.Unity.Box);
					FooterBackground            = new GUIStyle(FoCsGUI.Styles.Unity.Box);

					ElementBackground           = new GUIStyle(FoCsGUI.Styles.Unity.Box);
					HandleBackground            = new GUIStyle(FoCsGUI.Styles.Unity.Box);
					HandleBackground.fixedWidth = DRAG_HANDLE_WIDTH;
					Handle                      = new GUIStyle(UnityReorderableListProperty.ListStyles.DraggingHandle);
					Handle.fixedWidth           = DRAG_HANDLE_WIDTH;
				}

				public static GUIStyle Handle;
				public static GUIStyle HandleBackground;
				public static GUIStyle ElementBackground;
				public static GUIStyle HeaderBackground;
				public static GUIStyle FooterBackground;
			}

			public struct ListOptions
			{
				public bool DisplayHeader;
				public bool DisplayFooter;
				public bool Reorderable;

				public ListOptions(bool displayHeader, bool reorderable, bool displayFooter)
				{
					DisplayHeader = displayHeader;
					Reorderable   = reorderable;
					DisplayFooter = displayFooter;
				}

				public static ListOptions Default => new ListOptions(true, true, true);
			}

			public delegate float PropertyHeightDelegate(int index, SerializedProperty propertyAtIndex);

			public delegate void DrawElementDelegate(Rect pos, int index, SerializedProperty propertyAtIndex);

			public delegate float EmptyHeightDelegate();

			public delegate void DrawEmptyElementDelegate(Rect pos);

			public class ListDrawingCallbacks
			{
				public readonly PropertyHeightDelegate   PropertyHeight;
				public readonly DrawElementDelegate      DrawElement;
				public readonly EmptyHeightDelegate      EmptyHeight;
				public readonly DrawEmptyElementDelegate DrawEmptyElement;

				public ListDrawingCallbacks()
				{
					PropertyHeight   = (index, prop) => FoCsGUI.GetPropertyHeight(prop);
					DrawElement      = (pos,   index, prop) => FoCsGUI.PropertyField(pos, prop);
					EmptyHeight      = () => FoCsGUI.SingleLine;
					DrawEmptyElement = (pos) => FoCsGUI.Label(pos, "List/Array is empty.");
				}

				public static ListDrawingCallbacks Default => new ListDrawingCallbacks();
			}
		}
	}
}
