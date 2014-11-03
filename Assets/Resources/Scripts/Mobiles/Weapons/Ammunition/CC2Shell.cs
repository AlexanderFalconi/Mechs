using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC2Shell : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"AC-2"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 32;
	public CC2Shell()
	{
		Short = "2cc Shells";
		Long = "A bundle of 2cc ballistic shells.";
		Combustibility = 0.02f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 40;
		Range = 20;
	}
}