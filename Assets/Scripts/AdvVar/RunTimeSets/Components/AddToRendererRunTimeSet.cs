using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class AddToRendererRunTimeSet: BaseAddToRunTimeSet<Renderer, RendererRunTimeList>
	{
		[SerializeField] private Renderer _renderer;

		public Renderer Renderer
		{
			get { return _renderer ?? (_renderer = GetComponent<Renderer>()); }
			set { _renderer = value; }
		}

		public override Renderer Value => Renderer;
	}
}