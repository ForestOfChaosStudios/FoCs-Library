using System.Collections.Generic;
using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		public class AdvancedListLayoutStorage
		{
			internal static List<AdvancedListLayoutStorage> storages = new List<AdvancedListLayoutStorage>();
			public FoCsEditor owner;

			public AdvancedListLayoutStorage()
			{
				storages.Add(this);
			}

			public AdvancedListLayoutStorage(FoCsEditor painter)
			{
				storages.Add(this);
				owner = painter;
			}

			~AdvancedListLayoutStorage()
			{
				storages.Remove(this);
			}

			internal Dictionary<string, AdvancedListLayout> ALLList = new Dictionary<string, AdvancedListLayout>(1);

			public AdvancedListLayout GetList(SerializedProperty property)
			{
				var                          id = GetId(property);
				AdvancedListLayout list;

				if(ALLList.TryGetValue(id, out list))
				{
					if(list.Property.serializedObject != null)
						list.Property = property;
					else
						list = new AdvancedListLayout(property);

					return list;
				}

				list = new AdvancedListLayout(property);
				ALLList.Add(id, list);

				if(owner != null)
					list.IsExpandingAnimBool.valueChanged.AddListener(owner.Repaint);

				return list;
			}

			public static string GetId(SerializedProperty property) => string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.GetInstanceID(), property.propertyPath, property.name);
		}
	}
}
