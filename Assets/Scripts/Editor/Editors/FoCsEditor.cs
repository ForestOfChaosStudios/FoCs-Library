using System;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using ObjRef = ForestOfChaosLib.Editor.ObjectReference;
using SerializedProperty = UnityEditor.SerializedProperty;

namespace ForestOfChaosLib.Editor
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(object), true, isFallback = true)]
	public partial class FoCsEditor: UnityEditor.Editor, IRepaintable
	{
		private static          string                      search;
		public static           List<FoCsEditorSorter>      Sorters              = new List<FoCsEditorSorter>(3);
		private static readonly GUIContent                  SortModeContent      = new GUIContent("Sort Mode", "Change the order of the properties");
		private static readonly GUIContent                  SortModeContentHover = new GUIContent("",          "Change the order of the properties");
		private readonly        HandlerController           Handler              = new HandlerController();
		internal                UnityReorderableListStorage URLPStorage;
		internal                Dictionary<string, ObjRef>  objectDrawer           = new Dictionary<string, ObjRef>(1);
		private                 bool                        showContextMenuButtons = true;
		private                 int                         sortingModeIndex;
		protected               bool                        GUIChanged                { get; private set; }
		public virtual          bool                        HideDefaultProperty       => true;
		public virtual          bool                        ShowCopyPasteButtons      => true;
		public virtual          bool                        AllowsSortingModeChanging => true;
		public virtual bool ShowContextMenuButtons
		{
			get { return showContextMenuButtons; }
			private set { EditorPrefs.SetBool("FoCsEditor.showContextMenuButtons", showContextMenuButtons = value); }
		}
		public static string Search
		{
			get { return search; }
			private set { EditorPrefs.SetString("FoCsEditor.search", search = value); }
		}
		public virtual int SortingModeIndex
		{
			get { return sortingModeIndex; }
			private set { EditorPrefs.SetInt("FoCsEditor.sortingMode", sortingModeIndex = value); }
		}

		/// <summary>
		/// If you override this, either do base.OnEnable(), or check if a feature is initiated if you don't
		/// </summary>
		protected virtual void OnEnable()
		{
			search                 = EditorPrefs.GetString("FoCsEditor.search");
			sortingModeIndex       = EditorPrefs.GetInt("FoCsEditor.sortingMode");
			showContextMenuButtons = EditorPrefs.GetBool("FoCsEditor.showContextMenuButtons");

			if(URLPStorage == null)
				URLPStorage = new UnityReorderableListStorage(this);

			InitContextMenu();
		}

		public override bool UseDefaultMargins() => false;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			GUIChanged = false;
			VerifyHandler();

			using(var changeCheckScope = Disposables.ChangeCheck())
			{
				using(Disposables.Indent())
				{
					DoTopPadding();
					DoDrawHeader();

					var                      cachedGuiColor = GUI.color;
					List<SerializedProperty> list;

					if(AllowsSortingModeChanging)
					{
						var sorter = Sorters[SortingModeIndex];
						list = sorter.GetPropertyOrder(serializedObject.Properties());
						sorter.DoExtraDraw();
					}
					else
						list = NormalSorter.Instance.GetPropertyOrder(serializedObject.Properties());

					foreach(var serializedProperty in list)
						DrawProperty(serializedProperty);

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
		}

		public override bool RequiresConstantRepaint()
		{
			foreach(var property in serializedObject.Properties())
			{
				if(!property.isArray)
					continue;

				var reorderableListProperty = URLPStorage.GetList(property);

				if(reorderableListProperty.IsExpanded.isAnimating)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Verify the internal data of the HandlerController
		/// </summary>
		public void VerifyHandler()
		{
			Handler.VerifyIPropertyLayoutHandlerArray(this);
			Handler.VerifyHandlingDictionary(serializedObject);
		}

		/// <summary>
		/// Draw property using <see cref="Handler"/>.Handle(property)
		/// </summary>
		/// <param name="property">Property to draw</param>
		protected void DrawProperty(SerializedProperty property)
		{
			Handler.Handle(property);
		}

		/// <summary>
		/// Draw top padding space
		/// </summary>
		protected static void DoTopPadding()
		{
			FoCsGUI.Layout.GetControlRect(false, 0.3f);
		}

		/// <summary>
		///     Override this in sub classes to draw extra stuff, to also have the padding after it
		/// </summary>
		protected virtual void DoExtraDraw() { }

		/// <summary>
		/// Draw Copy & Paste buttons
		/// </summary>
		protected virtual void DrawCopyPasteButtons()
		{
			EditorHelpers.CopyPastObjectButtons(serializedObject);
		}

		/// <summary>
		/// Draws heading buttons based of off what gets returned by GetHeaderButtons
		/// </summary>
		protected virtual void DoDrawHeader()
		{
			var headerButtons = new List<Action>();
			GetHeaderButtons(headerButtons);

			if(headerButtons.IsNullOrEmpty())
				return;

			using(Disposables.HorizontalScope(FoCsGUI.Styles.Unity.Toolbar))
			{
				foreach(var headerButton in headerButtons)
					headerButton.Trigger();
			}
		}

		/// <summary>
		/// Get header button drawing methods, return 0 or null for no heading
		/// </summary>
		/// <param name="headerButtons">value passed so that inherited classes can add more</param>
		protected virtual void GetHeaderButtons(List<Action> headerButtons)
		{
			if(AllowsSortingModeChanging)
				headerButtons.Add(DoSortButtons);

			headerButtons.Add(DoContextMenuHeader);

			if(ShowCopyPasteButtons)
				headerButtons.Add(() => EditorHelpers.CopyPastObjectButtons(serializedObject));
		}

		/// <summary>
		/// Draws the Sorting mode options
		/// </summary>
		protected void DoSortButtons()
		{
			using(Disposables.HorizontalScope(GUILayout.MaxWidth(Screen.width * 0.3f)))
			{
				using(var cc = Disposables.ChangeCheck())
				{
					FoCsGUI.Layout.Label(SortModeContent, GUILayout.MaxWidth(Screen.width * 0.11f));
					var mode = FoCsGUI.Layout.Popup(SortModeContentHover, SortingModeIndex, Sorters.Select(a => a.ModeName).ToArray(), FoCsGUI.Styles.Unity.ToolbarDropDown, GUILayout.MaxWidth(Screen.width * 0.19f)).Value;

					if(cc.changed)
						SortingModeIndex = mode;
				}
			}
		}

		/// <summary>
		/// Draw Context toggle header menu
		/// </summary>
		protected virtual void DoContextMenuHeader()
		{
			if(contextData.Count > 0)
				ShowContextMenuButtons = FoCsGUI.Layout.Toggle(ShowContextMenuButtons? "Hide Context Buttons" : "Show Context Buttons", ShowContextMenuButtons, FoCsGUI.Styles.Unity.ToolbarButton);
		}

		/// <summary>
		/// Get the Object Reference drawer from the passed property
		/// </summary>
		/// <param name="property">Property to be drawing, and the index of</param>
		/// <param name="owner">The editor currently drawing the list</param>
		/// <returns>The object reference drawer class</returns>
		internal ObjRef GetObjectDrawer(SerializedProperty property, FoCsEditor owner)
		{
			var    id = GetUniqueStringID(property);
			ObjRef objDraw;

			if(objectDrawer.TryGetValue(id, out objDraw))
			{
				objDraw.Property = property;

				return objDraw;
			}

			objDraw = new ObjRef(property, this);
			objDraw.IsReferenceOpen.valueChanged.AddListener(owner.Repaint);
			objectDrawer.Add(id, objDraw);

			return objDraw;
		}

		/// <summary>
		/// Draws all of the default properties
		/// </summary>
		private void DrawOnlyDefault()
		{
			foreach(var property in serializedObject.Properties())
			{
				if(!IsDefaultScriptProperty(property))
					continue;

				DrawProperty(property);

				break;
			}
		}

		/// <summary>
		/// Draw the search box
		/// </summary>
		public static void DrawSearchBox()
		{
			search = FoCsGUI.Layout.TextField("Search: ", Search);
		}

		/// <summary>
		/// Adds custom sorting modes, for extra usability
		/// </summary>
		/// <param name="foCsEditorSorter"></param>
		public static void AddSortingMode(FoCsEditorSorter foCsEditorSorter)
		{
			Sorters.AddWithDuplicateCheck(foCsEditorSorter);
		}

		public List<SerializedProperty> GetDefaultProperties()
		{
			var rtnVal = new List<SerializedProperty>();

			foreach(var property in serializedObject.Properties())
			{
				if(IsDefaultScriptProperty(property))
					rtnVal.Add(property);
			}

			return rtnVal;
		}

		/// <summary>
		/// Get a list of all Default properties
		/// </summary>
		/// <param name="serializedObject">Object from where the properties are from</param>
		/// <returns>Default properties list</returns>
		public static List<SerializedProperty> GetDefaultProperties(SerializedObject serializedObject)
		{
			var rtnVal = new List<SerializedProperty>();

			foreach(var property in serializedObject.Properties())
			{
				if(IsDefaultScriptProperty(property))
					rtnVal.Add(property);
			}

			return rtnVal;
		}

		/// <summary>
		/// Removes any "Default" properties from the list.
		/// </summary>
		/// <param name="list">List to remove "Default" properties</param>
		public static void RemoveDefaultProperties(List<SerializedProperty> list)
		{
			for(var i = list.Count - 1; i >= 0; i--)
			{
				if(IsDefaultScriptProperty(list[i]))
					list.RemoveAt(i);
			}
		}

		/// <summary>
		/// The base class that any Sorting mode inherits from
		/// </summary>
		public abstract class FoCsEditorSorter
		{
			/// <summary>
			/// How the mode will be displayed in the drop down list
			/// </summary>
			public abstract GUIContent ModeName { get; }

			/// <summary>
			/// Returns a list of the properties to draw, and in what order to draw them
			/// </summary>
			/// <param name="properties">The properties of the SerializedObject</param>
			/// <returns>A Sorted and Ordered List</returns>
			public abstract List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties);

			/// <summary>
			/// Used to draw any controls before the properties are drawn
			/// </summary>
			public virtual void DoExtraDraw() { }
		}

		/// <summary>
		/// A custom way of sorting SerializedProperty
		/// </summary>
		public struct SortableSerializedProperty
		{
			public SerializedProperty Property;
			public bool               IsDefaultProperty;
			public string             UID => GetUniqueStringID(Property);

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

			public static implicit operator SortableSerializedProperty(SerializedProperty input) => new SortableSerializedProperty(input);
			public override                 bool Equals(object                            obj)   => obj is SortableSerializedProperty && Equals((SortableSerializedProperty)obj);
			public                          bool Equals(SortableSerializedProperty        obj)   => UID == obj.UID;
			public override                 int  GetHashCode()                                   => UID.GetHashCode() + 1;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T">Type of <see cref="UnityEngine.Object"/> that the target serializedObject</typeparam>
	public class FoCsEditor<T>: FoCsEditor where T: Object
	{
		protected T Target => (T)target;
	}
}