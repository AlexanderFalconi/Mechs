﻿using UnityEngine;
using System.Collections;

public class M1ArmActuator : Actuator 
{
	public string Short = "Mark-1 Arm Actuator";
	public string Long = "A MechTech Mark-1 arm actuator. It runs along the entire length of the arm and benefits any attached weaponry with a large firing arc.";
	public string[] Compatibility = new string[] {"left arm", "right arm"};

	public M1ArmActuator(float mass) : base(mass)
	{

	}

	public float GetAccuracy()
	{
		return GetMass() * 0.35f;
	}

	public float GetRotation()
	{
		return GetMass() * 0.15f;
	}

	public void EventInstall(Part part)
	{
		base.EventInstall(part);
		Installed.Master.UpdateActuators();
	}

	public void EventUninstall()
	{
		Installed.Master.UpdateActuators();
		base.EventUninstall();
	}
}
