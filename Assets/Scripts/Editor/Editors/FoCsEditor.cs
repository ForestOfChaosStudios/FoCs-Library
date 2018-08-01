//#define FoCsEditor_ANIMATED

using System.Collections.Generic;
using System.Reflection;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;
using RLP = ForestOfChaosLib.Editor.FoCsEditor.ReorderableListProperty;
using ORD = ForestOfChaosLib.Editor.PropertyDrawers.ObjectReferenceDrawer;

//Based off of the CustomBaseEditor available at
//https://gist.github.com/t0chas/34afd1e4c9bc28649311
namespace ForestOfChaosLib.Editor
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(object), true, isFallback = true)]
	public partial class FoCsEditor: UnityEditor.Editor
	{
		internal static Dictionary<string, RLP> RLPList = new Dictionary<string, RLP>(10);

		public enum DefaultPropertyType
		{
			NotDefault,
			Disabled,
			Hidden
		}

		internal  Dictionary<string, ORD> objectDrawers = new Dictionary<string, ORD>(1);
		protected bool                    GUIChanged { get; private set; }

		public virtual bool HideDefaultProperty
		{
			get { return true; }
		}

		public virtual bool ShowCopyPasteButtons
		{
			get { return true; }
		}

		public override bool UseDefaultMargins()
		{
			return false;
		}

		~FoCsEditor()
		{
			if(objectDrawers != null)
				objectDrawers.Clear();

			objectDrawers = null;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			GUIChanged = false;

			if(ShowCopyPasteButtons)
				DrawCopyPasteButtonsHeader();

			using(var changeCheckScope = Disposables.ChangeCheck())
			{
				using(Disposables.Indent())
				{
					var cachedGuiColor = GUI.color;

					foreach(var serializedProperty in serializedObject.Properties())
					{
						GUI.color = cachedGuiColor;
						HandleProperty(serializedProperty);
					}
				}

				if(changeCheckScope.changed)
				{
					serializedObject.ApplyModifiedProperties();
					GUIChanged = true;
				}
			}

			DoExtraDraw();

			DoBottomPadding();
		}

		protected static void DoBottomPadding()
		{
			EditorGUILayout.GetControlRect(false,2);
		}

		/// <summary>
		/// Override this in sub classes to draw extra stuff, to also have the padding after it
		/// </summary>
		protected virtual void DoExtraDraw(){}

		protected void DrawCopyPasteButtons()
		{
			EditorHelpers.CopyPastObjectButtons(serializedObject);
		}

		protected void DrawCopyPasteButtonsHeader()
		{
			EditorHelpers.CopyPastObjectButtons(serializedObject, EditorStyles.toolbar);
		}

		public virtual void OnSceneGUI() { }

		protected void HandleProperty(SerializedProperty property)
		{
			if(HideDefaultProperty)
			{
				var isDefaultScriptProperty = GetDefaultPropertyType(property);

				if(isDefaultScriptProperty == DefaultPropertyType.Hidden)
					return;

				var cachedGUIEnabled = GUI.enabled;

				if(isDefaultScriptProperty != DefaultPropertyType.NotDefault)
					GUI.enabled = false;

				DoPropertyDraw(property, isDefaultScriptProperty);

				if(isDefaultScriptProperty != DefaultPropertyType.NotDefault)
					GUI.enabled = cachedGUIEnabled;
			}
			else
				DoPropertyDraw(property);
		}

		private void DoPropertyDraw(SerializedProperty property, DefaultPropertyType defaultType = DefaultPropertyType.NotDefault)
		{
			if(!property.hasMultipleDifferentValues)
			{
				if(PropertyIsArrayAndNotString(property))
					HandleArray(property);
				else if((property.propertyType == SerializedPropertyType.ObjectReference) && (defaultType != DefaultPropertyType.Disabled))
					HandleObjectReference(property);
				else
					FoCsGUI.Layout.PropertyField(property, property.isExpanded);
			}
			else
				FoCsGUI.Layout.PropertyField(property, property.isExpanded);
		}

		private void HandleObjectReference(SerializedProperty property)
		{
			var drawer  = GetObjectDrawer(property);
			var GuiCont = new GUIContent(property.displayName);
			var height  = drawer.GetPropertyHeight(property, GuiCont);
			var rect    = FoCsGUI.Layout.GetControlRect(true, height);
			drawer.OnGUI(rect, property, GuiCont);
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
			return property.name.Equals("m_Script") && property.type.Equals("PPtr<MonoScript>") && (property.propertyType == SerializedPropertyType.ObjectReference) && property.propertyPath.Equals("m_Script");
		}

		public static bool IsPropertyHidden(SerializedProperty property)
		{
			return GetDefaultPropertyType(property) != DefaultPropertyType.NotDefault;
		}

		protected bool PropertyIsArrayAndNotString(SerializedProperty property)
		{
			return property.isArray && (property.propertyType != SerializedPropertyType.String);
		}

		public void HandleArray(SerializedProperty property)
		{
			using(Disposables.Indent(0))
			{
				var listData = GetReorderableList(property);
				var height   = listData.GetTotalHeight();
				var rect     = FoCsGUI.Layout.GetControlRect(true, height); //.ChangeX(16);
				listData.HandleDrawing(rect);
			}
		}

		public override bool RequiresConstantRepaint()
		{
#if FoCsEditor_ANIMATED
            foreach(var reorderableListProperty in reorderableLists)
            {
                if(reorderableListProperty.Value.Animate && reorderableListProperty.Value.IsExpanded.isAnimating)
                    return true;
            }
#endif
			return false;
		}

		public int FileID()
		{
			//From https://forum.unity.com/threads/how-to-get-the-local-identifier-in-file-for-scene-objects.265686/
			var inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
			int localId;

			{
				var seriObject             = new SerializedObject(target);
				var inspectorModeInfoValue = inspectorModeInfo.GetValue(seriObject, null);
				inspectorModeInfo.SetValue(seriObject, InspectorMode.Debug, null);
				var localIdProp = seriObject.FindProperty("m_LocalIdentfierInFile"); //note the misspelling
				inspectorModeInfo.SetValue(seriObject, inspectorModeInfoValue, null);
				localId = localIdProp.intValue;
			}

			return localId;
		}

		public string AssetPath()
		{
			return AssetPath(target);
		}

		public static string AssetPath(Object target)
		{
			return AssetDatabase.GetAssetPath(target);
		}

		//#region Storage
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

		public static RLP GetReorderableList(SerializedProperty property)
		{
			var id = string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.GetInstanceID(), property.propertyPath, property.name);
			RLP ret;

			if(RLPList.TryGetValue(id, out ret))
			{
				ret.Property = property;

				return ret;
			}
#if FoCsEditor_ANIMATED
				ret = new RLP(property, true, true, true, true, true);
#else
			ret = new RLP(property, true);
#endif
			RLPList.Add(id, ret);

			return ret;
		}
	}

	public class FoCsEditor<T>: FoCsEditor where T: Object
	{
		protected T Target
		{
			get { return (T)target; }
		}
	}
}
