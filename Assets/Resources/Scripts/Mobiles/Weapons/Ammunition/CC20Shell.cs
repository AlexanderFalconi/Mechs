using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC20Shell : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public CC20Shell()
	{
		Short = "20cc Shells";
		Long = "A bundle of 15cc ballistic shells.";
		Bundle = 3;
		Ammo = new List<string>() {"TC-20"};
		Combustibility = 0.2f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 400;
		Range = 3;
	}
}