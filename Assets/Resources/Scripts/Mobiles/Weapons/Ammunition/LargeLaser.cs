using UnityEngine;
using System.Collections.Generic;

public class LargeLaser : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LargeLaser()
	{
		Short = "Large Laser Beam";
		Long = "A large laser beam.";
		Bundle = 1;
		Ammo = new List<string>() {"LL-1"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 180;
		Range = 3;
	}
}