using UnityEngine;
using System.Collections.Generic;

public class MediumLaser : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"ML-24"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public MediumLaser()
	{
		Short = "Medium Laser Beam";
		Long = "A medium laser beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 120;
		Range = 2;
	}
}