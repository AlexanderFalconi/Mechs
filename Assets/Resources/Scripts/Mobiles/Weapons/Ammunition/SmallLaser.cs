using UnityEngine;
using System.Collections.Generic;

public class SmallLaser : Ammunition 
{
	static public string Short = "Small Laser Beam";
	static public string Long = "A small laser beam.";
	static public List<string> Ammo = new List<string>() {"SL-375"};
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public SmallLaser()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 60;
		Range = 1;
	}
}