using UnityEngine;
using System.Collections.Generic;

public class AmmoExplosion : Ammunition
{
	static public List<string> Ammo = new List<string>();

	public AmmoExplosion(int damage)
	{
		DamageType = "explosive";
		Damage = damage;
		Range = 0;
	}
}