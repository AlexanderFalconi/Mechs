using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC20Shell : Ammunition 
{
	static public string Short = "20cc Shells";
	static public string Long = "A bundle of 15cc ballistic shells.";
	static public List<string> Ammo = new List<string>() {"TC-20"};
	static public int Range = 3;
	static public float Combustibility = 0.2f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 3;
	public CC20Shell()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 400;
	}
}