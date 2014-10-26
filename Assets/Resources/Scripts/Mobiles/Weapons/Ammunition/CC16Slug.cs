using UnityEngine;
using System.Collections;

public class CC16Slug : Ammunition 
{
	static public string Short = "16cc Slugs";
	static public string Long = "A bundle of 16cc slugs.";
	static public List<string> Ammo = new List<string>() {"Gauss Rifle"};
	static public int Range = 12;
	static public float Combustibility = 0.1f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 6;
	public CC16Slug()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 320;
	}
}