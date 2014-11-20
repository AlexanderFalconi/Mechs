using UnityEngine;
using System.Collections.Generic;

public class AmmoExplosion : Ammunition
{
	public AmmoExplosion(int damage)
	{
		DamageType = "explosive";
		Damage["max"] = damage;
		Range = 0;
	}
}