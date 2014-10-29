using UnityEngine;
using System.Collections.Generic;

public class CenterTorso : Part 
{
	public CenterTorso () 
	{
		Short = "center torso";
		HitTable = new Dictionary<string,int>() {{"front", 7}, {"left", 5}, {"right", 5}};
		Proportion["ratio"] = 0.15f;	
		Melee.Add("charge");
		Melee.Add("pounce");
	}
	
	public override float[] GetFiringArc()
	{
		float[] arc = new float[] {322.5f, 37.5f};
		return arc;
	}

	public override int GetMeleeCR()
	{
		return 2;//Used for charge, pounce
	}

	public override int GetMeleeDamage()
	{
		return Mathf.FloorToInt(Master.GetMass() / 10.0f) * Master.Speed["momentum"];
	}

	public override void EventMeleeBacklash()
	{
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Master.GetMass() / 10.0f) * Master.Speed["momentum"]));
	}
}