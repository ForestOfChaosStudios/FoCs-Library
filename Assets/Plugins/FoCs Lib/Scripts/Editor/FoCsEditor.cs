//#define JMilesEditorBase_ANIMATED

using System;
using System.Collections.Generic;
using System.Reflection;
using ForestOfChaosLib.Editor.PropertyDrawers.Types;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using RLP = ForestOfChaosLib.Editor.ReorderableListProperty;

//Based off of the CustomBaseEditor available at
//https://gist.github.com/t0chas/34afd1e4c9bc28649311
//Removed animation on lists enabled/disabled
//and a few other things
namespace ForestOfChaosLib.Editor
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(object), true, isFallback = true)]
	public class FoCsEditor: UnityEditor.Editor
	{
		private Dictionary<string, RLP> reorderableLists = new Dictionary<string, RLP>(1);
		private Dictionary<string, ObjectDrawer> objectDrawers = new Dictionary<string, ObjectDrawer>(10);

		public static float StandardLine => EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

		protected bool GUIChanged { get; private set; }

		public virtual bool HideDefaultProperty => true;

		public virtual bool ShowCopyPasteButtons => true;

		protected virtual EditorHelpers.HeaderButton[] GetHeaderButtons => null;

		protected virtual bool DrawHeaderButtonsAfter => false;

		public override bool UseDefaultMargins() => false;

		protected virtual void OnEnable()
		{
			reorderableLists = new Dictionary<string, RLP>(1);
			objectDrawers = new Dictionary<string, ObjectDrawer>(10);
		}

		~FoCsEditor()
		{
			reorderableLists.Clear();
			reorderableLists = null;
		}

		public override void OnInspectorGUI()
		{
			using(EditorDisposables.Indent())
			{
				DrawCopyButtons();
				using (var changeCheckScope = EditorDisposables.ChangeCheck())
				{
					var cachedGuiColor = GUI.color;
					serializedObject.Update();

					foreach(var serializedProperty in serializedObject.Properties())
					{
						GUI.color = cachedGuiColor;
						HandleProperty(serializedProperty);
					}
					if (changeCheckScope.changed)
					{
						serializedObject.ApplyModifiedProperties();
						GUIChanged = true;
					}
					else
						GUIChanged = false;
				}

				DrawGUI();
				using(EditorDisposables.VerticalScope(GUILayout.Height(4)))
				{ }
			}
		}

		private void DrawCopyButtons()
		{
			if (ShowCopyPasteButtons)
				EditorHelpers.CopyPastObjectButtons(serializedObject, GetHeaderButtons, DrawHeaderButtonsAfter);
		}

		public virtual void DrawGUI()
		{ }

		public virtual void OnSceneGUI()
		{ }

		protected void HandleProperty(SerializedProperty property)
		{
			if(HideDefaultProperty)
			{
				var isDefaultScriptProperty = GetDefaultPropertyType(property);
				if(isDefaultScriptProperty == DefaultPropertyType.Hidden)
					return;

				var cachedGUIEnabled = GUI.enabled;
				if (isDefaultScriptProperty != DefaultPropertyType.NotDefault)
					GUI.enabled = false;

				DoPropertyDraw(property, isDefaultScriptProperty);

				if (isDefaultScriptProperty != DefaultPropertyType.NotDefault)
					GUI.enabled = cachedGUIEnabled;
			}
			else
			{
				DoPropertyDraw(property);
			}
		}

		private void DoPropertyDraw(SerializedProperty property, DefaultPropertyType defaultType = DefaultPropertyType.NotDefault)
		{
			if (PropertyIsArrayAndNotString(property))
				HandleArray(property);
			else if (property.propertyType == SerializedPropertyType.ObjectReference && defaultType != DefaultPropertyType.Disabled)
				HandleObjectReference(property);
			else
				EditorGUILayout.PropertyField(property, property.isExpanded);
		}

		private void HandleObjectReference(SerializedProperty property)
		{
			var drawer = GetObjectDrawer(property);
			var GuiCont = new GUIContent(property.displayName);
			var height = drawer.GetPropertyHeight(property, GuiCont);
			var rect = EditorGUILayout.GetControlRect(true, height);
			drawer.OnGUI(rect, property, GuiCont);
		}

		public enum DefaultPropertyType
		{
			NotDefault,
			Disabled,
			Hidden
		}

		public static DefaultPropertyType GetDefaultPropertyType(SerializedProperty property)
		{
			if(property.displayName.Equals("Object Hide Flags"))
				return DefaultPropertyType.Hidden;
			if(IsDefaultScriptProperty(property))
				return DefaultPropertyType.Disabled;
			return DefaultPropertyType.NotDefault;
		}

		public static bool IsDefaultScriptProperty(SerializedProperty property)
		{
			return property.name.Equals("m_Script") &&
					property.type.Equals("PPtr<MonoScript>") &&
					(property.propertyType == SerializedPropertyType.ObjectReference) &&
					property.propertyPath.Equals("m_Script");
		}

		public static bool IsPropertyHidden(SerializedProperty property)
		{
			return GetDefaultPropertyType(property) != DefaultPropertyType.NotDefault;}

		protected bool PropertyIsArrayAndNotString(SerializedProperty property) => property.isArray && (property.propertyType != SerializedPropertyType.String);

		public void HandleArray(SerializedProperty property)
		{
			using(EditorDisposables.Indent(-1))
			{
				var listData = GetReorderableList(property);
				var height = listData.GetTotalHeight();
				var rect = EditorGUILayout.GetControlRect(true, height).ChangeX(16);
				listData.HandleDrawing(rect);
			}
		}

		protected object[] GetPropertyAttributes(SerializedProperty property) => GetPropertyAttributes<PropertyAttribute>(property);

		protected object[] GetPropertyAttributes<T>(SerializedProperty property)
			where T: Attribute
		{
			const BindingFlags bindingFlags = BindingFlags.GetField |
											  BindingFlags.GetProperty |
											  BindingFlags.IgnoreCase |
											  BindingFlags.Instance |
											  BindingFlags.NonPublic |
											  BindingFlags.Public;
			if(property.serializedObject.targetObject == null)
				return null;
			var targetType = property.serializedObject.targetObject.GetType();
			var field = targetType.GetField(property.name, bindingFlags);
			return (field != null?
				field.GetCustomAttributes(typeof(T), true) :
				null);
		}

		private ObjectDrawer GetObjectDrawer(SerializedProperty property)
		{
			var id = $"{property.propertyPath}-{property.name}";
			ObjectDrawer objDraw;
			if(objectDrawers.TryGetValue(id, out objDraw))
			{
				return objDraw;
			}
			objDraw = new ObjectDrawer();

			objectDrawers.Add(id, objDraw);
			return objDraw;
		}

		private RLP GetReorderableList(SerializedProperty property)
		{
			var id = $"{property.propertyPath}-{property.name}";
			RLP ret;
			if(reorderableLists.TryGetValue(id, out ret))
			{
				ret.Property = property;
				return ret;
			}
#if JMilesEditorBase_ANIMATED
            ret = new RLP(property, true);
#else
			ret = new RLP(property, false);
#endif

			reorderableLists.Add(id, ret);
			return ret;
		}

		public override bool RequiresConstantRepaint()
		{
#if JMilesEditorBase_ANIMATED
            foreach(var reorderableListProperty in reorderableLists)
            {
                if(reorderableListProperty.Value.Animate && reorderableListProperty.Value.IsExpanded.isAnimating)
                    return true;
            }
#endif
			return false;
		}

		public int GetFileID()
		{
			//From https://forum.unity.com/threads/how-to-get-the-local-identifier-in-file-for-scene-objects.265686/
			var inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);

			int localId;
			{
				var seriObject = new SerializedObject(target);

				var inspectorModeInfoValue = inspectorModeInfo.GetValue(seriObject);

				inspectorModeInfo.SetValue(seriObject, InspectorMode.Debug, null);

				var localIdProp = seriObject.FindProperty("m_LocalIdentfierInFile"); //note the misspelling!

				inspectorModeInfo.SetValue(seriObject, inspectorModeInfoValue, null);

				localId = localIdProp.intValue;
			}

			return localId;
		}

		public string AssetPath() => AssetDatabase.GetAssetPath(target);

		public static string AssetPath(Object target) => AssetDatabase.GetAssetPath(target);
	}

	public class FoCsEditor<T>: FoCsEditor
		where T: Object
	{
		protected T Target => (T)target;
	}
}