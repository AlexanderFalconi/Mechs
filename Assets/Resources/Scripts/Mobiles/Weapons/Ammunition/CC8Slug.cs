using UnityEngine;
using System.Collections.Generic;

public class CC8Slug : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"Light Gauss Rifle"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 20;
	public CC8Slug()
	{
		Short = "8cc Slugs";
		Long = "A bundle of 8cc slugs.";
		Combustibility = 0.05f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 160;
		Range = 24;
	}
}