using UnityEngine;
using System.Collections.Generic;

public class RightArm : Part
{
	public RightArm () 
	{
		Short = "right arm";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 3}, {"right", 9}};
		Proportion["ratio"] = 0.12f;
		Melee.Add("punch");
		Melee.Add("kick");
	}

	public float[] GetFiringArc()
	{
		float[] arc = new float[2];
		float rotation = 0.0f;
		float expand;
		foreach(Component item in Components)
			rotation += item.GetRotation();
		expand = rotation/Master.GetMass() * 15.0f;//On average should be 225
		arc[0] = 22.5f - expand/2.0f;
		arc[1] = 22.5f + expand/2.0f;
		if(arc[1] >= 360)
			arc[1]-=360;
		return arc;
	}

	public float GetAccuracy()
	{
		float accuracy = 0.0f;
		foreach(Component item in Components)
			accuracy += item.GetAccuracy();
		return Mathf.Floor(accuracy/Master.GetMass());
	}

	public int GetMeleeCR()
	{
		return 1;//Punch push
	}

	public int GetMeleeDamage()
	{
		return (int)Proportion["mass"];
	}

	public void EventMeleeBacklash()
	{
		foreach(Component item in Components)
		{
			if(item.IsMeleeWeapon())
				return;//Found hand actuator or similar, no self damage
		}
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Proportion["mass"])));
	}
}
