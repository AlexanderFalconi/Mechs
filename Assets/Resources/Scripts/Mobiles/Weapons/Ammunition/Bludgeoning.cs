using UnityEngine;
using System.Collections.Generic;

public class Bludgeoning : Ammunition 
{
	public Bludgeoning(int damage)
	{
		DamageType = "impact";
		Damage["max"] = damage;
		Range = 1;
	}
}
