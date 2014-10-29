using UnityEngine;
using System.Collections;

public class M1LegActuator : Actuator 
{
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public M1LegActuator(float mass) : base(mass)
	{
		Short = "Mark-1 Leg Actuator";
		Long = "A MechTech Mark-1 leg actuator. It runs along the entire length of a leg and facilitates locomotion.";
	}

	public override float GetLocomotion()
	{
		return GetMass() * 0.50f;
	}

	public override void EventInstall(Part part)
	{
		base.EventInstall(part);
		Installed.Master.UpdateActuators();
	}

	public void EventUninstall()
	{
		Installed.Master.UpdateActuators();
		base.EventUninstall();
	}

	public override bool IsMeleeWeapon()
	{
		return true;
	}
}
