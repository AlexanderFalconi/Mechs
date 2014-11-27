using UnityEngine;
using System.Collections;

public class M1HipActuator : Actuator 
{
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public M1HipActuator(float mass) : base(mass)
	{
		Short = "Mark-1 Hip Actuator";
		Long = "A MechTech Mark-1 hip actuator. It facilitates twisting of the torso and more agile turning.";
	}

	public float GetMobility()
	{
		return GetMass() * 35.0f;
	}

	public float GetBalance()
	{
		return GetMass() * 15.0f;
	}

	public override void Interval()
	{
		Installed.Master.Balance += GetBalance();
		Installed.Master.Mobility += GetMobility();
		base.Interval();
  	}
}
