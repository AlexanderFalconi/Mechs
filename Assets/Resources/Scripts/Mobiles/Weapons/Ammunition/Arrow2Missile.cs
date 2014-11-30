using UnityEngine;
using System.Collections.Generic;

public class Arrow2Missile : Ammunition
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Arrow2Missile()
	{
		Short = "Arrow-2 Missiles";
		Long = "A short range Arrow-2 Missile.";
		Ammo = new List<string>() {"SRM-2", "SRM-4", "SRM-6"};
		Bundle = 20;
		Combustibility = 0.1f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 40;
		Range = 6;
	}
}