using UnityEngine;
using System.Collections.Generic;

public class Shuriken2Missile : Ammunition
{
	static public List<string> Ammo = new List<string>() {"SRM-2", "SRM-4", "SRM-6"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 20;
	public Shuriken2Missile()
	{
		Short = "Shuriken-2 Missile";
		Long = "A short range Shuriken-2 Missile.";
		Combustibility = 0.1f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 40;
		Range = 6;
	}
}