﻿using System;
using System.Collections.Generic;
using ForestOfChaosLib;
using ForestOfChaosLib.AdvVar;
using UnityEngine;

public class AdvTestComp : FoCsBehavior
{

	public FloatVariable Float = 10;

	private void OnEnable()
	{
		Float.OnValueChange += OnValueChange;
	}

	private void OnValueChange()
	{
		Debug.Log("Float Changed");
		Float.InternalData.ConstantValue = 17;
	}

	private void OnDisable()
	{
		Float.OnValueChange -= OnValueChange;
	}

	private void Start()
	{
		Float.Value = 5;
		Float.Value = 5;
	}
}