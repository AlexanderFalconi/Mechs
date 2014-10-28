using UnityEngine;
using System.Collections;

public class M1FootActuator : Actuator 
{
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public M1FootActuator(float mass) : base(mass)
	{
		Short = "Mark-1 Foot Actuator";
		Long = "A MechTech Mark-1 foot actuator. It attaches to the end of the foot and is necessary for balance and locomotion.";
	}
	
	public float GetMobility()
	{
		return GetMass() * 0.15f;
	}

	public float GetBalance()
	{
		return GetMass() * 0.35f;
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
