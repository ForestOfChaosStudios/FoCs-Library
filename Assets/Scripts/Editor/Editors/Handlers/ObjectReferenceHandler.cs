using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	public class ObjectReferenceHandler: IPropertyLayoutHandler
	{
		private UnityReorderableListStorage storage;
		public readonly FoCsEditor owner;

		public ObjectReferenceHandler(FoCsEditor _owner)
		{
			owner = _owner;
		}

		public ObjectReferenceHandler(UnityReorderableListStorage _URLStorage)
		{
			storage = _URLStorage;
			owner = null;
		}

		public UnityReorderableListStorage URLStorage
		{
			get { return storage ?? (storage = new UnityReorderableListStorage(owner)); }
			set { storage = value; }
		}

		public void HandleProperty(SerializedProperty property)
		{
			var drawer = owner.GetObjectDrawer(property, owner);

			using(var cc = Disposables.ChangeCheck())
			{
				drawer.IsReferenceOpen.target = drawer.ReferenceOpen;

				drawer.DrawHeader();

				using(var fade = Disposables.FadeGroupScope(drawer.IsReferenceOpen.faded))
				{
					if(fade.visible)
						drawer.DrawReference(URLStorage);
				}
				if(cc.changed)
					URLStorage.owner.Repaint();
			}
		}

		public float PropertyHeight(SerializedProperty property)
		{
			return FoCsGUI.SingleLine;
		}

		public bool IsValidProperty(SerializedProperty property) => (property.propertyType == SerializedPropertyType.ObjectReference) && !FoCsEditor.IsDefaultScriptProperty(property);
	}
}
