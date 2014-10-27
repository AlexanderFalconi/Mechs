using UnityEngine;
using System.Collections.Generic;

public class Bludgeoning : Ammunition 
{
	public int Damage;
	public string DamageType = "impact";
	static public List<string> Ammo = new List<string>();

	public Bludgeoning(int damage)
	{
		Damage = damage;
		Range = 1;
	}
}
