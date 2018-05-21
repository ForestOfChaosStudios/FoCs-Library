namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToGameObjectListVariable: FoCsBehavior
	{
		public GameObjectListReference GameObjectListReference;

		public void OnEnable()
		{
			GameObjectListReference?.Add(gameObject);
		}

		public void OnDisable()
		{
			GameObjectListReference?.Remove(gameObject);
		}
	}
}