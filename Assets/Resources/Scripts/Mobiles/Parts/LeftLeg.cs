using UnityEngine;
using System.Collections.Generic;

public class LeftLeg : Part
{
	public LeftLeg () 
	{
		Short = "left leg";
		HitTable = new Dictionary<string,int>() {{"front", 4}, {"left", 5}, {"right", 2}};
		Proportion["ratio"] = 0.14f;
		Melee.Add("kick");
	}
	public float[] GetFiringArc()
	{
		float[] arc = {285.0f, 0.0f};
		return arc;
	}
	public int GetMeleeCR()
	{
		return 0;
	}

	public float GetBalance()
	{
		float balance;
		foreach(Component item in Components)
			balance += item.GetBalance();
		return Mathf.Floor(balance/Master.GetMass());
	}

	public float GetMobility()
	{
		float mobility;
		foreach(Component item in Components)
			mobility += item.GetMobility();
		return Mathf.Floor(mobility/Master.GetMass());
	}

	public float GetLocomotion()
	{
		float locomotion;
		foreach(Component item in Components)
			locomotion += item.GetLocomotion();
		return Mathf.Floor(locomotion/Master.GetMass());
	}
}
