using UnityEngine;

namespace ForestOfChaosLib.GamePhysics
{
	public class GameSpeed
	{
		public enum SetSpeeds
		{
			PAUSED,
			HALF_SPEED,
			ONExSPEED,
			TWOxSPEED,
			THREExSPEED,
			FOURxSPEED,
			FIVExTIMES,
			TENxSPEED,
			TWENTYxSPEED
		}

		public float CurrentGameSpeed
		{
			get { return Time.timeScale; }
			set { Time.timeScale = value; }
		}

		public void ResetGameSpeed()
		{
			CurrentGameSpeed = ONExSPEED;
		}

		public void SetGameSpeed(float newSpeed = 1f)
		{
			CurrentGameSpeed = newSpeed;
		}

		public void SetGameSpeed(int newSpeed = 1)
		{
			CurrentGameSpeed = newSpeed;
		}

		public void SetGameSpeed(SetSpeeds newSpeed = SetSpeeds.ONExSPEED)
		{
			switch(newSpeed)
			{
				case SetSpeeds.PAUSED:
					CurrentGameSpeed = PAUSED;

					break;
				case SetSpeeds.HALF_SPEED:
					CurrentGameSpeed = HALF_SPEED;

					break;
				case SetSpeeds.ONExSPEED:
					CurrentGameSpeed = ONExSPEED;

					break;
				case SetSpeeds.TWOxSPEED:
					CurrentGameSpeed = TWOxSPEED;

					break;
				case SetSpeeds.THREExSPEED:
					CurrentGameSpeed = THREExSPEED;

					break;
				case SetSpeeds.FOURxSPEED:
					CurrentGameSpeed = FOURxSPEED;

					break;
				case SetSpeeds.FIVExTIMES:
					CurrentGameSpeed = FIVExTIMES;

					break;
				case SetSpeeds.TENxSPEED:
					CurrentGameSpeed = TENxSPEED;

					break;
				case SetSpeeds.TWENTYxSPEED:
					CurrentGameSpeed = TWENTYxSPEED;

					break;
			}
		}

#region Consts
		public const float PAUSED       = 0f;
		public const float HALF_SPEED   = 0.5f;
		public const float ONExSPEED    = 1f;
		public const float TWOxSPEED    = 2f;
		public const float THREExSPEED  = 3f;
		public const float FOURxSPEED   = 4f;
		public const float FIVExTIMES   = 5f;
		public const float TENxSPEED    = 10f;
		public const float TWENTYxSPEED = 20f;
#endregion

	}
}