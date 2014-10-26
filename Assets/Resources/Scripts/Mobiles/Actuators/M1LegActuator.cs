using UnityEngine;
using System.Collections;

public class M1LegActuator : Actuator 
{
	public string Short = "Mark-1 Leg Actuator";
	public string Long = "A MechTech Mark-1 leg actuator. It runs along the entire length of a leg and facilitates locomotion.";
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public float GetLocomotion()
	{
		return GetMass() * 0.50f;
	}

	public void EventInstall()
	{
		Installed.Master.UpdateActuators();
		base.EventInstall();
	}

	public void EventUninstall()
	{
		Installed.Master.UpdateActuators();
		base.EventInstall();
	}
}
