using UnityEngine;
using System.Collections;

public class M1ShoulderActuator : Actuator 
{
	public string Short = "Mark-1 Shoulder Actuator";
	public string Long = "A MechTech Mark-1 shoulder actuator. It binds the upper arm with the torso and expands the range of motion of the arm.";
	public string[] Compatibility = new string[] {"left arm", "right arm"};

	public float GetAccuracy()
	{
		return GetMass() * 0.15f;
	}

	public float GetRotation()
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
