﻿using System;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;
using ORD = ForestOfChaosLib.Editor.PropertyDrawers.ObjectReferenceDrawer;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		public class ReorderableListProperty
		{
			public static    int                      GLOBAL_CURRENT_ID;
			private static   ReorderableList.Defaults s_Defaults;
			private static   Action                   OnLimitingChange;
			private static   bool?                    limitingEnabled;
			private readonly Dictionary<string, ORD>  objectDrawers = new Dictionary<string, ORD>(1);
			private          SerializedProperty       property;
			public           bool                     Animate;
			public           int                      ID;
			public           ListLimiter              Limiter;

			public static bool LimitingEnabled
			{
				get
				{
					if(!limitingEnabled.HasValue)
						limitingEnabled = EditorPrefs.GetInt("FoCsRLP.LimitingEnabled") == 0;

					return limitingEnabled.Value;
				}
				set
				{
					limitingEnabled = value;
					EditorPrefs.SetInt("FoCsRLP.LimitingEnabled", value? 0 : 1);
					OnLimitingChange.Trigger();
				}
			}

			public ReorderableList List       { get; private set; }
			public AnimBool        IsExpanded { get; set; }

			public static ReorderableList.Defaults Defaults
			{
				get { return s_Defaults ?? (s_Defaults = new ReorderableList.Defaults()); }
			}

			public SerializedProperty Property
			{
				get { return property; }
				set
				{
					property                = value;
					List.serializedProperty = property;
				}
			}

			private ReorderableListProperty()
			{
				ID = GLOBAL_CURRENT_ID;
				++GLOBAL_CURRENT_ID;
			}

			public ReorderableListProperty(SerializedProperty property): this()
			{
				this.property = property;
				Animate       = false;
				InitList();
			}

			public ReorderableListProperty(SerializedProperty property, bool dragAble, bool displayHeader = true, bool displayAdd = true, bool displayRemove = true, bool animate = false): this()
			{
				this.property = property;
				Animate       = animate;

				if(Animate)
					IsExpanded = new AnimBool(property.isExpanded) {speed = 1f};

				InitList(dragAble, displayHeader, displayAdd, displayRemove);
			}

			~ReorderableListProperty()
			{
				property         =  null;
				List             =  null;
				OnLimitingChange -= ChangeLimiting;
			}

			private void ChangeLimiting()
			{
				Limiter = null;
			}

			private void InitList(bool dragable = true, bool displayHeader = true, bool displayAdd = true, bool displayRemove = true)
			{
				OnLimitingChange           += ChangeLimiting;
				List                       =  new ReorderableList(Property.serializedObject, Property, dragable, displayHeader, displayAdd, displayRemove);
				List.drawHeaderCallback    += OnListDrawHeaderCallback;
				List.onCanRemoveCallback   += OnListOnCanRemoveCallback;
				List.drawElementCallback   += DrawElement;
				List.elementHeightCallback += OnListElementHeightCallback;
				//TODO Implement limited view of lists, eg only show index 50-100, and buttons to move limits
				List.drawFooterCallback    += OnListDrawFooterCallback;
				List.showDefaultBackground =  true;
				CheckLimiter();
			}

			private void CheckLimiter()
			{
				if(LimitingEnabled)
				{
					if(Limiter == null)
						Limiter = ListLimiter.GetLimiter(this);
					else
						Limiter.UpdateRange();
				}
			}

			private void DrawElement(Rect rect, int index, bool active, bool focused)
			{
				if(Limiter == null)
					DoDrawElement(rect, index);
				else if(Limiter.ShowElement(index))
					DoDrawElement(rect, index);
				else
					List.elementHeight = 0;
			}

			private void DoDrawElement(Rect rect, int index)
			{
				//Debug.Log(List.serializedProperty.GetArrayElementAtIndex(index).type);

				if(List.serializedProperty.GetArrayElementAtIndex(index).propertyType == SerializedPropertyType.ObjectReference)
					HandleObjectReference(rect, List.serializedProperty.GetArrayElementAtIndex(index));
				else
				{
					List.elementHeight =  rect.height = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(property.GetArrayElementAtIndex(index), property.GetArrayElementAtIndex(index).isExpanded));
					rect.y             += 1;
					var iProp = property.GetArrayElementAtIndex(index);
					//EditorGUI.PropertyField(rect, iProp, iProp.propertyType == SerializedPropertyType.Generic? new GUIContent(iProp.displayName) : GUIContent.none, true);
					EditorGUI.PropertyField(rect, iProp, new GUIContent(iProp.displayName), true);
				}
			}

			private void HandleObjectReference(Rect rect, SerializedProperty property)
			{
				var drawer                       = GetObjectDrawer(property);
				var GuiCont                      = new GUIContent(property.displayName);
				List.elementHeight = rect.height = ObjectReferenceElementHeight(property, GuiCont);
				drawer.OnGUI(rect, property, GuiCont);
			}

			private float ObjectReferenceElementHeight(SerializedProperty property)
			{
				return ObjectReferenceElementHeight(property, new GUIContent(property.displayName));
			}

			private float ObjectReferenceElementHeight(SerializedProperty property, GUIContent content)
			{
				var drawer = GetObjectDrawer(property);

				return drawer.GetPropertyHeight(property, content);
			}

			public void HandleDrawing()
			{
				using(Disposables.VerticalScope())
				{
					CheckLimiter();

					if(Animate)
					{
						IsExpanded.target = Property.isExpanded;

						if((!IsExpanded.value && !IsExpanded.isAnimating) || (!IsExpanded.value && IsExpanded.isAnimating))
							DrawDefaultHeader();
						else
						{
							using(var fg = Disposables.FadeGroupScope(IsExpanded.faded))
							{
								if(fg.visible)
									List.DoLayoutList();
							}
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

			public void DrawHeader()
			{
				DrawDefaultHeader();
			}

			public void DrawHeader(Rect rect)
			{
				DrawDefaultHeader(rect);
			}

			private void DrawDefaultHeader()
			{
				DrawDefaultHeader(GUILayoutUtility.GetRect(0.0f, List.headerHeight, GUILayout.ExpandWidth(true)));
			}

			public static Object[] DropZone(Rect rect)
			{
				var eventType  = Event.current.type;
				var isAccepted = false;

				if(rect.Contains(Event.current.mousePosition))
				{
					if((eventType == EventType.DragUpdated) || (eventType == EventType.DragPerform))
					{
						DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

						if(eventType == EventType.DragPerform)
						{
							DragAndDrop.AcceptDrag();
							isAccepted = true;
						}

						Event.current.Use();
					}
				}

				return isAccepted? DragAndDrop.objectReferences : null;
			}

			private void DrawDefaultHeader(Rect headerRect)
			{
				Defaults.DrawHeaderBackground(headerRect);
				headerRect.xMin   += 6f;
				headerRect.xMax   -= 6f;
				headerRect.height -= 2f;
				++headerRect.y;
				List.drawHeaderCallback(headerRect);

				if(property.arrayElementType.Contains("PPtr<"))
				{
					var @event = Event.current;

					if(headerRect.Contains(@event.mousePosition))
					{
						if((@event.type == EventType.DragUpdated) || (@event.type == EventType.DragPerform))
						{
							Debug.Log(property.arrayElementType);

							foreach(var dD in DragAndDrop.objectReferences)
							{
								Debug.Log(dD.GetType().Name);
							}

							DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

							if(@event.type == EventType.DragPerform)
							{
								DoDropAdd();
								DragAndDrop.AcceptDrag();
							}

							@event.Use();
						}
					}
				}
			}

			private void DoDropAdd()
			{
				for(var i = 0; i < DragAndDrop.objectReferences.Length; i++)
				{
					var obj      = DragAndDrop.objectReferences[i];
					var typeName = obj.GetType().Name;

					var length = property.arraySize;
					property.InsertArrayElementAtIndex(length);
					var prop = property.GetArrayElementAtIndex(length);

					prop.objectReferenceValue = obj;

					if(prop.objectReferenceValue != null)
						continue;

					if(prop.type.Contains(typeName))
					{
						prop.objectReferenceValue = obj;

						continue;
					}

					var transform  = obj as Transform;
					var gameObject = obj as GameObject;

					if(transform)
					{
						switch(typeName)
						{
							case "Transform":
								prop.objectReferenceValue = transform;

								continue;
							case "GameObject":
								prop.objectReferenceValue = transform.gameObject;

								continue;
						}

						gameObject = transform.gameObject;
					}
					else if(gameObject)
					{
						switch(typeName)
						{
							case "Transform":
								prop.objectReferenceValue = gameObject.transform;

								continue;
							case "GameObject":
								prop.objectReferenceValue = gameObject;

								continue;
						}
					}

					if(gameObject)
					{
						foreach(var component in gameObject.GetComponents<Component>())
						{
							if(!prop.type.Contains(component.GetType().Name))
								continue;

							prop.objectReferenceValue = component;

							break;
						}
					}

					if(prop.objectReferenceValue == null)
						property.DeleteArrayElementAtIndex(length);
				}

				GUI.changed = true;
			}

			public float GetTotalHeight()
			{
				if(!Property.isExpanded)
					return List.headerHeight + FoCsGUI.Padding;

				var height = List.headerHeight + List.footerHeight + 4 + FoCsGUI.Padding;

				if(Property.isExpanded && (List.serializedProperty.arraySize == 0))
					return List.elementHeight + height;

				CheckLimiter();

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

			public static implicit operator ReorderableListProperty(SerializedProperty input)
			{
				return new ReorderableListProperty(input);
			}

			public static implicit operator SerializedProperty(ReorderableListProperty input)
			{
				return input.Property;
			}

#region Storage
			private ORD GetObjectDrawer(SerializedProperty property)
			{
				var id = string.Format("{0}-{1}", property.propertyPath, property.name);
				ORD objDraw;

				if(objectDrawers.TryGetValue(id, out objDraw))
					return objDraw;

				objDraw = new ORD();
				objectDrawers.Add(id, objDraw);

				return objDraw;
			}
#endregion

			public static class ListStyles
			{
				public static readonly GUIContent IconToolbarPlus     = EditorGUIUtility.IconContent("Toolbar Plus",      "|Add to list");
				public static readonly GUIContent IconToolbar         = EditorGUIUtility.IconContent("Toolbar Plus",      "|Add to list");
				public static readonly GUIContent IconToolbarPlusMore = EditorGUIUtility.IconContent("Toolbar Plus More", "Choose to add to list");
				public static readonly GUIContent IconToolbarMinus    = EditorGUIUtility.IconContent("Toolbar Minus",     "Remove selection from list");
				private static         GUIStyle   miniLabel;
				public static readonly GUIStyle   DraggingHandle    = new GUIStyle("RL DragHandle");
				public static readonly GUIStyle   HeaderBackground  = new GUIStyle("RL Header");
				public static readonly GUIStyle   FooterBackground  = new GUIStyle("RL Footer");
				public static readonly GUIStyle   BoxBackground     = new GUIStyle("RL Background");
				public static readonly GUIStyle   PreButton         = new GUIStyle("RL FooterButton");
				public static readonly GUIStyle   ElementBackground = new GUIStyle("RL Element");

				public static GUIStyle MiniLabel
				{
					get
					{
						if(miniLabel != null)
							return miniLabel;

						miniLabel           = new GUIStyle(EditorStyles.miniLabel);
						miniLabel.alignment = TextAnchor.UpperCenter;

						return miniLabel;
					}
				}
			}

			public class ListLimiter
			{
				private static Action                  ChangeCount;
				private        int                     _max;
				private        int                     _min;
				public         ReorderableListProperty MyListProperty;
				private        bool                    Update;

				private static int _TOTAL_VISIBLE_COUNT
				{
					get
					{
						var num = Mathf.Clamp(EditorPrefs.GetInt("FoCsRLP._TOTAL_VISIBLE_COUNT"), 0, int.MaxValue);

						if(num == 0)
							return _TOTAL_VISIBLE_COUNT = 25;

						return num;
					}
					set { EditorPrefs.SetInt("FoCsRLP._TOTAL_VISIBLE_COUNT", Mathf.Clamp(value, 0, int.MaxValue)); }
				}

				public static int TOTAL_VISIBLE_COUNT
				{
					get { return _TOTAL_VISIBLE_COUNT; }
					set
					{
						_TOTAL_VISIBLE_COUNT = value;
						ChangeCount.Trigger();
					}
				}

				private int Count
				{
					get { return MyListProperty.Property.arraySize; }
				}

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

				public bool ShowElement(int index)
				{
					return (index >= Min) && (index < Max);
				}

				public static ListLimiter GetLimiter(ReorderableListProperty listProperty)
				{
					if(listProperty.Property.arraySize < TOTAL_VISIBLE_COUNT)
						return null;

					var limiter = new ListLimiter {MyListProperty = listProperty, Min = 0, Max = TOTAL_VISIBLE_COUNT, Update = true};
					ChangeCount += limiter.UpdateRange;

					return limiter;
				}

				public bool CanDecrease()
				{
					CheckUpdate();

					return _min > 0;
				}

				public bool CanIncrease()
				{
					CheckUpdate();

					return _max < Count;
				}

				public void ChangeRange(int amount)
				{
					if(amount != 0)
						CheckUpdate();

					var newMin = Min    + amount;
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
						Min    = newMax - TOTAL_VISIBLE_COUNT;
						Max    = newMax;

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

				public void UpdateRange()
				{
					Update = true;
				}

				private void CheckUpdate()
				{
					if(Update)
						ChangeRange(0);
				}

				~ListLimiter()
				{
					ChangeCount -= UpdateRange;
				}

				/// <inheritdoc />
				public override string ToString()
				{
					return string.Format("Min: {0}. Max: {1}", Min, Max);
				}
			}

#region Delegate Methods
			private float OnListElementHeightCallback(int index)
			{
				var prop = List.serializedProperty.GetArrayElementAtIndex(index);

				if(Limiter == null)
				{
					if(List.serializedProperty.GetArrayElementAtIndex(index).propertyType == SerializedPropertyType.ObjectReference)
						return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, ObjectReferenceElementHeight(prop)) + 4.0f;

					return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(prop, prop.isExpanded)) + 4.0f;
				}

				if(Limiter.ShowElement(index))
				{
					if(List.serializedProperty.GetArrayElementAtIndex(index).propertyType == SerializedPropertyType.ObjectReference)
						return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, ObjectReferenceElementHeight(prop)) + 4.0f;

					return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(prop, prop.isExpanded)) + 4.0f;
				}

				return 0;
			}

			private bool OnListOnCanRemoveCallback(ReorderableList list)
			{
				return List.count > 0;
			}

			private void OnListDrawHeaderCallback(Rect rect)
			{
				var xMax = rect.xMax;
				var x    = xMax - 8f;

				if(List.displayAdd)
					x -= 25f;

				if(List.displayRemove)
					x -= 25f;

				using(Disposables.IndentSet(0))
				{
					property.isExpanded = EditorGUI.ToggleLeft(rect.Edit(RectEdit.SetWidth(x - 10)),
					                                           string.Format("{0}\t[{1}]", property.displayName, property.arraySize),
					                                           property.isExpanded,
					                                           property.prefabOverride? EditorStyles.boldLabel : GUIStyle.none);
				}

				using(Disposables.DisabledScope(!property.isExpanded))
				{
					var rect2            = new Rect(x, rect.y, xMax - x,   rect.height);
					var addButtonRect    = new Rect(xMax - 29f      - 25f, rect2.y - 3f, 25f, 13f);
					var removeButtonRect = new Rect(xMax            - 29f, rect2.y - 3f, 25f, 13f);

					if(List.displayAdd)
						FooterAddGUI(addButtonRect.Edit(RectEdit.AddY(3)));

					if(List.displayRemove)
						FooterRemoveGUI(removeButtonRect.Edit(RectEdit.AddY(3)));
				}
			}

			private void OnListDrawFooterCallback(Rect rowRect)
			{
				var xMax = rowRect.xMax;
				var x    = xMax - 8f;

				if(List.displayAdd)
					x -= 25f;

				if(List.displayRemove)
					x -= 25f;

				if(Limiter != null)
					x -= 25f * 6;

				var rect             = new Rect(x, rowRect.y, xMax - x,   rowRect.height);
				var addButtonRect    = new Rect(xMax - 29f         - 25f, rect.y - 3f, 25f, 13f);
				var removeButtonRect = new Rect(xMax               - 29f, rect.y - 3f, 25f, 13f);

				if(Event.current.type == EventType.Repaint)
					ListStyles.FooterBackground.Draw(rect, false, false, false, false);

				if(Limiter != null)
					FooterLimiterGUI(rect);

				if(List.displayAdd)
					{FooterAddGUI(addButtonRect);}

				if(List.displayRemove)
					FooterRemoveGUI(removeButtonRect);
			}

			private void FooterLimiterGUI(Rect rect)
			{
				var minAmount  = 1;
				var maxAmount  = 5;
				var upArrow    = new GUIContent("", string.Format("Increase Displayed Index {0}", minAmount));
				var up2Arrow   = new GUIContent("", string.Format("Increase Displayed Index {0}", maxAmount));
				var downArrow  = new GUIContent("", string.Format("Decrease Displayed Index {0}", minAmount));
				var down2Arrow = new GUIContent("", string.Format("Decrease Displayed Index {0}", maxAmount));
				var horScope   = Disposables.RectHorizontalScope(11, rect.Edit(RectEdit.ChangeX(5), RectEdit.AddWidth(-16)));

				using(Disposables.DisabledScope(!Limiter.CanDecrease()))
				{
					if(FoCsGUI.Button(horScope.GetNext(), upArrow, FoCsGUI.Styles.UpArrow))
						Limiter.ChangeRange(-minAmount);

					if(FoCsGUI.Button(horScope.GetNext(), up2Arrow, FoCsGUI.Styles.Up2Arrow))
						Limiter.ChangeRange(-maxAmount);
				}

				var minString  = (Limiter.Min + 1).ToString();
				var maxString  = Limiter.Max.ToString();
				var shortLabel = string.Format("{0}: {1}-{2}",                      minString.Length + maxString.Length < 5? "Index" : "I", minString, maxString);
				var toolTip    = string.Format("Viewable Indices: Min:{0} Max:{1}", minString,                                              maxString);
				FoCsGUI.Label(horScope.GetNext(5, RectEdit.ChangeY(-3)), new GUIContent(shortLabel, toolTip));

				using(Disposables.DisabledScope(!Limiter.CanIncrease()))
				{
					if(FoCsGUI.Button(horScope.GetNext(), downArrow, FoCsGUI.Styles.DownArrow))
						Limiter.ChangeRange(minAmount);

					if(FoCsGUI.Button(horScope.GetNext(), down2Arrow, FoCsGUI.Styles.Down2Arrow))
						Limiter.ChangeRange(maxAmount);
				}
			}

			private void FooterAddGUI(Rect addButtonRect)
			{
				using(Disposables.DisabledScope((List.onCanAddCallback != null) && !List.onCanAddCallback(List)))
				{
					var @event = Event.current;
					if(addButtonRect.Contains(@event.mousePosition))
					{
						if((@event.type == EventType.DragUpdated) || (@event.type == EventType.DragPerform))
						{
							Debug.Log(property.arrayElementType);

							foreach(var dD in DragAndDrop.objectReferences)
							{
								Debug.Log(dD.GetType().Name);
							}

							DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

							if(@event.type == EventType.DragPerform)
							{
								DoDropAdd();
								DragAndDrop.AcceptDrag();
							}

							@event.Use();
						}
					}

					if(!FoCsGUI.Button(addButtonRect, List.onAddDropdownCallback == null? ListStyles.IconToolbarPlus : ListStyles.IconToolbarPlusMore, ListStyles.PreButton))
						return;

					if(List.onAddDropdownCallback != null)
						List.onAddDropdownCallback(addButtonRect, List);
					else if(List.onAddCallback != null)
						List.onAddCallback(List);
					else
						Defaults.DoAddButton(List);

					if(List.onChangedCallback != null)
						List.onChangedCallback(List);

					if(Limiter != null)
						Limiter.ChangeEnd();
				}
			}

			private void FooterRemoveGUI(Rect removeButtonRect)
			{
				using(Disposables.DisabledScope((List.index < 0) || (List.index >= List.count) || ((List.onCanRemoveCallback != null) && !List.onCanRemoveCallback(List))))
				{
					if(!FoCsGUI.Button(removeButtonRect, ListStyles.IconToolbarMinus, ListStyles.PreButton))
						return;

					if(List.onRemoveCallback == null)
						Defaults.DoRemoveButton(List);
					else
						List.onRemoveCallback(List);

					if(List.onChangedCallback != null)
						List.onChangedCallback(List);

					if(Limiter != null)
						Limiter.ChangeRange(-1);
				}
			}
#endregion
#region Delegate Setters
			/// <summary>
			///     SetAddCallBack
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetAddCallBack(ReorderableList.AddCallbackDelegate a)
			{
				List.onAddCallback = a;

				return this;
			}

			/// <summary>
			///     SetAddDropdownCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetAddDropdownCallback(ReorderableList.AddDropdownCallbackDelegate a)
			{
				List.onAddDropdownCallback = a;

				return this;
			}

			/// <summary>
			///     SetCanAddCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetCanAddCallback(ReorderableList.CanAddCallbackDelegate a)
			{
				List.onCanAddCallback = a;

				return this;
			}

			/// <summary>
			///     SetCanRemoveCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetCanRemoveCallback(ReorderableList.CanRemoveCallbackDelegate a)
			{
				List.onCanRemoveCallback = a;

				return this;
			}

			/// <summary>
			///     SetReorderCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetReorderCallback(ReorderableList.ReorderCallbackDelegate a)
			{
				List.onReorderCallback = a;

				return this;
			}

			/// <summary>
			///     SetDrawElementBackgroundCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawElementBackgroundCallback(ReorderableList.ElementCallbackDelegate a)
			{
				List.drawElementBackgroundCallback = a;

				return this;
			}

			/// <summary>
			///     SetDrawElementCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawElementCallback(ReorderableList.ElementCallbackDelegate a)
			{
				List.drawElementCallback = a;

				return this;
			}

			/// <summary>
			///     SetDrawFooterCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawFooterCallback(ReorderableList.FooterCallbackDelegate a)
			{
				List.drawFooterCallback = a;

				return this;
			}

			/// <summary>
			///     SetDrawHeaderCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetDrawHeaderCallback(ReorderableList.HeaderCallbackDelegate a)
			{
				List.drawHeaderCallback = a;

				return this;
			}

			/// <summary>
			///     SetElementHeightCallback
			/// </summary>
			/// <param name="a">The callback to be used instead of default</param>
			/// <returns>This</returns>
			public ReorderableListProperty SetElementHeightCallback(ReorderableList.ElementHeightCallbackDelegate a)
			{
				List.elementHeightCallback = a;

				return this;
			}

			/// <summary>
			///     SetSelectCallback
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
