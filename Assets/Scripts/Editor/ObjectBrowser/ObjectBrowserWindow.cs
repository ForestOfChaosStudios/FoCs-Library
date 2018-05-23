using System;
using System.Collections.Generic;
using System.Text;
using ForestOfChaosLib.Editor.Windows;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.Editor.ObjectBrowser
{
	[FoCsWindow]
	public class ObjectBrowserWindow: FoCsWindow<ObjectBrowserWindow>
	{
		private const string TITLE = "Object Browser";

		[MenuItem("Forest Of Chaos/" + TITLE)]
		private static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = TITLE;
		}

		private const float TYPE_WIDTH = 250;
		private Vector2 typeScrollPos = Vector2.zero;

		private static List<Type> TypeList;
		private static int activeIndex = 0;
		private static string search = "";

		public static Type ActiveType
		{
			get
			{
				return TypeList[activeIndex];
			}
			set { activeIndex = TypeList.IndexOf(value); }
		}

		private static string Search
		{
			get { return search; }
			set { EditorPrefs.SetString("FoCsOB.Search", search = value); }
		}

		private List<Object> FoundSceneObjects = new List<Object>();
		private List<Object> FoundAssetsObjects = new List<Object>();

		private void OnEnable()
		{
			Search = EditorPrefs.GetString("FoCsOB.Search");
			TypeList = ReflectionUtilities.GetInheritedClasses<ScriptableObject>();
			TypeList.AddRange(ReflectionUtilities.GetInheritedClasses<MonoBehaviour>());

			for(var i = TypeList.Count - 1; i >= 0; i--)
			{
				if(TypeList[i].IsGenericType ||
				   TypeList[i].IsAbstract ||
				   TypeList[i].Assembly == typeof(EditorWindow).Assembly ||
				   TypeList[i].IsSubclassOf(typeof(UnityEditor.Editor)) ||
				   TypeList[i].IsSubclassOf(typeof(EditorWindow)))
					TypeList.RemoveAt(i);
			}
			TypeList.TrimExcess();
		}

		protected override void OnGUI()
		{
			using(FoCsEditor.Disposables.HorizontalScope())
			{
				using(FoCsEditor.Disposables.VerticalScope(GUILayout.Width(TYPE_WIDTH)))
					DrawTypePanel();
				using(FoCsEditor.Disposables.VerticalScope())
					DrawObjectPanel();
			}
		}

		private void DrawTypePanel()
		{
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
				FoCsGUI.Layout.Label("Type Selection", FoCsGUI.Styles.ToolbarButton);

			using(var scroll = FoCsEditor.Disposables.ScrollViewScope(typeScrollPos, true, false, true))
			{
				for(var i = 0; i < TypeList.Count; i++)
				{
					if(Search.IsNullOrEmpty())
					{
						var @event = FoCsGUI.Layout.Toggle(activeIndex == i, TypeList[i].Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton, GUILayout.ExpandWidth(true));
						TypePressed(i, @event);
					}
					else
					{
						if (!TypeList[i].Name.ToLower().Contains(Search.ToLower()))
							continue;
						var @event = FoCsGUI.Layout.Toggle(activeIndex == i, TypeList[i].Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton, GUILayout.ExpandWidth(true));
						TypePressed(i, @event);
					}
					typeScrollPos = scroll.scrollPosition;
				}
			}
			DrawSearchBox();
		}

		private void TypePressed(int i, FoCsGUI.GUIEvent<bool> @event)
		{
			if (@event.Pressed)
			{
				activeIndex = i;
				ChangeObjectType();
			}
		}

		private void DrawSearchBox()
		{
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, GUILayout.ExpandWidth(true)))
			{
				FoCsGUI.Layout.Label("Search", GUILayout.Width(60));
				using(var cc = FoCsEditor.Disposables.ChangeCheck())
				{
					var str = FoCsGUI.Layout.TextField(Search, FoCsGUI.Styles.Unity.ToolbarTextField, GUILayout.ExpandWidth(true));
					if(!cc.changed)
						return;
					Search = str;
					Repaint();
				}
			}
		}

		private void DrawObjectPanel()
		{
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
				FoCsGUI.Layout.Label(TypeList[activeIndex].Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton);
			using(FoCsEditor.Disposables.HorizontalScope(GUILayout.ExpandHeight(true)))
			{
				using (FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
				{
					using (FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
						FoCsGUI.Layout.Label("Scene Objects", FoCsGUI.Styles.ToolbarButton);
					if (FoundSceneObjects.Count == 0)
					{
						FoCsGUI.Layout.InfoBox($"No Objects of {ActiveType.Name} In scene.");
					}
					else
					{
						foreach (var foundObject in FoundSceneObjects)
							DrawFoundObject(foundObject);
					}
				}
				DrawDivide();
				using (FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
				{
					using (FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
						FoCsGUI.Layout.Label("Asset Library Objects", FoCsGUI.Styles.ToolbarButton);
					if(FoundAssetsObjects.Count == 0)
					{
						FoCsGUI.Layout.InfoBox($"No Objects of {ActiveType.Name}. Can be found in the Assets Database.");
					}
					else
					{
						foreach(var foundObject in FoundAssetsObjects)
							DrawFoundObject(foundObject);
					}
				}
			}
			DrawInfo();
		}

		private static void DrawDivide()
		{
			using (FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true), GUILayout.Width(3)))
			{
				using (FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
					FoCsGUI.Layout.Label("", FoCsGUI.Styles.Toolbar);
				using (FoCsEditor.Disposables.ColorChanger(Color.gray))
				{
					using (FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, GUILayout.ExpandHeight(true)))
					{
						FoCsGUI.Layout.Label("");
					}
				}
			}
		}

		private static void DrawFoundObject(Object foundObject)
		{
			using(FoCsEditor.Disposables.HorizontalScope())
			{
				FoCsGUI.Layout.Label(foundObject.name);
				var eventPingButton = FoCsGUI.Layout.Button(FoCsGUI.Styles.Find, GUILayout.Width(16));
				FoCsGUI.Layout.Label("  ", GUILayout.Width(8));
				if(eventPingButton.Pressed)
					EditorGUIUtility.PingObject(foundObject);
			}
		}

		private void Update()
		{
			if(mouseOverWindow)
				Repaint();
		}

		private static void DrawInfo()
		{
			using(FoCsEditor.Disposables.VerticalScope())
			{
				using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
					FoCsGUI.Layout.Label("Type Info", FoCsGUI.Styles.ToolbarButton);
				using(FoCsEditor.Disposables.HorizontalScope())
				{
					FoCsGUI.Layout.Label("Assembly:");
					FoCsGUI.Layout.Label(TypeList[activeIndex].Assembly.GetName().Name);
				}
				using(FoCsEditor.Disposables.HorizontalScope())
				{
					var baseType = TypeList[activeIndex].BaseType;
					if(baseType != null)
					{
						FoCsGUI.Layout.Label("Inherits from:");

						if(baseType.IsGenericType)
						{
							var genArg = new StringBuilder();
							genArg.Append('<');
							var genArgArray = baseType.GetGenericArguments();
							for(var i = 0; i < genArgArray.Length; i++)
							{
								if(i != 0)
									genArg.Append(',');
								genArg.Append(genArgArray[i].Name);
							}
							genArg.Append('>');
							FoCsGUI.Layout.Label($"{TypeList[activeIndex].BaseType.Name.Replace("`1", "")}{genArg}");
						}
						else
						{
							FoCsGUI.Layout.Label(TypeList[activeIndex].BaseType.Name.SplitCamelCase());
						}
					}
				}
			}
		}

		private void ChangeObjectType()
		{
			SceneObjectChange();
			AssetsObjectsChange();
		}

		private void AssetsObjectsChange()
		{
			if(FoundAssetsObjects == null)
				FoundAssetsObjects = new List<Object>();
			else
				FoundAssetsObjects.Clear();
			FoundAssetsObjects.AddRange(Resources.FindObjectsOfTypeAll(ActiveType));
			for(var i = FoundAssetsObjects.Count - 1; i >= 0; i--)
			{
				if(!AssetDatabase.Contains(FoundAssetsObjects[i]))
				{
					FoundSceneObjects.Add(FoundAssetsObjects[i]);
					FoundAssetsObjects.RemoveAt(i);
				}
			}

			FoundAssetsObjects.TrimExcess();
			FoundSceneObjects.TrimExcess();
		}

		private void SceneObjectChange()
		{
			if (FoundSceneObjects == null)
				FoundSceneObjects = new List<Object>();
			else
				FoundSceneObjects.Clear();
			//FoundSceneObjects.AddRange(FindObjectsOfType(ActiveType));
		}
	}
}
