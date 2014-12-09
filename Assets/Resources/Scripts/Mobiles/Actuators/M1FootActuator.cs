using UnityEngine;
using System.Collections;
using Config;

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
		return GetMass() * 15.0f;
	}

	public float GetBalance()
	{
		return GetMass() * 35.0f;
	}

	public override void Interval()
	{
		if(GetStatus() == Statuses.OK)
		{
			Installed.Master.Mobility += GetMobility();
			Installed.Master.Balance += GetBalance();
		}
		base.Interval();
  	}
}
