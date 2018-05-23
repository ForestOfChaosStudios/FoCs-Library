using System;
using System.Collections.Generic;
using System.Text;
using ForestOfChaosLib.Editor;
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

		private List<Type> TypeList;
		private int activeIndex = 0;
		private string search = "";

		private List<Object> FoundObjects = new List<Object>();

		private void OnEnable()
		{
			TypeList = ReflectionUtilities.GetInheritedClasses<ScriptableObject>();
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

			using(var scroll = FoCsEditor.Disposables.ScrollViewScope(typeScrollPos, true))
			{
				for(var i = 0; i < TypeList.Count; i++)
				{
					if(search.IsNullOrEmpty())
					{
						var @event = FoCsGUI.Layout.Toggle(activeIndex == i, TypeList[i].Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton);
						if(@event.Pressed)
							activeIndex = i;
						ChangeObjectType();
					}
					else
					{
						if(!TypeList[i].Name.ToLower().Contains(search.ToLower()))
							continue;
						var @event = FoCsGUI.Layout.Toggle(activeIndex == i, TypeList[i].Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton);
						if(@event.Pressed)
							activeIndex = i;
					}
				}
				typeScrollPos = scroll.scrollPosition;
			}
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, GUILayout.ExpandWidth(true)))
			{
				FoCsGUI.Layout.Label("Search", GUILayout.Width(60));
				search = FoCsGUI.Layout.TextField(search, FoCsGUI.Styles.UnitySkins.ToolbarTextField, GUILayout.ExpandWidth(true));
			}
		}

		private void DrawObjectPanel()
		{
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
				FoCsGUI.Layout.Label(TypeList[activeIndex].Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton);
			using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
			{ }
			DrawInfo();
		}

		private void DrawInfo()
		{
			using(FoCsEditor.Disposables.VerticalScope(FoCsGUI.Styles.UnitySkins.Box))
			{
				FoCsGUI.Layout.Label("Type Info", FoCsGUI.Styles.UnitySkins.BoldLabel);
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
							//CopyPasteUtility.CopyBuffer = TypeList[activeIndex].BaseType.Name;
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
		{ }
	}
}