using UnityEngine;
using System.Collections.Generic;

public class CC16Slug : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"Gauss Rifle"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 6;
	public CC16Slug()
	{
		Short = "16cc Slugs";
		Long = "A bundle of 16cc slugs.";
		Combustibility = 0.1f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 320;
		Range = 12;
	}
}