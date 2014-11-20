using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC2Shell : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public CC2Shell()
	{
		Short = "2cc Shells";
		Long = "A bundle of 2cc ballistic shells.";
		Bundle = 32;
		Ammo = new List<string>() {"AC-2"};
		Combustibility = 0.02f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 40;
		Range = 20;
	}
}