﻿using UnityEngine;
using System.Collections;

public class Actuator : Component 
{
	public Actuator (float mass) 
	{
		SetMass(mass);
	}

	public void EventInstall(Part part)
	{
		Debug.Log("middle");
		base.EventInstall(part);
	}

	public float GetRotation()
	{
		return 0.0f;
	}

	public float GetMobility()
	{
		return 0.0f;
	}

	public float GetAccuracy()
	{
		return 0.0f;
	}

	public float GetBalance()
	{
		return 0.0f;
	}
}