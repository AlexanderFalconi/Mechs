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
	
	public override float GetMobility()
	{
		return GetMass() * 15.0f;
	}

	public override float GetBalance()
	{
		return GetMass() * 35.0f;
	}

	public override void EventInstall(Part part)
	{
		base.EventInstall(part);
		Installed.Master.UpdateActuators();
	}

	public override void EventUninstall()
	{
		Installed.Master.UpdateActuators();
		base.EventUninstall();
	}
}
