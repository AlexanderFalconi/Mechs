﻿using UnityEngine;
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
		float[] arc = new float[] {285.0f, 0.0f};
		return arc;
	}
	public int GetMeleeCR()
	{
		return 0;
	}

	public float GetBalance()
	{
		float balance = 0.0f;
		foreach(Component item in Components)
			balance += item.GetBalance();
		return Mathf.Floor(balance/Master.GetMass());
	}

	public float GetMobility()
	{
		float mobility = 0.0f;
		foreach(Component item in Components)
			mobility += item.GetMobility();
		return Mathf.Floor(mobility/Master.GetMass());
	}

	public float GetLocomotion()
	{
		float locomotion = 0.0f;
		foreach(Component item in Components)
			locomotion += item.GetLocomotion();
		return Mathf.Floor(locomotion/Master.GetMass());
	}

	public int GetMeleeDamage()
	{
		return (int)Proportion["mass"];
	}

	public void EventMeleeBacklash()
	{
		Master.EventManeuver(0);//Balance after a kick
		foreach(Component item in Components)
		{
			if(item.IsMeleeWeapon())
				return;//Found hand actuator or similar, no self damage
		}
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Proportion["mass"])));
	}
}
