using UnityEngine;
using System.Collections.Generic;

public class LargeLaser : Ammunition 
{
	static public string Short = "Large Laser Beam";
	static public string Long = "A large laser beam.";
	static public List<string> Ammo = new List<string>() {"HL-1"};
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public LargeLaser()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 180;
		Range = 3;
	}
}