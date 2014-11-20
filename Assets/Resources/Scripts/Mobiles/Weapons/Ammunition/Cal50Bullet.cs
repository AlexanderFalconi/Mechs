using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cal50Bullet : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Cal50Bullet()
	{
		Short = "50 Caliber Bullets";
		Long = "A bundle of 50 Caliber Bullets.";
		Bundle = 50;
		Ammo = new List<string>() {"HMG-1"};
		Combustibility = 0.007f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 7;
		Range = 10;
	}
}