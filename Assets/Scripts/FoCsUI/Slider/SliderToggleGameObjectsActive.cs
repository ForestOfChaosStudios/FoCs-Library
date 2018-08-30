using System.Collections.Generic;
using ForestOfChaosLib.Utilities.Enums;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Slider/Toggle GameObjects")]
	public class SliderToggleGameObjectsActive: FoCsBehaviour
	{
		public List<GameObject>  GameObjects2Toggle = new List<GameObject>();
		public SliderToggle      Toggle;
		public UnityTriggerTimes TriggerTimes = UnityTriggerTimes.OnEnable;

		private void OnEnable()
		{
			if(Toggle == null)
				Toggle = GetComponentInChildren<SliderToggle>();

			if(Toggle == null)
				return;

			Toggle.OnToggle += OnToggle;

			if(TriggerTimes == UnityTriggerTimes.OnEnable)
				OnToggle(Toggle.Toggled);
		}

		private void Start()
		{
			if(TriggerTimes == UnityTriggerTimes.Start)
				OnToggle(Toggle.Toggled);
		}

		private void OnToggle(bool val)
		{
			foreach(var go in GameObjects2Toggle)
				go.SetActive(val);
		}

		private void OnDisable()
		{
			Toggle.OnToggle -= OnToggle;
		}

		private void Reset()
		{
			Toggle = GetComponentInChildren<SliderToggle>();
		}
	}
}
