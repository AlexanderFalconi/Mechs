using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC20Shell : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"TC-20"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 3;
	public CC20Shell()
	{
		Short = "20cc Shells";
		Long = "A bundle of 15cc ballistic shells.";
		Combustibility = 0.2f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 400;
		Range = 3;
	}
}