using UnityEngine;
using System.Collections;

public class AmmoExplosion : Ammunition
{
	public int Damage;
	public string DamageType = "explosive";

	public AmmoExplosion(int damage)
	{
		Damage = damage;
	}
}