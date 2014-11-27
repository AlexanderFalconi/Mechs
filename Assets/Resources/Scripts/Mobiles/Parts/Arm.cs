using UnityEngine;
using System.Collections;

public class Arm : Part
{
	public Arm () 
	{
		Proportion["ratio"] = 0.14f;
		Melee.Add("punch");
		Melee.Add("push");
	}

	public override float GetAccuracy()
	{
		float accuracy = 0.0f;
		//foreach(Component item in Components)
		//	accuracy += item.GetAccuracy();
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
