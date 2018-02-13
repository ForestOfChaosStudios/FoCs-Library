using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.CSharpExtensions;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.UnityScriptsExtensions;
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
		private bool foldout;

		public override bool ShowCopyPasteButtons => false;

		public override void DrawGUI()
		{
			if(serializedObject.isEditingMultipleObjects)
			{
				EditorGUILayout.HelpBox("Editing Multiple Objects Is Not Permitted!", MessageType.Warning);
				return;
			}

			EditorGUILayout.HelpBox("These options will add child assets to the current asset, this is done to help with sorting of the huge amount of Scriptable Objects this system could generate.",
									MessageType.Info);

			var dictionary = GetDictionaryTypes();
			var nameList = dictionary.Keys.ToList();

			for(var i = 0; i < nameList.Count; i++)
			{
				var key = nameList[i];

				var value = true;

				enableDictionary.TryGetValue(key.ToggleName, out value);

				using(EditorDisposables.VerticalScope())
				{
					var area = EditorGUILayout.GetControlRect(true, StandardLine);
					var @event = FoCsGUI.Toggle(area,
												value,
												value?
													$"Hide {key.ToggleName}" :
													$" {key.ToggleName}",
												EditorStyles.toolbarButton);

					if(@event)
						value = !value;
					if(value)
					{
						foreach(var type in dictionary[key])
							DrawAddTypeButton(type);
						EditorGUILayout.GetControlRect(true, EditorGUIUtility.standardVerticalSpacing);
					}
				}
				enableDictionary[key.ToggleName] = value;
			}

			{
				var assets = AssetDatabase.LoadAllAssetsAtPath(AssetPath());
				if(assets.Length > 1)
				{
					EditorGUILayout.LabelField($"Children [{assets.Length - 1}]");

					using(EditorDisposables.VerticalScope(GUI.skin.box))
					{
						var rect = EditorGUILayout.GetControlRect(true, StandardLine, EditorStyles.toolbarButton);

						var @event = FoCsGUI.Button(rect,
													foldout?
														"Hide Children Settings" :
														"Edit Children",
													EditorStyles.toolbarButton);

						if(@event.AsButtonLeftClick)
							foldout = !foldout;
						if(foldout)
						{
							using(EditorDisposables.VerticalScope())
							{
								using(EditorDisposables.Indent())
								{
									for(var i = assets.Length - 1; i >= 0; i--)
									{
										var obj = assets[i];
										if(obj)
										{
											if(AssetDatabase.IsSubAsset(obj))
												DrawChildObject(assets, i);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void DrawChildObject(Object[] assets, int index)
		{
			var obj = assets[index];

			using(EditorDisposables.HorizontalScope())
			{
				using(EditorDisposables.Indent(-1))
				{
					using(var changeCheckScope = EditorDisposables.ChangeCheck())
					{
						obj.name = EditorGUILayout.DelayedTextField(obj.name);

						if(changeCheckScope.changed)
						{
							EditorUtility.SetDirty(target);
							AssetDatabase.ImportAsset(AssetPath(target));
						}
					}
				}

				var event2 = FoCsGUILayout.Button(FoCsGUIStyles.CrossCircle);
				if(event2.AsButtonLeftClick)
				{
					if(EditorUtility.DisplayDialog("Delete Child", $"Delete {obj.name}", "Yes Delete", "No Cancel"))
					{
						DestroyImmediate(obj, true);
						EditorUtility.SetDirty(target);
						AssetDatabase.ImportAsset(AssetPath(target));
					}
				}
			}
		}

		private void DrawAddTypeButton(Type type)
		{
			var rect = EditorGUILayout.GetControlRect();
			var labelRect = rect.SetWidth(EditorGUIUtility.labelWidth);
			var buttonRect = rect.SetWidth(rect.width - labelRect.width).MoveX(EditorGUIUtility.labelWidth);

			EditorGUI.LabelField(labelRect, type.Name);
			var @event = FoCsGUI.Button(buttonRect, "Add New");
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
													 OnCancel = OnCreateCancel,
													 target = target,
													 type = type
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

		private void DrawDevOptions()
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