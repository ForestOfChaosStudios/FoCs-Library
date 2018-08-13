using System.Collections.Generic;
using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		public class UnityReorderableListStorage
		{
			internal static List<UnityReorderableListStorage> storages = new List<UnityReorderableListStorage>();
			public FoCsEditor owner;

			public UnityReorderableListStorage()
			{
				storages.Add(this);
			}

			public UnityReorderableListStorage(FoCsEditor painter)
			{
				storages.Add(this);
				owner = painter;
			}

			~UnityReorderableListStorage()
			{
				storages.Remove(this);
			}

			internal Dictionary<string, UnityReorderableListProperty> URLPList = new Dictionary<string, UnityReorderableListProperty>(1);

			public UnityReorderableListProperty GetList(SerializedProperty property)
			{
				var                          id = GetId(property);
				UnityReorderableListProperty reorderableList;

				if(URLPList.TryGetValue(id, out reorderableList))
				{
					if(reorderableList.Property.serializedObject != null)
						reorderableList.Property = property;
					else
						reorderableList = new UnityReorderableListProperty(property, true, true, true, true);

					return reorderableList;
				}

				reorderableList = new UnityReorderableListProperty(property, true, true, true, true);
				URLPList.Add(id, reorderableList);

				if(owner != null)
					reorderableList.IsExpanded.valueChanged.AddListener(owner.Repaint);

				return reorderableList;
			}

			public static string GetId(SerializedProperty property) => string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.GetInstanceID(), property.propertyPath, property.name);
		}
	}
}
