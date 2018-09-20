using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForestOfChaosAdvVar;
using ForestOfChaosLibraryEditor;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosAdvVarEditor
{
	[InitializeOnLoad]
	static class AdvFolderStaticEditor
	{
		static AdvFolderStaticEditor()
		{
			AdvFolderEditor.ReInit();
		}
	}

	[CustomEditor(typeof(AdvSOFolder))]
	[CanEditMultipleObjects]
	public class AdvFolderEditor: FoCsEditor
	{
		private static SortedDictionary<AdvFolderNameAttribute, List<Type>> typeDictionary;
		private        int                                                  ActiveTab;
		private        AdvFolderNameAttribute                               ActiveTabName;
		private        bool                                                 showChildrenSettings = true;

		protected override void OnEnable()
		{
			base.OnEnable();
			Init();
		}

		public override void OnInspectorGUI()
		{
			if(serializedObject.isEditingMultipleObjects)
			{
				EditorGUILayout.HelpBox("Editing Multiple Objects Is Not Permitted!", MessageType.Warning);

				return;
			}

			EditorGUILayout.HelpBox("These options will add child assets to the current asset, this is done to help with sorting of the huge amount of Scriptable Objects this system could generate.", MessageType.Info);

			if(typeDictionary == null)
			{
				Init();
				Repaint();

				return;
			}

			DrawMenuTabs();
			DrawTypeTabs();
			DoPadding();
			DrawChildrenGUI();
		}

		public static void Init()
		{
			if(typeDictionary == null)
				typeDictionary = GetDictionaryTypes();
		}

		public static void ReInit()
		{
			typeDictionary = GetDictionaryTypes();
		}

		private void DrawChildrenGUI()
		{
			using(Disposables.Indent())
			{
				var assets = AssetDatabase.LoadAllAssetsAtPath(AssetPath());

				if(assets.Length > 1)
				{
					using(Disposables.HorizontalScope(EditorStyles.toolbar))
						showChildrenSettings = EditorGUILayout.Foldout(showChildrenSettings, $"Children [{assets.Length - 1}]");

					if(!showChildrenSettings)
						return;

					using(Disposables.VerticalScope(GUI.skin.box))
					{
						for(var i = 0; i < assets.Length; i++)
						{
							var obj = assets[i];

							if(!obj)
								continue;

							if(AssetDatabase.IsSubAsset(obj))
								DrawChildObject(obj, i);
						}
					}
				}
			}
		}

		private void DrawTypeTabs()
		{
			EditorGUILayout.LabelField("Type of Scriptable Object to add", EditorStyles.boldLabel);

			foreach(var type in typeDictionary[ActiveTabName])
				DrawAddTypeButton(type);
		}

		private void DrawMenuTabs()
		{
			EditorGUILayout.LabelField("Categories of Scriptable Objects that can be added", EditorStyles.boldLabel);
			var width    = (Screen.width / 180) + 1;
			var nameList = typeDictionary.Keys.ToList();

			if(!nameList.InRange(ActiveTab))
				ActiveTab = 0;

			for(var i = 0; i < nameList.Count; i += width)
			{
				if(!nameList.InRange(i))
					break;

				using(Disposables.HorizontalScope(EditorStyles.toolbar))
				{
					for(var j = 0; j < width; j += 1)
					{
						var index = i + j;

						if(!nameList.InRange(index))
							break;

						var key = nameList[index];

						if(ActiveTab == index)
							ActiveTabName = key;

						using(var cc = Disposables.ChangeCheck())
						{
							var @event = FoCsGUI.Layout.Toggle(key.ToggleName.SplitCamelCase(), ActiveTab == index, FoCsGUI.Styles.Unity.ToolbarButton);

							if(cc.changed && @event)
							{
								if(ActiveTab != index)
								{
									ActiveTab     = index;
									ActiveTabName = key;
									Repaint();
								}
							}
						}
					}
				}
			}
		}

		private static void DoPadding(bool  hasLabel              = true) => DoPadding(EditorGUIUtility.standardVerticalSpacing, hasLabel);
		private static void DoPadding(float height, bool hasLabel = true) => EditorGUILayout.GetControlRect(hasLabel, height);

		//TODO: add Un Parent Button
		private void DrawChildObject(Object[] assets, int index) => DrawChildObject(assets[index], index);
		//TODO: add Un Parent Button

		private void DrawChildObject(Object obj, int index)
		{
			using(Disposables.HorizontalScope())
			{
				FoCsGUI.Layout.Label($"[{index}] {obj.GetType().Name.SplitCamelCase()}", GUILayout.Width(Screen.width / 4f));

				using(var changeCheckScope = Disposables.ChangeCheck())
				{
					using(Disposables.IndentSet(0))
						obj.name = EditorGUILayout.DelayedTextField(obj.name);

					if(changeCheckScope.changed)
					{
						EditorUtility.SetDirty(target);
						AssetDatabase.ImportAsset(AssetPath(target));
					}
				}

				var event2 = FoCsGUI.Layout.Button(FoCsGUI.Styles.CrossCircle, GUILayout.Width(FoCsGUI.Styles.CrossCircle.Style.fixedWidth));

				if(event2)
				{
					if(EditorUtility.DisplayDialog("Delete Child", $"Delete {obj.name}", "Yes Delete", "No Cancel"))
					{
						DestroyImmediate(obj, true);
						EditorUtility.SetDirty(target);
						AssetDatabase.ImportAsset(AssetPath(target));
						Repaint();

						return;
					}
				}
			}

			DoPadding(1, false);
		}

		private void DrawAddTypeButton(Type type)
		{
			var @event = FoCsGUI.Layout.Button(type.Name.SplitCamelCase());

			if(@event)
			{
				SubmitStringWindow.SetUpInstance(new CreateArgs
				{
						Title                = $"Enter Name of the new {type.Name}",
						WindowTitle          = "Enter Name",
						CancelMessage        = "Cancel",
						Data                 = $"New {type.Name}",
						SubmitMessage        = $"Create new {type.Name}",
						OnSubmit             = OnCreateSubmit,
						HasAnotherButton     = true,
						SubmitAnotherMessage = $"Create new {type.Name} & Add Another",
						OnSubmitAnother      = OnCreateSubmit,
						OnCancel             = OnCreateCancel,
						target               = target,
						type                 = type
				});
			}
		}

		private static void OnCreateSubmit(SubmitStringWindow.SubmitStringArguments obj)
		{
			var args = obj as CreateArgs;

			if(args != null)
			{
				var sO = CreateInstance(args.type);
				sO.name = args.Data;
				AssetDatabase.AddObjectToAsset(sO, args.target);
				EditorUtility.SetDirty(args.target);
				AssetDatabase.ImportAsset(AssetPath(args.target));
			}
		}

		private static void OnCreateCancel(SubmitStringWindow.SubmitStringArguments obj) { }

		private static void OnRenameSubmit(SubmitStringWindow.SubmitStringArguments obj)
		{
			var args = obj as Args;

			if(args != null)
			{
				args.target.name = args.Data;
				EditorUtility.SetDirty(args.target);
				AssetDatabase.ImportAsset(AssetPath(args.target));
			}
		}

		private static void OnRenameCancel(SubmitStringWindow.SubmitStringArguments obj) { }

		private static void DrawDevOptions()
		{
			EditorGUILayout.LabelField("To Add You Own Scriptable Objects To This List, Add the ");
			EditorGUILayout.LabelField("[AdvancedFolderName(toggleName: \"Custom Types\", order: 42)]");
		}

		public static SortedDictionary<AdvFolderNameAttribute, List<Type>> GetDictionaryTypes()
		{
			var types     = ReflectionUtilities.GetTypesWith<AdvFolderNameAttribute, ScriptableObject>(false);
			var finalList = new SortedDictionary<AdvFolderNameAttribute, List<Type>>();

			foreach(var type in types)
			{
				var attribute = (AdvFolderNameAttribute)type.GetCustomAttribute(typeof(AdvFolderNameAttribute), false);

				if(finalList.ContainsKey(attribute))
				{
					if(finalList[attribute] == null)
						finalList[attribute] = new List<Type>();

					if(!finalList[attribute].Contains(type))
						finalList[attribute].Add(type);
				}
				else
					finalList.Add(attribute, new List<Type> {type});
			}

			return finalList;
		}

		private class Args: SubmitStringWindow.SubmitStringArguments
		{
			public Object target;
		}

		private class CreateArgs: Args
		{
			public Type type;
		}
	}
}