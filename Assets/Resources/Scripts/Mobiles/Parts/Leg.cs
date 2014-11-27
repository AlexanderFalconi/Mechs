using UnityEngine;
using System.Collections;

public class Leg : Part 
{
	public Leg () 
	{
		Proportion["ratio"] = 0.14f;
		Melee.Add("kick");
	}

	public override int GetMeleeDamage()
	{
		return (int)Proportion["mass"];
	}

	public override void EventMeleeBacklash()
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