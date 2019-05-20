using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaosAdvVar.RuntimeRef.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add Renderer RunTime Ref")]
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
