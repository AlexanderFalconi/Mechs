using UnityEngine;
using System.Collections;

public class M1FootActuator : Actuator 
{
	public string Short = "Mark-1 Foot Actuator";
	public string Long = "A MechTech Mark-1 foot actuator. It attaches to the end of the foot and is necessary for balance and locomotion.";
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public float GetMobility()
	{
		return GetMass() * 0.15f;
	}

	public float GetBalance()
	{
		return GetMass() * 0.35f;
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
