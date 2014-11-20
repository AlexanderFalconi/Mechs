using UnityEngine;
using System.Collections.Generic;

public class SmallLaser : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SmallLaser()
	{
		Short = "Small Laser Beam";
		Long = "A small laser beam.";
		Ammo = new List<string>() {"SL-375"};
		Bundle = 1;
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 60;
		Range = 1;
	}
}