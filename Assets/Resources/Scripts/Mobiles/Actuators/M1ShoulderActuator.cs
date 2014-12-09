using UnityEngine;
using System.Collections;
using Config;

public class M1ShoulderActuator : Actuator 
{
	public string[] Compatibility = new string[] {"left arm", "right arm"};

	public M1ShoulderActuator(float mass) : base(mass)
	{
		Short = "Mark-1 Shoulder Actuator";
		Long = "A MechTech Mark-1 shoulder actuator. It binds the upper arm with the torso and expands the range of motion of the arm.";
	}

	public float GetAccuracy()
	{
		return GetMass() * 15.0f;
	}

	public float GetRotation()
	{
		return GetMass() * 35.0f;
	}

	public override void Interval()
	{
		if(GetStatus() == Statuses.OK)
		{
			Installed.Accuracy += GetAccuracy();
			Installed.Rotation += GetRotation();
		}
		base.Interval();
  	}
}
