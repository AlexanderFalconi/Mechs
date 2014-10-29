using UnityEngine;
using System.Collections;

public class M1ShoulderActuator : Actuator 
{
	public string[] Compatibility = new string[] {"left arm", "right arm"};

	public M1ShoulderActuator(float mass) : base(mass)
	{
		Short = "Mark-1 Shoulder Actuator";
		Long = "A MechTech Mark-1 shoulder actuator. It binds the upper arm with the torso and expands the range of motion of the arm.";
	}

	public override float GetAccuracy()
	{
		return GetMass() * 0.15f;
	}

	public override float GetRotation()
	{
		return GetMass() * 0.35f;
	}

	public override void EventInstall(Part part)
	{
		part.Master.UpdateActuators();
		base.EventInstall(part);
	}

	public void EventUninstall()
	{
		Installed.Master.UpdateActuators();
		base.EventUninstall();
	}
}
