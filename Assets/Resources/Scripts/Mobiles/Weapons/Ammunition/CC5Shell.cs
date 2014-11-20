using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC5Shell : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public CC5Shell()
	{
		Short = "5cc Shells";
		Long = "A bundle of 5cc ballistic shells.";
		Bundle = 16;
		Ammo = new List<string>() {"TC-5", "AC-5"};
		Combustibility = 0.05f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 100;
		Range = 10;
	}
}