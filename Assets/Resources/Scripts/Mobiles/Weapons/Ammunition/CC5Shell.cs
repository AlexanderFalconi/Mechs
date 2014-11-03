using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC5Shell : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"TC-15", "AC-15"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 16;
	public CC5Shell()
	{
		Short = "5cc Shells";
		Long = "A bundle of 5cc ballistic shells.";
		Combustibility = 0.05f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 100;
		Range = 10;
	}
}