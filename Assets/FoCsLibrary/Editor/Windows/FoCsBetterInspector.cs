using System;
using System.Collections;
using System.Collections.Generic;
using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Extensions;
using UnityEditor;
using UEditor = UnityEditor.Editor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLibrary.Editor.Windows
{
	public class FoCsBetterInspector: FoCsWindow<FoCsBetterInspector>
	{
		private                 Vector2                     scrollPos;
		public                  List<Object>                Object           = new List<Object>();
		private                 Dictionary<Object, UEditor> ObjectsToEditors = new Dictionary<Object, UEditor>();
		private static readonly GUIContent                  Label            = new GUIContent("Add Object to window");
		private const           string                      Title            = "Better Inspector";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void Init()
		{
			GetWindow();
			Window.titleContent.text = Title;
			Window.Show();
		}

		protected override void OnGUI()
		{
			if(ObjectsToEditors.IsNullOrEmpty())
				ObjectsToEditors = new Dictionary<Object, UEditor>();

			if(Object.IsNullOrEmpty())
				Object = new List<Object>();

			using(var scroll = Disposables.ScrollViewScope(scrollPos, true, FoCsGUI.LayoutOptions.Expand(true)))
			{
				scrollPos = scroll.scrollPosition;

				using(Disposables.HorizontalScope())
				{
					foreach(var o in Object)
					{
						if(!ObjectsToEditors.ContainsKey(o))
							GenerateEditor(o);

						using(Disposables.VerticalScope(FoCsGUI.LayoutOptions.Width(500)))
							ObjectsToEditors[o].OnInspectorGUI();
					}
				}
			}

			using(var cc = Disposables.ChangeCheck())
			{
				var obj = FoCsGUI.Layout.ObjectField<Object>(null, Label, true);

				if(cc.changed)
				{
					if(obj != null)
					{
						Object.AddWithDuplicateCheck(obj);
						GenerateEditor(obj);
					}
				}
			}
		}

		private void GenerateEditor(Object obj)
		{
			if(!ObjectsToEditors.ContainsKey(obj))
				ObjectsToEditors[obj] = UEditor.CreateEditor(obj);
		}

		private void Update()
		{
			if(mouseOverWindow)
				Repaint();
		}
	}
}