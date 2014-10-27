using UnityEngine;
using System.Collections.Generic;

public class CC8Slug : Ammunition 
{
	static public string Short = "8cc Slugs";
	static public string Long = "A bundle of 8cc slugs.";
	static public List<string> Ammo = new List<string>() {"Light Gauss Rifle"};
	static public float Combustibility = 0.05f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 20;
	public CC8Slug()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 160;
		Range = 24;
	}
}