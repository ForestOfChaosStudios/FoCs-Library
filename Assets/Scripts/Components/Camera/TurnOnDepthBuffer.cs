using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaosLib.Components.Camera
{
	public class TurnOnDepthBuffer: FoCsBehaviour
	{
		public void Start()
		{
			UCamera.main.depthTextureMode = DepthTextureMode.Depth;
		}
	}
}