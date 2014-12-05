using UnityEngine;
using System.Collections.Generic;

public class MediumLaser : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MediumLaser()
	{
		Short = "Medium Laser Beam";
		Long = "A medium laser beam.";
		Bundle = 1;
		Ammo = new List<string>() {"ML-24"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "energy";
		Damage["max"] = 120;
		Range = 2;
		SoundFX = "Audio/FXLargeLaser";
	}
}