using UnityEngine;
using System.Collections.Generic;

public class ExtraSmallLaser : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ExtraSmallLaser()
	{
		Short = "Extra Small Laser Beam";
		Long = "An extra small laser beam.";
		Bundle = 1;
		Ammo = new List<string>() {"XSL-2000"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 20;
		Range = 1;
	}
}