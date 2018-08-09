using System;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using RLP = ForestOfChaosLib.Editor.FoCsEditor.ReorderableListProperty;
using ORD = ForestOfChaosLib.Editor.PropertyDrawers.ObjectReferenceDrawer;

//Based off of the CustomBaseEditor available at
//https://gist.github.com/t0chas/34afd1e4c9bc28649311
namespace ForestOfChaosLib.Editor
{
	[CustomEditor(typeof(object), true, isFallback = true)]
	[CanEditMultipleObjects]
	public partial class FoCsEditor: UnityEditor.Editor
	{
		internal static Dictionary<string, RLP>                                        RLPList                = new Dictionary<string, RLP>(10);
		internal        Dictionary<string, ORD>                                        objectDrawers          = new Dictionary<string, ORD>(1);
		protected       bool                                                           showContextMenuButtons = true;
		protected       SortMode                                                       sortingMode            = SortMode.Standard;
		protected       bool                                                           GUIChanged { get; private set; }
		private         Dictionary<SortableSerializedProperty, IPropertyLayoutHandler> PropertyHandlingDictionary;
		private         string                                                         search;

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

		public virtual string Search
		{
			get { return search; }
			private set { EditorPrefs.SetString("FoCsEditor.search", search = value); }
		}

		public SortMode SortingMode
		{
			get { return sortingMode; }
			private set { EditorPrefs.SetInt("FoCsEditor.sortingMode", (int)(sortingMode = value)); }
		}

		private void OnEnable()
		{
			search                 = EditorPrefs.GetString("FoCsEditor.search");
			sortingMode            = (SortMode)EditorPrefs.GetInt("FoCsEditor.sortingMode");
			showContextMenuButtons = EditorPrefs.GetBool("FoCsEditor.showContextMenuButtons");
			InitContextMenu();
		}

		~FoCsEditor()
		{
			if(objectDrawers == null)
				return;

			objectDrawers.Clear();
			objectDrawers = null;
		}

		public override bool UseDefaultMargins()
		{
			return false;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			VerifyHandlingDictionary();
			GUIChanged = false;
			DoTopPadding();

			if(ShowCopyPasteButtons)
				DrawCopyPasteButtonsHeader();

			using(var changeCheckScope = Disposables.ChangeCheck())
			{
				using(Disposables.Indent())
				{
					var cachedGuiColor = GUI.color;

					switch(SortingMode)
					{
						case SortMode.Standard:
							NormalSortMode();

							break;
						case SortMode.Alpha:
							AlphaSortMode();

							break;
						case SortMode.ReverseAlpha:
							AlphaSortMode(true);

							break;
						case SortMode.Search:
							SearchSortMode();

							break;
						default: throw new ArgumentOutOfRangeException();
					}

					GUI.color = cachedGuiColor;
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

		private void NormalSortMode(bool checkForDefault = false)
		{
			foreach(var property in serializedObject.Properties())
			{
				if(checkForDefault)
				{
					if(!IsDefaultScriptProperty(property))
						PropertyHandlingDictionary[property].HandleProperty(property);
				}
				else
					PropertyHandlingDictionary[property].HandleProperty(property);
			}
		}

		private void AlphaSortMode(bool reverse = false)
		{
			DrawOnlyDefault();
			var list = PropertyHandlingDictionary.Keys.ToList();
			list.Sort((a, b) => string.Compare(a.UID, b.UID, StringComparison.Ordinal));

			if(reverse)
				list.Reverse();

			foreach(var propName in list)
			{
				if(!propName.IsDefaultProperty)
					PropertyHandlingDictionary[propName].HandleProperty(propName.Property);
			}
		}

		private void SearchSortMode()
		{
			if(search.IsNullOrEmpty())
			{
				DrawSearchBox();
				NormalSortMode();
			}
			else
			{
				DrawSearchBox();
				DrawOnlyDefault();

				foreach(var property in serializedObject.Properties())
					if(property.name.ToLower().Contains(Search.ToLower()) && !IsDefaultScriptProperty(property))
						PropertyHandlingDictionary[property].HandleProperty(property);
			}
		}

		private void DrawSearchBox()
		{
			search = FoCsGUI.Layout.TextField("Search: ", Search);
		}

		private void DrawOnlyDefault()
		{
			foreach(var property in serializedObject.Properties())
			{
				if(!IsDefaultScriptProperty(property))
					continue;

				PropertyHandlingDictionary[property].HandleProperty(property);

				break;
			}
		}

		private void VerifyHandlingDictionary()
		{
			if(PropertyHandlingDictionary != null)
				return;

			PropertyHandlingDictionary = new Dictionary<SortableSerializedProperty, IPropertyLayoutHandler>(serializedObject.VisibleProperties());

			foreach(var property in serializedObject.Properties())
				PropertyHandlingDictionary.Add(property, GetHandler(property));
		}

		public override bool RequiresConstantRepaint()
		{
			foreach(var reorderableListProperty in RLPList)
			{
				if(reorderableListProperty.Value.Animate && reorderableListProperty.Value.IsExpanded.isAnimating)
					return true;
			}

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
				DoSortButtons();
				DoContextMenuHeader();
			}
		}

		private static readonly GUIContent SortModeContent      = new GUIContent("Sort Mode", "Change the order of the properties");
		private static readonly GUIContent SortModeContentHover = new GUIContent("",          "Change the order of the properties");

		private void DoSortButtons()
		{
			using(Disposables.HorizontalScope(GUILayout.MaxWidth(Screen.width * 0.3f)))
			{
				using(var cc = Disposables.ChangeCheck())
				{
					FoCsGUI.Layout.Label(SortModeContent, GUILayout.MaxWidth(Screen.width * 0.11f));
					var mode = FoCsGUI.Layout.EnumPopup(SortModeContentHover, SortingMode, FoCsGUI.Styles.Unity.ToolbarDropDown, GUILayout.MaxWidth(Screen.width * 0.19f));

					if(cc.changed)
						SortingMode = (SortMode)mode.Value;
				}
			}
		}

		protected virtual void DoContextMenuHeader()
		{
			if(contextData.Count > 0)
				ShowContextMenuButtons = FoCsGUI.Layout.Toggle(ShowContextMenuButtons? "Hide Context Buttons" : "Show Context Buttons", ShowContextMenuButtons, FoCsGUI.Styles.Unity.ToolbarButton);
		}

		private void HandleObjectReference(SerializedProperty property)
		{
			var drawer  = GetObjectDrawers(property);
			var GuiCont = new GUIContent(property.displayName);
			var height  = drawer.GetPropertyHeight(property, GuiCont);
			var rect    = FoCsGUI.Layout.GetControlRect(true, height);
			drawer.IsExpanded.value = property.isExpanded;

			if((!drawer.IsExpanded.value && !drawer.IsExpanded.isAnimating) || (!drawer.IsExpanded.value && drawer.IsExpanded.isAnimating && (drawer.IsExpanded.faded < 0.1f)))
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

		internal ORD GetObjectDrawers(SerializedProperty property)
		{
			var id = GetUniqueStringID(property);
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
					ret = new RLP(property, true, true, true, true, true);

				return ret;
			}

			ret = new RLP(property, true, true, true, true, true);
			RLPList.Add(id, ret);

			return ret;
		}

		public IPropertyLayoutHandler GetHandler(SerializedProperty property)
		{
			if((property.propertyType == SerializedPropertyType.ObjectReference) && !IsDefaultScriptProperty(property))
				return _objectReferenceHandler ?? (_objectReferenceHandler = new ObjectReferenceHandler(this));

			if(property.isArray && (property.propertyType != SerializedPropertyType.String))
				return _listHandler ?? (_listHandler = new ListHandler(this));

			return _propertyHandler ?? (_propertyHandler = new PropertyHandler(this));
		}

		private PropertyHandler        _propertyHandler;
		private ListHandler            _listHandler;
		private ObjectReferenceHandler _objectReferenceHandler;

		public enum SortMode
		{
			Standard,
			Alpha,
			ReverseAlpha,
			Search
		}

		private struct SortableSerializedProperty
		{
			public SerializedProperty Property;
			public bool               IsDefaultProperty;

			public string UID
			{
				get { return GetUniqueStringID(Property); }
			}

			public SortableSerializedProperty(SerializedProperty property)
			{
				Property          = property;
				IsDefaultProperty = IsDefaultScriptProperty(property);
			}

			public SortableSerializedProperty(SerializedProperty property, bool isDefaultProperty)
			{
				Property          = property;
				IsDefaultProperty = isDefaultProperty;
			}

			public static implicit operator SortableSerializedProperty(SerializedProperty input)
			{
				return new SortableSerializedProperty(input);
			}

			/// <inheritdoc />
			public override bool Equals(object obj)
			{
				return obj is SortableSerializedProperty && Equals((SortableSerializedProperty)obj);
			}

			public bool Equals(SortableSerializedProperty obj)
			{
				return UID == obj.UID;
			}

			/// <inheritdoc />
			public override int GetHashCode()
			{
				return UID.GetHashCode() + 1;
			}
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
