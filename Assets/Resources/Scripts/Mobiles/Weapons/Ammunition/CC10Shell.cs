using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC10Shell : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"TC-10", "AC-10"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 8;
	public CC10Shell()
	{
		Short = "10cc Shells";
		Long = "A bundle of 10cc ballistic shells.";
		Combustibility = 0.1f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 200;
		Range = 6;
	}
}