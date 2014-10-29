using UnityEngine;
using System.Collections.Generic;

public class LeftArm : Part 
{
	public LeftArm()
	{
		Short = "left arm";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 9}, {"right", 3}};
		Proportion["ratio"] = 0.12f;
		Melee.Add("punch");
		Melee.Add("kick");
	}

	public override float[] GetFiringArc()
	{
		float[] arc = new float[2];
		float rotation = 0.0f;
		float expand;
		foreach(Component item in Components)
			rotation += item.GetRotation();
		expand = Mathf.Floor(rotation/Master.GetMass()) * 15;//On average should be 225
		arc[0] = 337.5f - expand/2.0f;
		arc[1] = 337.5f + expand/2.0f;
		if(arc[1] >= 360)
			arc[1]-=360;
		return arc;
	}

	public override float GetAccuracy()
	{
		float accuracy = 0.0f;
		foreach(Component item in Components)
			accuracy += item.GetAccuracy();
		return Mathf.Floor(accuracy/Master.GetMass());
	}

	public override int GetMeleeCR()
	{
		return 1;//Punch push
	}

	public override int GetMeleeDamage()
	{
		return (int)Proportion["mass"];
	}

	public override void EventMeleeBacklash()
	{
		foreach(Component item in Components)
		{
			if(item.IsMeleeWeapon())
				return;//Found hand actuator or similar, no self damage
		}
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Proportion["mass"])));
	}
}