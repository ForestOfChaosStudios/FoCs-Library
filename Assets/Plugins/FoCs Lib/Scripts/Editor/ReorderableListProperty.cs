using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditorInternal;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public class ReorderableListProperty
	{
		private SerializedProperty _property;
		public bool Animate;

		private ReorderableList.Defaults s_Defaults;

		/// <summary>
		///     ref http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
		/// </summary>
		public ReorderableList List { get; private set; }

		public AnimBool IsExpanded { get; set; }

		public ReorderableList.Defaults Defaults => s_Defaults ?? (s_Defaults = new ReorderableList.Defaults());

		public SerializedProperty Property
		{
			private get { return _property; }
			set
			{
				_property = value;
				List.serializedProperty = _property;
			}
		}

		public ReorderableListProperty(SerializedProperty property, bool animate = false)
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
			CreateList();
		}

		~ReorderableListProperty()
		{
			_property = null;
			List = null;
		}

		private void CreateList()
		{
			const bool dragable = true,
					   header = true,
					   add = true,
					   remove = true;
			List = new ReorderableList(Property.serializedObject, Property, dragable, header, add, remove);
			List.drawHeaderCallback += OnListDrawHeaderCallback;
			List.onCanRemoveCallback += OnListOnCanRemoveCallback;
			List.drawElementCallback += DrawElement;
			List.elementHeightCallback += OnListElementHeightCallback;
			//TODO Impliment limited view of lists, eg only show index 50-100, and buttons to move limits
			List.drawFooterCallback += OnListDrawFooterCallback;
			List.showDefaultBackground = true;
		}

		private void DrawElement(Rect rect, int index, bool active, bool focused)
		{
			rect.height = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(_property.GetArrayElementAtIndex(index), _property.GetArrayElementAtIndex(index).isExpanded));

			rect.y += 1;
			EditorGUI.PropertyField(rect,
									_property.GetArrayElementAtIndex(index),
									_property.GetArrayElementAtIndex(index).propertyType == SerializedPropertyType.Generic?
										new GUIContent(_property.GetArrayElementAtIndex(index).displayName) :
										GUIContent.none,
									true);
		}

		public void HandleDrawing()
		{
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

		public void HandleDrawing(Rect rect)
		{
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

		public float GetTotalHeight()
		{
			if(!Property.isExpanded)
				return List.headerHeight;
			return (List.elementHeight *
					(List.count == 0?
						1.5f :
						List.count)) +
				   List.headerHeight +
				   List.footerHeight +
				   2;
		}

		public static implicit operator ReorderableListProperty(SerializedProperty input) => new ReorderableListProperty(input);
		public static implicit operator SerializedProperty(ReorderableListProperty input) => input.Property;

		#region DelegateMethods
		private float OnListElementHeightCallback(int index) => Mathf.Max(EditorGUIUtility.singleLineHeight,
																		  EditorGUI.GetPropertyHeight(_property.GetArrayElementAtIndex(index), _property.GetArrayElementAtIndex(index).isExpanded)) +
																4.0f;

		private bool OnListOnCanRemoveCallback(ReorderableList list) => List.count > 0;

		private void OnListDrawHeaderCallback(Rect rect)
		{
			using(EditorDisposables.IndentSet(0))
			{
				_property.isExpanded = EditorGUI.ToggleLeft(rect,
															$"{_property.displayName}\t[{_property.arraySize}]",
															_property.isExpanded,
															_property.prefabOverride?
																EditorStyles.boldLabel :
																GUIStyle.none);
			}
		}

		private bool RangedDisplay = true;

		private void OnListDrawFooterCallback(Rect rowRect)
		{
			float xMax = rowRect.xMax;
			float x = xMax - 8f;
			if(List.displayAdd)
				x -= 25f;
			if(List.displayRemove)
				x -= 25f;

			if(RangedDisplay)
				x -= (25f * 6);
			var rect = new Rect(x, rowRect.y, xMax - x, rowRect.height);

			Rect addButtonRect = new Rect(xMax - 29f - 25f, rect.y - 3f, 25f, 13f);

			Rect removeButtonRect = new Rect(xMax - 29f, rect.y - 3f, 25f, 13f);
			if(Event.current.type == EventType.Repaint)
				ListStyles.FooterBackground.Draw(rect, false, false, false, false);

			if(RangedDisplay)
			{
				var horScope = EditorDisposables.RectHorizontalScope(11, rect.ChangeX(5).MoveWidth(-16));

				if(FoCsGUI.Button(horScope.GetNext(), ListStyles.UpArrow, ListStyles.PreButton))
				{ }
				if(FoCsGUI.Button(horScope.GetNext(), ListStyles.Up2Arrow, ListStyles.PreButton))
				{ }
				var minString = 32.ToString();
				var maxString = 102.ToString();



				var shortLabel = $"{(minString.Length + maxString.Length >4?"Index":"I")}: {minString}-{maxString}";
				var toolTip = $"Viewable Indices: Min:{minString} Max:{maxString}";
				FoCsGUI.Button(horScope.GetNext(5).ChangeY(-3), new GUIContent(shortLabel, toolTip), ListStyles.MiniLabel);

				if(FoCsGUI.Button(horScope.GetNext(), ListStyles.DownArrow, ListStyles.PreButton))
				{ }
				if(FoCsGUI.Button(horScope.GetNext(), ListStyles.Down2Arrow, ListStyles.PreButton))
				{ }
			}


			if(List.displayAdd)
			{
				using(EditorDisposables.DisabledScope(List.onCanAddCallback != null && !List.onCanAddCallback(List)))
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
					}
				}
			}
			if(!List.displayRemove)
				return;
			using(EditorDisposables.DisabledScope(List.index < 0 || List.index >= List.count || List.onCanRemoveCallback != null && !List.onCanRemoveCallback(List)))
			{
				if(GUI.Button(removeButtonRect, ListStyles.IconToolbarMinus, ListStyles.PreButton))
				{
					if(List.onRemoveCallback == null)
						Defaults.DoRemoveButton(List);
					else
						List.onRemoveCallback(List);
					if(List.onChangedCallback != null)
						List.onChangedCallback(List);
				}
			}
		}
		#endregion


		public static class ListStyles
		{
			public static readonly GUIContent IconToolbarPlus = EditorGUIUtility.IconContent("Toolbar Plus", "|Add to list");
			public static readonly GUIContent IconToolbar = EditorGUIUtility.IconContent("Toolbar Plus", "|Add to list");

			public static readonly GUIContent IconToolbarPlusMore = EditorGUIUtility.IconContent("Toolbar Plus More", "Choose to add to list");
			public static readonly GUIContent IconToolbarMinus = EditorGUIUtility.IconContent("Toolbar Minus", "Remove selection from list");


			public static readonly GUIContent UpArrow = new GUIContent(FoCsGUIImages.UpArrow, "Increase Displayed Index 5");
			public static readonly GUIContent Up2Arrow = new GUIContent(FoCsGUIImages.Up2Arrow, "Increase Displayed Index 10");

			public static readonly GUIContent DownArrow = new GUIContent(FoCsGUIImages.DownArrow, "Decrease Displayed Index 5");
			public static readonly GUIContent Down2Arrow = new GUIContent(FoCsGUIImages.Down2Arrow, "Decrease Displayed Index 10");

			private static GUIStyle miniLabel;

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




			public static readonly GUIStyle DraggingHandle = new GUIStyle("RL DragHandle");
			public static readonly GUIStyle HeaderBackground = new GUIStyle("RL Header");
			public static readonly GUIStyle FooterBackground = new GUIStyle("RL Footer");
			public static readonly GUIStyle BoxBackground = new GUIStyle("RL Background");
			public static readonly GUIStyle PreButton = new GUIStyle("RL FooterButton");
			public static readonly GUIStyle ElementBackground = new GUIStyle("RL Element");
		}
	}
}