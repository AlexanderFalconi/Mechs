using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC2Shell : Ammunition 
{
	static public string Short = "2cc Shells";
	static public string Long = "A bundle of 2cc ballistic shells.";
	static public int Velocity = 15;//Affects accuracy, power degredation
	static public List<string> Ammo = new List<string>() {"AC-2"};
	static public float Combustibility = 0.02f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 32;
	public CC2Shell()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 40;
	}
}