using UnityEngine;
using System.Collections.Generic;

public class Armor
{
	static public int ArmorUnits = 8;//Per 0.25 mass
	public float Mass;
	public int MaxHP, HP;
	public string Short;
	public Dictionary<string,int> Hardness;

	public Armor(float mass)
	{
		Mass = mass;
		MaxHP = Mathf.FloorToInt(mass / 0.25f) * ArmorUnits;
		HP = MaxHP;//Set initial to full
	}

	public string GetUILong()
	{
		return HP+"/"+MaxHP;
	}

	public void AddArmor(float mass)
	{
		Mass += mass;
		MaxHP +=  Mathf.FloorToInt(mass / 0.25f) * ArmorUnits;
		HP +=  Mathf.FloorToInt(mass / 0.25f) * ArmorUnits;//Increase initial accordingly
	}
}
	
