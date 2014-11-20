using UnityEngine;
using System.Collections.Generic;

public class CC16Slug : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public CC16Slug()
	{
		Short = "16cc Slugs";
		Long = "A bundle of 16cc slugs.";
		Bundle = 6;
		Ammo = new List<string>() {"Gauss Rifle"};
		Combustibility = 0.1f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 320;
		Range = 12;
	}
}