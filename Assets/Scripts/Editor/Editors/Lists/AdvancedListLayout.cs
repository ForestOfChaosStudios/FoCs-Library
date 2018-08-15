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
			public IAdvancedListLayoutable Listable;
			public ListOptions             Options;
			public ListDrawingCallbacks    DrawingCallbacks;
			public AnimBool                IsExpandingAnimBool;
			public bool                    IsAnimating => IsExpandingAnimBool.isAnimating;
			public AdvancedListLayout(SerializedProperty property): this(property, ListOptions.Default, ListDrawingCallbacks.Default) { }
			public AdvancedListLayout(SerializedProperty property, ListOptions          options): this(property, options, ListDrawingCallbacks.Default) { }
			public AdvancedListLayout(SerializedProperty property, ListDrawingCallbacks drawingCallbacks): this(property, ListOptions.Default, drawingCallbacks) { }

			public AdvancedListLayout(SerializedProperty property, ListOptions options, ListDrawingCallbacks drawingCallbacks)
			{
				Options             = options;
				Listable            = new SerializedPropertyInternals(property);
				DrawingCallbacks    = drawingCallbacks;
				IsExpandingAnimBool = new AnimBool(Listable.IsExpanded) {speed = ANIMBOOL_ANIMATION_SPEED};
			}

			private DragData CurrentDrag;

			public void Draw()
			{
				InternalDraw(this);
			}

			private RectSizes CurrentSizes;

			private static void InternalDraw(AdvancedListLayout list)
			{
				list.IsExpandingAnimBool.target = list.Listable.IsExpanded;

				using(Disposables.IndentOnlyIfLessThenIndent(1))
				{
					var headerHeight = list.DrawingCallbacks.HeaderHeight(list);
					var headerRect   = EditorGUILayout.GetControlRect(true, headerHeight);

					if(list.Options.DisplayHeader)
						list.DrawingCallbacks.DrawHeader(headerRect, list);

					if(list.IsExpandingAnimBool.isAnimating || list.Listable.IsExpanded)
					{
						using(var fade = Disposables.FadeGroupScope(list.IsExpandingAnimBool.faded))
						{
							list.CurrentSizes = RectSizes.Get(headerRect, list);

							if(fade.visible)
							{
								using(Disposables.VerticalScope())
									list.DrawElements(list.CurrentSizes);

								if(list.Options.DisplayFooter)
									list.DrawingCallbacks.DrawFooter(list.CurrentSizes.Footer, list);
							}
						}
					}
				}
			}

			private string GetHeaderText()
			{
				if(Listable.DisplayName.Length >= 20)
					return $"{Listable.DisplayName}[{Listable.Length}]";

				if(Listable.DisplayName.Length >= 10)
					return $"{Listable.DisplayName}\t[{Listable.Length}]";

				return $"{Listable.DisplayName}\t\t[{Listable.Length}]";
			}

			private void DrawElements(RectSizes sizes)
			{
				if(Listable.Length == 0)
					DrawingCallbacks.DrawEmptyElement(sizes.Elements[0]);
				else
				{
					for(var i = 0; i < sizes.Elements.Length; i++)
						DrawFullElement(sizes.Elements[i], i);
				}
			}

			private void DrawFullElement(Rect pos, int index)
			{
				if(Options.Reorderable)
				{
					if(CurrentDrag.index == index)
					{
						Debug.Log("Before: " + pos);
						pos = pos.Edit(RectEdit.AddX(8), RectEdit.AddY(CurrentDrag.MouseDelta.y));
						Debug.Log("After: " + pos);
						IsExpandingAnimBool.valueChanged.Invoke();
					}

					ListStyles.ElementBackground.DrawChecked(pos);
					DoDrawHandle(pos.Edit(RectEdit.SetWidth(DRAG_HANDLE_WIDTH), RectEdit.SetX(16 * EditorGUI.indentLevel)));

					if(Event.current.type == EventType.MouseDown && CurrentDrag.index != index)
						if(pos.Contains(DragData.CurrentPosition))
							CurrentDrag = DragData.Now(index);

					if(Event.current.type == EventType.MouseUp && CurrentDrag.index == index)
						CurrentDrag.index = -1;

					Listable.DoDrawAtIndex(pos.Edit(RectEdit.ChangeX(DRAG_HANDLE_WIDTH)), index, this);
				}
				else
				{
					ListStyles.ElementBackground.DrawChecked(pos);
					Listable.DoDrawAtIndex(pos, index, this);
				}
			}

			private static void DoDrawHandle(Rect pos)
			{
				ListStyles.HandleBackground.DrawChecked(pos);
				ListStyles.Handle.DrawChecked(pos.Edit(RectEdit.AddY(6)));
			}

			public float GetTotalHeight()
			{
				var retVal = TotalHeaderCalc();

				if(!Listable.IsExpanded)
					return retVal;

				retVal += TotalElementCalc();
				retVal += TotalFooterCalc();

				return retVal;
			}

			protected float TotalHeaderCalc()
			{
				if(Options.DisplayHeader)
					return DrawingCallbacks.HeaderHeight(this);

				return 0;
			}

			protected float TotalElementCalc()
			{
				var retVal = 0f;

				if(Listable.Length == 0)
					retVal += DrawingCallbacks.EmptyHeight();
				else
				{
					for(var i = 0; i < Listable.Length; i++)
						retVal += Listable.GetHeightAtIndex(i, this);
				}

				return retVal;
			}

			protected float TotalFooterCalc()
			{
				if(Options.DisplayFooter)
					return DrawingCallbacks.FooterHeight(this);

				return 0;
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

			public class ListDrawingCallbacks
			{
				public delegate float HeightDelegate();

				public delegate void DrawDelegate(Rect pos);

				public delegate float HeightDelegateWithList(AdvancedListLayout list);

				public delegate void DrawDelegateWithList(Rect pos, AdvancedListLayout list);

				public readonly HeightDelegateWithList HeaderHeight;
				public readonly DrawDelegateWithList   DrawHeader;
				public readonly HeightDelegate         EmptyHeight;
				public readonly DrawDelegate           DrawEmptyElement;
				public readonly HeightDelegateWithList FooterHeight;
				public readonly DrawDelegateWithList   DrawFooter;

				public ListDrawingCallbacks()
				{
					DrawHeader       = InternalDrawHeader;
					DrawFooter       = InternalDrawFooter;
					HeaderHeight     = InternalHeaderHeight;
					FooterHeight     = InternalFooterHeight;
					EmptyHeight      = InternalEmptyHeight;
					DrawEmptyElement = InternalDrawEmptyElement;
				}

				public static ListDrawingCallbacks Default => new ListDrawingCallbacks();

				private static void InternalDrawHeader(Rect pos, AdvancedListLayout list)
				{
					ListStyles.HeaderBackground.DrawChecked(pos);
					list.IsExpandingAnimBool.target = list.Listable.IsExpanded = FoCsGUI.Foldout(pos, list.Listable.IsExpanded, list.GetHeaderText());
				}

				private static void InternalDrawFooter(Rect pos, AdvancedListLayout list)
				{
					ListStyles.FooterBackground.DrawChecked(pos);
					FoCsGUI.Label(pos, "Footer");
				}

				private static float InternalHeaderHeight(AdvancedListLayout list) => FoCsGUI.SingleLine;
				private static float InternalFooterHeight(AdvancedListLayout list) => FoCsGUI.SingleLine;
				private static float InternalEmptyHeight() => FoCsGUI.SingleLine;
				private static void InternalDrawEmptyElement(Rect pos) => FoCsGUI.Label(pos, "List/Array is empty.");
			}

			private struct RectSizes
			{
				public Rect   WholeRect;
				public Rect   Header;
				public Rect[] Elements;
				public Rect   Footer;

				public static RectSizes Get(Rect header, AdvancedListLayout list)
				{
					var retVal = new RectSizes();
					retVal.WholeRect = EditorGUILayout.GetControlRect(true, list.TotalElementCalc() + list.TotalFooterCalc());
					retVal.Header    = header;
					retVal.Elements  = new Rect[Mathf.Max(list.Listable.Length, 1)];
					var tempRect = retVal.WholeRect.Edit(RectEdit.SubtractY(2));

					if(list.Listable.Length == 0)
					{
						var eleHeight = list.DrawingCallbacks.EmptyHeight();
						retVal.Elements[0] = tempRect.Edit(RectEdit.SetHeight(eleHeight));
						tempRect           = tempRect.Edit(RectEdit.AddY(eleHeight), RectEdit.SubtractHeight(eleHeight));
					}
					else
					{
						for(var i = 0; i < list.Listable.Length; i++)
						{
							var eleHeight = list.Listable.GetHeightAtIndex(i, list);
							retVal.Elements[i] = tempRect.Edit(RectEdit.SetHeight(eleHeight));
							tempRect           = tempRect.Edit(RectEdit.AddY(eleHeight), RectEdit.SubtractHeight(eleHeight));
						}
					}

					retVal.Footer = tempRect.Edit(RectEdit.SetHeight(list.DrawingCallbacks.FooterHeight(list)));

					return retVal;
				}
			}

			public class SerializedPropertyInternals: IAdvancedListLayoutable
			{
				private SerializedProperty property;

				public int Length
				{
					get { return property.arraySize; }
					set { property.arraySize = value; }
				}

				public bool IsExpanded
				{
					get { return property.isExpanded; }
					set { property.isExpanded = value; }
				}

				public string DisplayName => property.displayName;
				public void DoDrawAtIndex(Rect    pos,   int                index, AdvancedListLayout list) => FoCsGUI.PropertyField(pos, property.GetArrayElementAtIndex(index));
				public float GetHeightAtIndex(int index, AdvancedListLayout list) => FoCsGUI.GetPropertyHeight(property.GetArrayElementAtIndex(index));

				public SerializedPropertyInternals(SerializedProperty property)
				{
					this.property = property;
				}
			}

			public interface IAdvancedListLayoutable
			{
				int    Length      { get; set; }
				bool   IsExpanded  { get; set; }
				string DisplayName { get; }
				void DoDrawAtIndex(Rect    pos,   int                index, AdvancedListLayout list);
				float GetHeightAtIndex(int index, AdvancedListLayout list);
			}

			private struct DragData
			{
				public        int     index;
				public        Vector2 StartPosition;
				public static Vector2 CurrentPosition => Event.current.mousePosition;
				public        Vector2 MouseDelta      => CurrentPosition - StartPosition;

				public static DragData Now(int index)
				{
					Debug.Log("Now");

					return new DragData {index = index, StartPosition = CurrentPosition};
				}
			}
		}
	}
}
