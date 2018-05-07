using System;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditorInternal;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		public class ReorderableListProperty
		{
			private static ReorderableList.Defaults s_Defaults;
			private SerializedProperty _property;
			public bool Animate;
			public ListLimiter Limiter;

			/// <summary>
			///     ref http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
			/// </summary>
			public ReorderableList List { get; private set; }

			public AnimBool IsExpanded { get; set; }

			public static ReorderableList.Defaults Defaults => s_Defaults ?? (s_Defaults = new ReorderableList.Defaults());

			public SerializedProperty Property
			{
				get { return _property; }
				set
				{
					_property = value;
					List.serializedProperty = _property;
				}
			}

			public ReorderableListProperty(SerializedProperty property)
			{
				_property = property;
				Animate = false;
				if(Animate)
				{
					IsExpanded = new AnimBool(property.isExpanded)
								 {
									 speed = 1f
								 };
				}
				CreateList();
			}

			public ReorderableListProperty(
					SerializedProperty property,
					bool dragAble,
					bool displayHeader = true,
					bool displayAdd = true,
					bool displayRemove = true,
					bool animate = false)
			{
				_property = property;
				Animate = animate;
				if(Animate)
				{
					IsExpanded = new AnimBool(property.isExpanded)
								 {
									 speed = 1f
								 };
				}
				CreateList(dragAble, displayHeader, displayAdd, displayRemove);
			}

			~ReorderableListProperty()
			{
				_property = null;
				List = null;
			}

			private void CreateList(bool dragAble = true, bool displayHeader = true, bool displayAdd = true, bool displayRemove = true)
			{
				List = new ReorderableList(Property.serializedObject, Property, dragAble, displayHeader, displayAdd, displayRemove);
				List.drawHeaderCallback += OnListDrawHeaderCallback;
				List.onCanRemoveCallback += OnListOnCanRemoveCallback;
				List.drawElementCallback += DrawElement;
				List.elementHeightCallback += OnListElementHeightCallback;
				//TODO Impliment limited view of lists, eg only show index 50-100, and buttons to move limits
				List.drawFooterCallback += OnListDrawFooterCallback;
				List.showDefaultBackground = true;

				CheckLimiter();
			}

			private void CheckLimiter()
			{
				if(List.serializedProperty.arraySize >= ListLimiter.TOTAL_VISIBLE_COUNT)
				{
					if(Limiter == null)
						Limiter = ListLimiter.GetLimiter(this);
				}
				else
					Limiter = null;
			}

			private void DrawElement(Rect rect, int index, bool active, bool focused)
			{
				if(Limiter == null)
					DoDrawElement(rect, index);
				else if(Limiter.ShowElement(index))
					DoDrawElement(rect, index);
			}

			private void DoDrawElement(Rect rect, int index)
			{
				rect.height = Mathf.Max(EditorGUIUtility.singleLineHeight,
										EditorGUI.GetPropertyHeight(_property.GetArrayElementAtIndex(index), _property.GetArrayElementAtIndex(index).isExpanded));

				rect.y += 1;
				var iProp = _property.GetArrayElementAtIndex(index);
				EditorGUI.PropertyField(rect,
										iProp,
										iProp.propertyType == SerializedPropertyType.Generic?
											new GUIContent(iProp.displayName) :
											GUIContent.none,
										true);
			}

			public void HandleDrawing()
			{
				using(FoCsEditor.Disposables.VerticalScope())
				{
					CheckLimiter();
					if(Animate)
					{
						IsExpanded.target = Property.isExpanded;
						if((!IsExpanded.value && !IsExpanded.isAnimating) || (!IsExpanded.value && IsExpanded.isAnimating))
							DrawDefaultHeader();

						else
						{
							if(EditorGUILayout.BeginFadeGroup(IsExpanded.faded))
								List.DoLayoutList();
							EditorGUILayout.EndFadeGroup();
						}
					}
					else
					{
						if(Property.isExpanded)
							List.DoLayoutList();
						else
							DrawDefaultHeader();
					}
				}
			}

			public void HandleDrawing(Rect rect)
			{
				CheckLimiter();
				if(Animate)
				{
					IsExpanded.target = Property.isExpanded;
					if((!IsExpanded.value && !IsExpanded.isAnimating) || (!IsExpanded.value && IsExpanded.isAnimating))
						DrawDefaultHeader(rect);

					else
					{
						if(EditorGUILayout.BeginFadeGroup(IsExpanded.faded))
							List.DoList(rect);
						EditorGUILayout.EndFadeGroup();
					}
				}
				else
				{
					if(Property.isExpanded)
						List.DoList(rect);
					else
						DrawDefaultHeader(rect);
				}
			}

			public void DrawHeader() => DrawDefaultHeader();

			public void DrawHeader(Rect rect) => DrawDefaultHeader(rect);

			private void DrawDefaultHeader()
			{
				DrawDefaultHeader(GUILayoutUtility.GetRect(0.0f, List.headerHeight, GUILayout.ExpandWidth(true)));
			}

			private void DrawDefaultHeader(Rect headerRect)
			{
				Defaults.DrawHeaderBackground(headerRect);
				headerRect.xMin += 6f;
				headerRect.xMax -= 6f;
				headerRect.height -= 2f;
				++headerRect.y;
				List.drawHeaderCallback(headerRect);
			}

			public float GetTotalHeight()
			{
				if(!Property.isExpanded)
					return List.headerHeight + FoCsEditorUtilities.Padding;

				var height = List.headerHeight + List.footerHeight + 4 + FoCsEditorUtilities.Padding;

				if(Property.isExpanded && (List.serializedProperty.arraySize == 0))
					return List.elementHeight + height;

				if(Limiter == null)
				{
					for(var i = 0; i < List.serializedProperty.arraySize; i++)
						height += OnListElementHeightCallback(i);
				}
				else
				{
					for(var i = 0; i < List.serializedProperty.arraySize; i++)
					{
						if(Limiter.ShowElement(i))
							height += OnListElementHeightCallback(i);
					}
				}

				return height;
			}

			public static implicit operator ReorderableListProperty(SerializedProperty input) => new ReorderableListProperty(input);
			public static implicit operator SerializedProperty(ReorderableListProperty input) => input.Property;

			public static class ListStyles
			{
				public static readonly GUIContent IconToolbarPlus = EditorGUIUtility.IconContent("Toolbar Plus", "|Add to list");
				public static readonly GUIContent IconToolbar = EditorGUIUtility.IconContent("Toolbar Plus", "|Add to list");

				public static readonly GUIContent IconToolbarPlusMore = EditorGUIUtility.IconContent("Toolbar Plus More", "Choose to add to list");
				public static readonly GUIContent IconToolbarMinus = EditorGUIUtility.IconContent("Toolbar Minus", "Remove selection from list");

				public static readonly GUIContent UpArrow = new GUIContent(FoCsEditor.Styles.FoCsGUIData.UpArrow, "Increase Displayed Index 5");
				public static readonly GUIContent Up2Arrow = new GUIContent(FoCsEditor.Styles.FoCsGUIData.Up2Arrow, "Increase Displayed Index 10");

				public static readonly GUIContent DownArrow = new GUIContent(FoCsEditor.Styles.FoCsGUIData.DownArrow, "Decrease Displayed Index 5");
				public static readonly GUIContent Down2Arrow = new GUIContent(FoCsEditor.Styles.FoCsGUIData.Down2Arrow, "Decrease Displayed Index 10");

				private static GUIStyle miniLabel;

				public static readonly GUIStyle DraggingHandle = new GUIStyle("RL DragHandle");
				public static readonly GUIStyle HeaderBackground = new GUIStyle("RL Header");
				public static readonly GUIStyle FooterBackground = new GUIStyle("RL Footer");
				public static readonly GUIStyle BoxBackground = new GUIStyle("RL Background");
				public static readonly GUIStyle PreButton = new GUIStyle("RL FooterButton");
				public static readonly GUIStyle ElementBackground = new GUIStyle("RL Element");

				public static GUIStyle MiniLabel
				{
					get
					{
						if(miniLabel != null)
							return miniLabel;
						miniLabel = new GUIStyle(EditorStyles.miniLabel);
						miniLabel.alignment = TextAnchor.UpperCenter;

						return miniLabel;
					}
				}
			}

			public class ListLimiter
			{
				public const int TOTAL_VISIBLE_COUNT = 25;

				private int _max;
				private int _min;
				public ReorderableListProperty MyListProperty;
				private int Count => MyListProperty.Property.arraySize;

				public int Min
				{
					get { return _min; }
					set { _min = Math.Max(0, value); }
				}

				public int Max
				{
					get { return _max; }
					set { _max = Math.Min(Count, value); }
				}

				public bool ShowElement(int index) => (index >= Min) && (index < Max);

				public static ListLimiter GetLimiter(ReorderableListProperty listProperty) => new ListLimiter
																							  {
																								  MyListProperty = listProperty,
																								  _min = 0,
																								  _max = TOTAL_VISIBLE_COUNT
																							  };

				public bool CanDecrease() => _min > 0;

				public bool CanIncrease() => _max < Count;

				public void ChangeRange(int amount)
				{
					var newMin = Min + amount;
					var newMax = newMin + TOTAL_VISIBLE_COUNT;
					if((newMax < Count) && (newMin >= 0))
					{
						Min = Min + amount;
						Max = Min + TOTAL_VISIBLE_COUNT;
						return;
					}

					if(newMax >= Count)
					{
						newMax = Count;
						Min = newMax - TOTAL_VISIBLE_COUNT;
						Max = newMax;
						return;
					}

					Min = Min + amount;
					Max = Min + TOTAL_VISIBLE_COUNT;
				}

				public void ChangeStart()
				{
					Min = 0;
					Max = Min + TOTAL_VISIBLE_COUNT;
				}

				public void ChangeEnd()
				{
					Max = Count;
					Min = Max - TOTAL_VISIBLE_COUNT;
				}
			}

			#region DelegateMethods
			private float OnListElementHeightCallback(int index)
			{
				if(Limiter == null)
				{
					var prop = _property.GetArrayElementAtIndex(index);
					return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(prop, prop.isExpanded)) + 4.0f;
				}
				if(Limiter.ShowElement(index))
				{
					var prop = _property.GetArrayElementAtIndex(index);
					return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(prop, prop.isExpanded)) + 4.0f;
				}
				return 0;
			}

			private bool OnListOnCanRemoveCallback(ReorderableList list) => List.count > 0;

			private void OnListDrawHeaderCallback(Rect rect)
			{

				var xMax = rect.xMax;
				var x = xMax - 8f;
				if(List.displayAdd)
					x -= 25f;
				if(List.displayRemove)
					x -= 25f;


				using(FoCsEditor.Disposables.IndentSet(0))
				{
					_property.isExpanded = EditorGUI.ToggleLeft(rect.SetWidth(x - 10),
																$"{_property.displayName}\t[{_property.arraySize}]",
																_property.isExpanded,
																_property.prefabOverride?
																	EditorStyles.boldLabel :
																	GUIStyle.none);
				}

				using(FoCsEditor.Disposables.DisabledScope(!_property.isExpanded))
				{
					var rect2 = new Rect(x, rect.y, xMax - x, rect.height);

					var addButtonRect = new Rect(xMax - 29f - 25f, rect2.y - 3f, 25f, 13f);

					var removeButtonRect = new Rect(xMax - 29f, rect2.y - 3f, 25f, 13f);

					if(List.displayAdd)
					{
						FooterAddGUI(addButtonRect.MoveY(3));
					}
					if(List.displayRemove)
					{
						FooterRemoveGUI(removeButtonRect.MoveY(3));
					}
				}
			}

			private void OnListDrawFooterCallback(Rect rowRect)
			{
				var xMax = rowRect.xMax;
				var x = xMax - 8f;
				if(List.displayAdd)
					x -= 25f;
				if(List.displayRemove)
					x -= 25f;

				if(Limiter != null)
					x -= 25f * 6;
				var rect = new Rect(x, rowRect.y, xMax - x, rowRect.height);

				var addButtonRect = new Rect(xMax - 29f - 25f, rect.y - 3f, 25f, 13f);

				var removeButtonRect = new Rect(xMax - 29f, rect.y - 3f, 25f, 13f);
				if(Event.current.type == EventType.Repaint)
					ListStyles.FooterBackground.Draw(rect, false, false, false, false);

				if(Limiter != null)
				{
					FooterLimiterGUI(rect);
				}

				if(List.displayAdd)
				{
					FooterAddGUI(addButtonRect);
				}
				if(List.displayRemove)
				{
					FooterRemoveGUI(removeButtonRect);
				}
			}

			private void FooterLimiterGUI(Rect rect)
			{
				var horScope = FoCsEditor.Disposables.RectHorizontalScope(11, rect.ChangeX(5).MoveWidth(-16));
				using(FoCsEditor.Disposables.DisabledScope(!Limiter.CanDecrease()))
				{
					if(FoCsGUI.Button(horScope.GetNext(), ListStyles.UpArrow, ListStyles.PreButton))
						Limiter.ChangeRange(-5);
					if(FoCsGUI.Button(horScope.GetNext(), ListStyles.Up2Arrow, ListStyles.PreButton))
						Limiter.ChangeRange(-10);
				}
				var minString = Limiter.Min.ToString();
				var maxString = Limiter.Max.ToString();

				var shortLabel = $"{(minString.Length + maxString.Length < 5? "Index" : "I")}: {minString}-{maxString}";
				var toolTip = $"Viewable Indices: Min:{minString} Max:{maxString}";
				FoCsGUI.Button(horScope.GetNext(5).ChangeY(-3), new GUIContent(shortLabel, toolTip), ListStyles.MiniLabel);
				using(FoCsEditor.Disposables.DisabledScope(!Limiter.CanIncrease()))
				{
					if(FoCsGUI.Button(horScope.GetNext(), ListStyles.DownArrow, ListStyles.PreButton))
						Limiter.ChangeRange(5);
					if(FoCsGUI.Button(horScope.GetNext(), ListStyles.Down2Arrow, ListStyles.PreButton))
						Limiter.ChangeRange(10);
				}
			}

			private void FooterAddGUI(Rect addButtonRect)
			{
				using(FoCsEditor.Disposables.DisabledScope((List.onCanAddCallback != null) && !List.onCanAddCallback(List)))
				{
					if(GUI.Button(addButtonRect,
								  List.onAddDropdownCallback == null?
									  ListStyles.IconToolbarPlus :
									  ListStyles.IconToolbarPlusMore,
								  ListStyles.PreButton))
					{
						if(List.onAddDropdownCallback != null)
							List.onAddDropdownCallback(addButtonRect, List);
						else if(List.onAddCallback != null)
							List.onAddCallback(List);
						else
							Defaults.DoAddButton(List);
						if(List.onChangedCallback != null)
							List.onChangedCallback(List);
						Limiter?.ChangeEnd();
					}
				}
			}

			private void FooterRemoveGUI(Rect removeButtonRect)
			{
				using(FoCsEditor.Disposables.DisabledScope((List.index < 0) ||
														   (List.index >= List.count) ||
														   ((List.onCanRemoveCallback != null) && !List.onCanRemoveCallback(List))))
				{
					if(GUI.Button(removeButtonRect, ListStyles.IconToolbarMinus, ListStyles.PreButton))
					{
						if(List.onRemoveCallback == null)
							Defaults.DoRemoveButton(List);
						else
							List.onRemoveCallback(List);
						if(List.onChangedCallback != null)
							List.onChangedCallback(List);

						Limiter?.ChangeRange(-1);
					}
				}
			}
			#endregion

			#region Delegate Setters
			/// <summary>
			/// SetAddCallBack
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetAddCallBack(ReorderableList.AddCallbackDelegate a)
			{
				List.onAddCallback = a;
				return this;
			}

			/// <summary>
			/// SetAddDropdownCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetAddDropdownCallback(ReorderableList.AddDropdownCallbackDelegate a)
			{
				List.onAddDropdownCallback = a;
				return this;
			}

			/// <summary>
			/// SetCanAddCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetCanAddCallback(ReorderableList.CanAddCallbackDelegate a)
			{
				List.onCanAddCallback = a;
				return this;
			}

			/// <summary>
			/// SetCanRemoveCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetCanRemoveCallback(ReorderableList.CanRemoveCallbackDelegate a)
			{
				List.onCanRemoveCallback = a;
				return this;
			}

			/// <summary>
			/// SetReorderCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetReorderCallback(ReorderableList.ReorderCallbackDelegate a)
			{
				List.onReorderCallback = a;
				return this;
			}

			/// <summary>
			/// SetDrawElementBackgroundCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawElementBackgroundCallback(ReorderableList.ElementCallbackDelegate a)
			{
				List.drawElementBackgroundCallback = a;
				return this;
			}

			/// <summary>
			/// SetDrawElementCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawElementCallback(ReorderableList.ElementCallbackDelegate a)
			{
				List.drawElementCallback = a;
				return this;
			}

			/// <summary>
			/// SetDrawFooterCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawFooterCallback(ReorderableList.FooterCallbackDelegate a)
			{
				List.drawFooterCallback = a;
				return this;
			}

			/// <summary>
			/// SetDrawHeaderCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawHeaderCallback(ReorderableList.HeaderCallbackDelegate a)
			{
				List.drawHeaderCallback = a;
				return this;
			}

			/// <summary>
			/// SetElementHeightCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetElementHeightCallback(ReorderableList.ElementHeightCallbackDelegate a)
			{
				List.elementHeightCallback = a;
				return this;
			}

			/// <summary>
			/// SetSelectCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetSelectCallback(ReorderableList.SelectCallbackDelegate a)
			{
				List.onSelectCallback = a;
				return this;
			}
			#endregion
		}
	}
}