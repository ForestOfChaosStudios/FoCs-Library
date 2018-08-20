using System;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using ObjRef = ForestOfChaosLib.Editor.ObjectReference;

namespace ForestOfChaosLib.Editor
{
	[CustomEditor(typeof(object), true, isFallback = true)]
	[CanEditMultipleObjects]
	public partial class FoCsEditor: UnityEditor.Editor, IRepaintable
	{
		private static          string                      search;
		public static           List<FoCsEditorSorter>      Sorters              = new List<FoCsEditorSorter>(3);
		private static readonly GUIContent                  SortModeContent      = new GUIContent("Sort Mode", "Change the order of the properties");
		private static readonly GUIContent                  SortModeContentHover = new GUIContent("",          "Change the order of the properties");
		private readonly        HandlerController           Handler              = new HandlerController();
		internal                UnityReorderableListStorage URLPStorage;
		internal                Dictionary<string, ObjRef>  objectDrawer           = new Dictionary<string, ObjRef>(1);
		protected               bool                        showContextMenuButtons = true;
		protected               int                         sortingModeIndex;
		protected               bool                        GUIChanged           { get; private set; }
		public virtual          bool                        HideDefaultProperty  => true;
		public virtual          bool                        ShowCopyPasteButtons => true;
		public virtual          bool                        AllowsModeChanging   => true;
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
		public int SortingModeIndex
		{
			get { return sortingModeIndex; }
			private set { EditorPrefs.SetInt("FoCsEditor.sortingMode", sortingModeIndex = value); }
		}

		private void OnEnable()
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
			VerifyHandler();
			GUIChanged = false;
			DoTopPadding();
			DoDrawHeader();

			using(var changeCheckScope = Disposables.ChangeCheck())
			{
				using(Disposables.Indent())
				{
					var cachedGuiColor = GUI.color;
					var sorter         = Sorters[SortingModeIndex];
					var list           = sorter.GetPropertyOrder(serializedObject.Properties());
					sorter.DoExtraDraw();

					foreach(var serializedProperty in list)
						Handler.Handle(serializedProperty);

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

		public void VerifyHandler()
		{
			Handler.VerifyIPropertyLayoutHandlerArray(this);
			Handler.VerifyHandlingDictionary(serializedObject);
		}

		protected void DrawProperty(SerializedProperty property)
		{
			Handler.Handle(property);
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

		protected static void DoTopPadding()
		{
			FoCsGUI.Layout.GetControlRect(false, 0.3f);
		}

		/// <summary>
		///     Override this in sub classes to draw extra stuff, to also have the padding after it
		/// </summary>
		protected virtual void DoExtraDraw() { }

		protected virtual void DrawCopyPasteButtons()
		{
			EditorHelpers.CopyPastObjectButtons(serializedObject);
		}

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

		protected virtual void GetHeaderButtons(List<Action> headerButtons)
		{
			if(AllowsModeChanging)
				headerButtons.Add(DoSortButtons);

			headerButtons.Add(DoContextMenuHeader);

			if(ShowCopyPasteButtons)
				headerButtons.Add(() => EditorHelpers.CopyPastObjectButtons(serializedObject));
		}

		private void DoSortButtons()
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

		protected virtual void DoContextMenuHeader()
		{
			if(contextData.Count > 0)
				ShowContextMenuButtons = FoCsGUI.Layout.Toggle(ShowContextMenuButtons? "Hide Context Buttons" : "Show Context Buttons", ShowContextMenuButtons, FoCsGUI.Styles.Unity.ToolbarButton);
		}

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

		public static void DrawSearchBox()
		{
			search = FoCsGUI.Layout.TextField("Search: ", Search);
		}

		public static void AddSortingMode(FoCsEditorSorter foCsEditorSorter)
		{
			Sorters.AddWithDuplicateCheck(foCsEditorSorter);
		}

		public abstract class FoCsEditorSorter
		{
			public abstract GUIContent               ModeName { get; }
			public abstract List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties);
			public virtual  void                     DoExtraDraw() { }
		}

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

	public class FoCsEditor<T>: FoCsEditor where T: Object
	{
		protected T Target => (T)target;
	}
}