using UnityEngine;
using System.Collections;

public class M1ArmActuator : Actuator 
{
	public string[] Compatibility = new string[] {"left arm", "right arm"};

	public M1ArmActuator(float mass) : base(mass)
	{
		Short = "Mark-1 Arm Actuator";
		Long = "A MechTech Mark-1 arm actuator. It runs along the entire length of the arm and benefits any attached weaponry with a large firing arc.";
	}

	public override float GetAccuracy()
	{
		return GetMass() * 35.0f;
	}

	public override float GetRotation()
	{
		return GetMass() * 15.0f;
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
