using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullets556 : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Bullets556()
	{
		Short = "5.56x45mm Bullets";
		Long = "A bundle of 5.56x45mm Bullets.";
		Bundle = 200;
		Ammo = new List<string>() {"LMG-300"};
		Combustibility = 0.001f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 1;
		Range = 4;
	}
}