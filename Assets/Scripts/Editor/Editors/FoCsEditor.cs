using System;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using OR = ForestOfChaosLib.Editor.ObjectReference;

//Based off of the CustomBaseEditor available at
//https://gist.github.com/t0chas/34afd1e4c9bc28649311
namespace ForestOfChaosLib.Editor
{
	[CustomEditor(typeof(object), true, isFallback = true)]
	[CanEditMultipleObjects]
	public partial class FoCsEditor: UnityEditor.Editor, IRepaintable
	{
		internal         UnityReorderableListStorage URLPStorage;
		internal         Dictionary<string, OR>      objectDrawer           = new Dictionary<string, OR>(1);
		protected        bool                        showContextMenuButtons = true;
		protected        SortMode                    sortingMode            = SortMode.Standard;
		protected        bool                        GUIChanged { get; private set; }
		private          string                      search;
		private readonly HandlerController           Handler = new HandlerController();

		public virtual bool HideDefaultProperty
		{
			get { return true; }
		}

		public virtual bool ShowCopyPasteButtons
		{
			get { return true; }
		}

		public virtual bool AllowsModeChanging
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

			if(URLPStorage == null)
				URLPStorage = new UnityReorderableListStorage(this);

			InitContextMenu();
		}

		public override bool UseDefaultMargins()
		{
			return false;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			Handler.VerifyIPropertyLayoutHandlerArray(this);
			Handler.VerifyHandlingDictionary(serializedObject);
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

		private void NormalSortMode()
		{
			foreach(var property in serializedObject.Properties())
			{
				Handler[property].HandleProperty(property);
			}
		}

		private void AlphaSortMode(bool reverse = false)
		{
			DrawOnlyDefault();
			var list = Handler.Keys.ToList();
			list.Sort((a, b) => string.Compare(a.UID, b.UID, StringComparison.Ordinal));

			if(reverse)
				list.Reverse();

			foreach(var propName in list)
			{
				if(!propName.IsDefaultProperty)
					Handler[propName].HandleProperty(propName.Property);
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
				{
					if(property.name.ToLower().Contains(Search.ToLower()) && !IsDefaultScriptProperty(property))
						Handler[property].HandleProperty(property);
				}
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

				DrawProperty(property);

				break;
			}
		}

		protected void DrawProperty(SerializedProperty property)
		{
			Handler[property].HandleProperty(property);
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

		protected static void DoBottomPadding()
		{
			//FoCsGUI.Layout.GetControlRect(false, 0.2f);
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

				if(AllowsModeChanging)
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

		internal OR GetObjectDrawer(SerializedProperty property, FoCsEditor owner)
		{
			var id = GetUniqueStringID(property);
			OR  objDraw;

			if(objectDrawer.TryGetValue(id, out objDraw))
			{
				objDraw.Property = property;

				return objDraw;
			}

			objDraw = new OR(property, this);
			objDraw.IsReferenceOpen.valueChanged.AddListener(owner.Repaint);
			objectDrawer.Add(id, objDraw);

			return objDraw;
		}

		public enum SortMode
		{
			Standard,
			Alpha,
			ReverseAlpha,
			Search
		}

		public struct SortableSerializedProperty
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
