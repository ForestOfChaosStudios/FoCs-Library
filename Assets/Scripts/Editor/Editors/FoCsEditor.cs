#define FoCsEditor_ANIMATED

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using Object = UnityEngine.Object;
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

		internal  Dictionary<string, ORD> objectDrawers          = new Dictionary<string, ORD>(1);
		//internal  Dictionary<string, ObjectReference> ObjectDrawer          = new Dictionary<string, ObjectReference>(1);
		protected bool                    showContextMenuButtons = true;
		protected bool                    GUIChanged { get; private set; }

		public virtual bool HideDefaultProperty
		{
			get { return true; }
		}

		public virtual bool ShowCopyPasteButtons
		{
			get { return true; }
		}

		public virtual bool ShowContextMenuButtons
		{
			get { return showContextMenuButtons; }
			private set { EditorPrefs.SetBool("FoCsEditor.showContextMenuButtons", showContextMenuButtons = value); }
		}

		private void OnEnable()
		{
			showContextMenuButtons = EditorPrefs.GetBool("FoCsEditor.showContextMenuButtons");
			FindContextMenu();
		}

		~FoCsEditor()
		{
			if(objectDrawers != null)
			{
				objectDrawers.Clear();
				objectDrawers = null;
			}

			//if(ObjectDrawer != null)
			//{
			//	ObjectDrawer.Clear();
			//	ObjectDrawer = null;
			//}
		}

		public override bool UseDefaultMargins()
		{
			return false;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			GUIChanged = false;
			DoTopPadding();

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

			if(ShowContextMenuButtons)
				DrawContextMenuButtons();

			DoBottomPadding();
		}

		public override bool RequiresConstantRepaint()
		{
#if FoCsEditor_ANIMATED
			foreach(var reorderableListProperty in RLPList)
			{
				if(reorderableListProperty.Value.Animate && reorderableListProperty.Value.IsExpanded.isAnimating)
					return true;
			}
			//foreach(var objectDrawer in ObjectDrawer)
			//{
			//	if(objectDrawer.Value.IsExpanded.isAnimating)
			//		return true;
			//}
#endif
			return false;
		}

		protected static void DoTopPadding()
		{
			FoCsGUI.Layout.GetControlRect(false, 0.3f);
		}

		protected static void DoBottomPadding()
		{
			FoCsGUI.Layout.GetControlRect(false, 1);
		}

		/// <summary>
		///     Override this in sub classes to draw extra stuff, to also have the padding after it
		/// </summary>
		protected virtual void DoExtraDraw() { }

		protected virtual void DrawCopyPasteButtons()
		{
			EditorHelpers.CopyPastObjectButtons(serializedObject);
		}

		protected virtual void DrawCopyPasteButtonsHeader()
		{
			using(Disposables.HorizontalScope(FoCsGUI.Styles.Unity.Toolbar))
			{
				EditorHelpers.CopyPastObjectButtons(serializedObject);
				DoContextMenuHeader();
			}
		}

		protected virtual void DoContextMenuHeader()
		{
			if(contextData.Count > 0)
				ShowContextMenuButtons = FoCsGUI.Layout.Toggle(ShowContextMenuButtons? "Hide Context Buttons" : "Show Context Buttons", ShowContextMenuButtons, FoCsGUI.Styles.Unity.ToolbarButton);
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
			//var drawer = GetObjectDrawer(property);
			////if((!drawer.Foldout && !drawer.IsExpanded.isAnimating) || (!drawer.Foldout && drawer.IsExpanded.isAnimating && drawer.IsExpanded.faded < 0.1f))
			//
			//Debug.Log(drawer.IsExpanded.faded);
			//if(!drawer.Foldout)
			//	ObjectReference.Draw(drawer, ObjectReference.HeaderMode.OnlyHeader);
			//else
			//{
			//	drawer.IsExpanded.value = drawer.Foldout;
			//	ObjectReference.Draw(drawer, ObjectReference.HeaderMode.OnlyHeader);
			//	FoCsGUI.Layout.GetControlRect(false, -4f);
			//	using(var fade = Disposables.FadeGroupScope(drawer.IsExpanded.faded))
			//	{
			//		if(fade.visible)
			//		{
			//			ObjectReference.Draw(drawer, ObjectReference.HeaderMode.NoHeader);
			//		}
			//	}
			//}

			var drawer  = GetObjectDrawers(property);
			var GuiCont = new GUIContent(property.displayName);
			var height  = drawer.GetPropertyHeight(property, GuiCont);
			var rect    = FoCsGUI.Layout.GetControlRect(true, height);
			drawer.IsExpanded.value = property.isExpanded;

			if((!drawer.IsExpanded.value && !drawer.IsExpanded.isAnimating) || (!drawer.IsExpanded.value && drawer.IsExpanded.isAnimating && drawer.IsExpanded.faded < 0.1f))
				drawer.OnGUI(rect, property, GuiCont);
			else
			{
				using(var fade = Disposables.FadeGroupScope(drawer.IsExpanded.faded))
				{
					if(fade.visible)
						drawer.OnGUI(rect, property, GuiCont);
				}
			}
		}

		public void HandleArray(SerializedProperty property)
		{
			using(Disposables.SetIndent(1))
			{
				var listData = GetReorderableList(property);
				listData.HandleDrawing();
			}
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
		//protected ObjectReference GetObjectDrawer(SerializedProperty property)
		//{
		//	var id = string.Format("{0}-{1}", property.propertyPath, property.name);
		//	ObjectReference objRef;
		//
		//	if(ObjectDrawer.TryGetValue(id, out objRef))
		//		return objRef;
		//
		//	objRef = new ObjectReference {Property = property, IsExpanded = new AnimBool(property.objectReferenceValue) {speed = 0.7f}, Foldout = property.objectReferenceValue};
		//	ObjectDrawer.Add(id, objRef);
		//
		//	return objRef;
		//}

		protected ORD GetObjectDrawers(SerializedProperty property)
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
				if(ret.Property.serializedObject != null)
					ret.Property = property;
				else
				{
#if FoCsEditor_ANIMATED
					ret = new RLP(property, true, true, true, true, true);
#else
					ret = RLPList[id] = new RLP(property, true);
#endif
				}
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

#region ContextMenu Attributes
		// Based off of https://github.com/SubjectNerd-Unity/ReorderableInspector/blob/master/Editor/ReorderableArrayInspector.cs
		protected struct ContextMenuData
		{
			public string         MenuItem;
			public MethodInfo     Function;
			public MethodInfo     Validate;
			public LayoutOptions? Layout;

			public ContextMenuData(string item)
			{
				MenuItem = item;
				Function = null;
				Validate = null;
				Layout   = null;
			}

			public struct LayoutOptions
			{
				public int Row;
				public int Column;
				public int AmountPerLine;

				public LayoutOptions(int row, int column, int amountPerLine)
				{
					Row           = row;
					Column        = column;
					AmountPerLine = amountPerLine;
				}

				public LayoutOptions(ContextMenuLayoutAttribute layout)
				{
					Row           = layout.Row;
					Column        = layout.Column;
					AmountPerLine = layout.AmountPerLine;
				}
			}
		}

		protected Dictionary<string, ContextMenuData> contextData = new Dictionary<string, ContextMenuData>();

		private static IEnumerable<MethodInfo> GetAllMethods(Type t)
		{
			const BindingFlags binding = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

			return t == null? Enumerable.Empty<MethodInfo>() : t.GetMethods(binding).Concat(GetAllMethods(t.BaseType));
		}

		private static readonly Type ContextMenuType       = typeof(ContextMenu);
		private static readonly Type ContextMenuLayoutType = typeof(ContextMenuLayoutAttribute);

		private void FindContextMenu()
		{
			if(contextData == null)
				contextData = new Dictionary<string, ContextMenuData>();
			else
				contextData.Clear();

			// Get context menu
			var targetType = target.GetType();
			var methods    = GetAllMethods(targetType).ToArray();

			for(var index = 0; index < methods.GetLength(0); ++index)
			{
				var methodInfo                  = methods[index];
				var contextMenuAttributes       = methodInfo.GetCustomAttributes(ContextMenuType,       false);
				var contextMenuLayoutAttributes = methodInfo.GetCustomAttributes(ContextMenuLayoutType, false);

				for(var i = 0; i < contextMenuAttributes.Length; i++)
				{
					var contextMenu = (ContextMenu)contextMenuAttributes[i];

					if(contextMenu == null)
						continue;

					ContextMenuLayoutAttribute layout = null;

					for(var innerIndex = 0; innerIndex < contextMenuLayoutAttributes.Length; innerIndex++)
					{
						var contextMenuLayoutAttribute = (ContextMenuLayoutAttribute)contextMenuLayoutAttributes[innerIndex];

						if(contextMenuLayoutAttribute == null)
							continue;

						layout = contextMenuLayoutAttribute;

						break;
					}

					if(contextData.ContainsKey(contextMenu.menuItem))
					{
						var data = contextData[contextMenu.menuItem];

						if(contextMenu.validate)
							data.Validate = methodInfo;
						else
							data.Function = methodInfo;

						if(layout != null)
							data.Layout = new ContextMenuData.LayoutOptions(layout);

						contextData[data.MenuItem] = data;
					}
					else
					{
						var data = new ContextMenuData(contextMenu.menuItem);

						if(contextMenu.validate)
							data.Validate = methodInfo;
						else
							data.Function = methodInfo;

						if(layout != null)
							data.Layout = new ContextMenuData.LayoutOptions(layout);

						contextData.Add(data.MenuItem, data);
					}
				}
			}
		}

		public void DrawContextMenuButtons()
		{
			if(contextData.Count == 0)
				return;

			FoCsGUI.Layout.Space(4);
			FoCsGUI.Layout.LabelField("Context Menu:", FoCsGUI.Styles.Unity.BoldLabel);
			//TODO: Implement ContextMenuLayoutAttribute Logic
			var rectRows = new Dictionary<int, Rect>();

			foreach(var kv in contextData)
			{
				var enabledState = GUI.enabled;
				var isEnabled    = true;

				if(kv.Value.Validate != null)
					isEnabled = (bool)kv.Value.Validate.Invoke(target, null);

				GUI.enabled = isEnabled;

				if(kv.Value.Function != null)
				{
					if(kv.Value.Layout.HasValue)
					{
						var  layout = kv.Value.Layout.Value;
						Rect rect;

						if(rectRows.ContainsKey(layout.Column))
							rect = rectRows[layout.Column];
						else
						{
							FoCsGUI.Layout.Space();
							rect = GUILayoutUtility.GetLastRect();
							rectRows.Add(layout.Column, rect);
						}

						using(var scope = Disposables.RectHorizontalScope(layout.AmountPerLine, rect))
						{
							if(layout.Row != 0)
								scope.GetNext(layout.Row);

							if(FoCsGUI.Button(scope.GetNext(), kv.Key))
								InvokeMethod(kv);
						}
					}
					else
					{
						if(FoCsGUI.Layout.Button(kv.Key))
							InvokeMethod(kv);
					}
				}

				GUI.enabled = enabledState;
			}
		}

		private void InvokeMethod(KeyValuePair<string, ContextMenuData> kv)
		{
			kv.Value.Function.Invoke(target, null);
		}
#endregion

		public IPropertyLayoutDrawingHandler GetHandler(SerializedProperty property)
		{
			if(property.propertyType == SerializedPropertyType.ObjectReference)
				return _objectReferenceHandler ?? (_objectReferenceHandler = new ObjectReferenceHandler(this));

			if(property.isArray && (property.propertyType != SerializedPropertyType.String))
				return _listHandler ?? (_listHandler = new ListHandler(this));

			return _propertyHandler ?? (_propertyHandler = new PropertyHandler(this));
		}

		private PropertyHandler _propertyHandler;

		private class PropertyHandler: IPropertyLayoutDrawingHandler
		{
			private readonly FoCsEditor owner;

			public PropertyHandler(FoCsEditor _owner)
			{
				owner = _owner;
			}

			public void HandleProperty(SerializedProperty property)
			{
				if(owner.HideDefaultProperty)
				{
					var isDefaultScriptProperty = GetDefaultPropertyType(property);

					if(isDefaultScriptProperty == DefaultPropertyType.Hidden)
						return;

					var cachedGUIEnabled = GUI.enabled;

					if(isDefaultScriptProperty != DefaultPropertyType.NotDefault)
						GUI.enabled = false;

					FoCsGUI.Layout.PropertyField(property, property.isExpanded);

					if(isDefaultScriptProperty != DefaultPropertyType.NotDefault)
						GUI.enabled = cachedGUIEnabled;
				}
				else
					FoCsGUI.Layout.PropertyField(property, property.isExpanded);
			}

			public float PropertyHeight(SerializedProperty property)
			{
				return FoCsGUI.GetPropertyHeight(property);
			}
		}

		private ListHandler _listHandler;

		private class ListHandler: IPropertyLayoutDrawingHandler
		{
			private readonly FoCsEditor owner;

			public ListHandler(FoCsEditor _owner)
			{
				owner = _owner;
			}

			public void HandleProperty(SerializedProperty property)
			{
				var list = GetReorderableList(property);
				list.HandleDrawing();
			}

			public float PropertyHeight(SerializedProperty property)
			{
				var list = GetReorderableList(property);

				return list.GetTotalHeight();
			}
		}

		private ObjectReferenceHandler _objectReferenceHandler;

		private class ObjectReferenceHandler: IPropertyLayoutDrawingHandler
		{
			private readonly FoCsEditor owner;

			public ObjectReferenceHandler(FoCsEditor _owner)
			{
				owner = _owner;
			}

			public void HandleProperty(SerializedProperty property)
			{
				var drawer  = owner.GetObjectDrawers(property);
				var GuiCont = new GUIContent(property.displayName);
				var height  = drawer.GetPropertyHeight(property, GuiCont);
				var rect    = FoCsGUI.Layout.GetControlRect(true, height);
				drawer.OnGUI(rect, property, GuiCont);
			}

			public float PropertyHeight(SerializedProperty property)
			{
				var drawer  = owner.GetObjectDrawers(property);
				var GuiCont = new GUIContent(property.displayName);
				var height  = drawer.GetPropertyHeight(property, GuiCont);

				return height;
			}
		}

		public interface IPropertyLayoutDrawingHandler
		{
			void HandleProperty(SerializedProperty  property);
			float PropertyHeight(SerializedProperty property);
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
