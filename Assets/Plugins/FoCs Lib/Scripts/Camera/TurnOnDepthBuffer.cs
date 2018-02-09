using ForestOfChaosLib.Interfaces;
using ForestOfChaosLib.Components;
using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaosLib.Camera
{
	public class TurnOnDepthBuffer: FoCsBehavior, IStart
	{
		public void Start()
		{
			UCamera.main.depthTextureMode = DepthTextureMode.Depth;
		}
	}
}