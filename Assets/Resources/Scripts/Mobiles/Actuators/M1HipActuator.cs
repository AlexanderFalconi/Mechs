using UnityEngine;
using System.Collections;

public class M1HipActuator : Actuator 
{
	public string Short = "Mark-1 Hip Actuator";
	public string Long = "A MechTech Mark-1 hip actuator. It facilitates twisting of the torso and more agile turning.";
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public M1HipActuator(float mass) : base(mass)
	{

	}

	public float GetMobility()
	{
		return GetMass() * 0.35f;
	}

	public float GetBalance()
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
