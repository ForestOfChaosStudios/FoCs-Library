using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.AdvVar.Editor
{
	//TODO: look into making this editor better!!!
	[CustomEditor(typeof(AdvFolder))]
	[CanEditMultipleObjects]
	public class AdvFolderEditor: FoCsEditor
	{
		private static readonly Dictionary<string, bool> enableDictionary = new Dictionary<string, bool>();
		private static SortedDictionary<AdvFolderNameAttribute, List<Type>> typeDictionary;

		private bool showChildrenSettings = true;

		public override bool ShowCopyPasteButtons => false;

		public override void OnInspectorGUI()
		{
			if(serializedObject.isEditingMultipleObjects)
			{
				EditorGUILayout.HelpBox("Editing Multiple Objects Is Not Permitted!", MessageType.Warning);
				return;
			}

			EditorGUILayout.HelpBox("These options will add child assets to the current asset, this is done to help with sorting of the huge amount of Scriptable Objects this system could generate.",
									MessageType.Info);
			if(typeDictionary == null)
				typeDictionary = GetDictionaryTypes();
			var nameList = typeDictionary.Keys.ToList();

			for(var i = 0; i < nameList.Count; i++)
			{
				var key = nameList[i];

				bool value;

				enableDictionary.TryGetValue(key.ToggleName, out value);

				using(Disposables.Indent())
				{
					using(Disposables.VerticalScope())
					{
						using(Disposables.HorizontalScope(EditorStyles.toolbar))
						{
							var @event = FoCsGUI.Layout.Toggle(value,
														value?
															$"Hide {key.ToggleName}" :
															$" {key.ToggleName}",
														EditorStyles.toolbarButton);

						if(@event)
							value = !value;
						}
						if(value)
						{
							foreach (var type in typeDictionary[key])
									DrawAddTypeButton(type);
							DoPadding();
						}
					}
				}
				enableDictionary[key.ToggleName] = value;
			}

			{
				var assets = AssetDatabase.LoadAllAssetsAtPath(AssetPath());
				if(assets.Length > 1)
				{
					EditorGUILayout.LabelField($"Children [{assets.Length - 1}]");

					using(Disposables.VerticalScope(GUI.skin.box))
					{
						var rect = EditorGUILayout.GetControlRect(true, StandardLine, EditorStyles.toolbarButton);

						var @event = FoCsGUI.Button(rect,
													showChildrenSettings?
														"Hide Children Settings" :
														"Edit Children",
													EditorStyles.toolbarButton);

						if(@event.AsButtonLeftClick)
							showChildrenSettings = !showChildrenSettings;
						if(!showChildrenSettings)
							return;
						using(Disposables.VerticalScope())
						{
							using(Disposables.Indent())
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
			}
		}

		private static void DoPadding(bool hasLabel = true) => DoPadding(EditorGUIUtility.standardVerticalSpacing, hasLabel);

		private static void DoPadding(float height, bool hasLabel = true) => EditorGUILayout.GetControlRect(hasLabel, height);

		//TODO: add Un Parent Button
		private void DrawChildObject(Object[] assets, int index) => DrawChildObject(assets[index], index);
		//TODO: add Un Parent Button

		private void DrawChildObject(Object obj, int index)
		{
			using(Disposables.HorizontalScope())
			{
				FoCsGUI.Layout.Label($"[{index}] {obj.GetType().Name}", GUILayout.Width(Screen.width / 4f));

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

				var event2 = FoCsGUI.Layout.Button(Styles.CrossCircle, GUILayout.Width(Styles.CrossCircle.fixedWidth));
				if(event2.AsButtonLeftClick)
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
			using(Disposables.HorizontalScope())
			{
				//FoCsGUILayout.Label(type.Name, EditorStyles.toolbarButton);
				var @event = FoCsGUI.Layout.Button($"{type.Name} Add New", GUI.skin.button);
				if(@event.AsButtonLeftClick)
				{
					SubmitStringWindow.SetUpInstance(new CreateArgs
													 {
														 Title = $"Enter Name of the new {type.Name}",
														 WindowTitle = "Enter Name",
														 CancelMessage = "Cancel",
														 Data = $"New {type.Name}",
														 SubmitMessage = $"Create new {type.Name}",
														 OnSubmit = OnCreateSubmit,
														 SubmitAnotherMessage = $"Create new {type.Name} & Add Another",
														 OnSubmitAnother = OnCreateSubmit,
														 OnCancel = OnCreateCancel,
														 target = target,
														 type = type
													 });
				}
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

		private static void OnCreateCancel(SubmitStringWindow.SubmitStringArguments obj)
		{ }

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

		private static void OnRenameCancel(SubmitStringWindow.SubmitStringArguments obj)
		{ }

		private static void DrawDevOptions()
		{
			EditorGUILayout.LabelField("To Add You Own Scriptable Objects To This List, Add the ");
			EditorGUILayout.LabelField("[AdvancedFolderName(toggleName: \"Custom Types\", order: 42)]");
		}

		public static SortedDictionary<AdvFolderNameAttribute, List<Type>> GetDictionaryTypes()
		{
			var types = GetTypesWith<AdvFolderNameAttribute, ScriptableObject>(false);

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
				{
					finalList.Add(attribute,
								  new List<Type>
								  {
									  type
								  });
				}
			}
			return finalList;
		}

		private static List<Type> GetTypesWith<TAttribute>(bool inherit)
			where TAttribute: Attribute
		{
			var list = new List<Type>();
			foreach(var t in typeof(TAttribute).Assembly.GetTypes())
			{
				if(t.IsDefined(typeof(TAttribute), inherit))
					list.Add(t);
			}
			return list;
		}

		private static List<Type> GetTypesWith<TAttribute, TInherit>(bool inherit)
			where TAttribute: Attribute
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();

			var list = new List<Type>();

			foreach(var assembly in assembliesList)
			{
				foreach(var t in assembly.GetTypes())
				{
					if(t.IsDefined(typeof(TAttribute), inherit) && t.IsSubclassOf(typeof(TInherit)))
						list.Add(t);
				}
			}
			return list;
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