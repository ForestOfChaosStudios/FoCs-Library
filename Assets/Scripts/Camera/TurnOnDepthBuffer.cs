using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaosLib.Camera
{
	public class TurnOnDepthBuffer: FoCsBehavior
	{
		public void Start()
		{
			UCamera.main.depthTextureMode = DepthTextureMode.Depth;
		}
	}
}