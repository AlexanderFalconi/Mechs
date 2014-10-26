using UnityEngine;
using System.Collections.Generic;

public class AmmoExplosion : Ammunition
{
	public int Damage;
	public string DamageType = "explosive";
	static public List<string> Ammo = new List<string>();

	public AmmoExplosion(int damage)
	{
		Damage = damage;
	}
}