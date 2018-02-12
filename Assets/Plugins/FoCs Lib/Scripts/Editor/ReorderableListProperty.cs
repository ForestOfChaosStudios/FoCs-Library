using ForestOfChaosLib.Editor.Utilities;
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
			//List.drawFooterCallback += OnListDrawFooterCallback;
			List.showDefaultBackground = true;
		}

		private void DrawElement(Rect rect, int index, bool active, bool focused)
		{
			rect.height = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(_property.GetArrayElementAtIndex(index), GUIContent.none, true));

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
																		  EditorGUI.GetPropertyHeight(_property.GetArrayElementAtIndex(index), GUIContent.none, true)) +
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

		private void OnListDrawFooterCallback(Rect rect)
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
		#endregion
	}
}