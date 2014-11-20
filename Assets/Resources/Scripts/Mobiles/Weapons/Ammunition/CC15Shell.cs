using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC15Shell : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public CC15Shell()
	{
		Short = "15cc Shells";
		Long = "A bundle of 15cc ballistic shells.";
		Bundle = 5;
		Ammo = new List<string>() {"TC-15", "AC-15"};
		Combustibility = 0.15f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 300;
		Range = 4;
	}
}