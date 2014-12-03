using UnityEngine;
using System.Collections.Generic;

public class CC8Slug : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public CC8Slug()
	{
		Short = "8cc Slugs";
		Long = "A bundle of 8cc slugs.";
		Bundle = 20;
		Ammo = new List<string>() {"Light Gauss Rifle"};
		Combustibility = 0.05f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 160;
		Range = 24;
		SoundFX = "Audio/FXSmallShell";
	}
}