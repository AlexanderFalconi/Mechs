using UnityEngine;
using System.Collections.Generic;

public class Bludgeoning : Ammunition 
{
	static public List<string> Ammo = new List<string>();

	public Bludgeoning(int damage)
	{
		DamageType = "impact";
		Damage = damage;
		Range = 1;
	}
}
