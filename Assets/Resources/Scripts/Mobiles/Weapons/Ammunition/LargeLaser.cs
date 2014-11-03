using UnityEngine;
using System.Collections.Generic;

public class LargeLaser : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"HL-1"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public LargeLaser()
	{
		Short = "Large Laser Beam";
		Long = "A large laser beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 180;
		Range = 3;
	}
}