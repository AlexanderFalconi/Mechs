using UnityEngine;
using System.Collections.Generic;

public class SmallLaser : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"SL-375"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public SmallLaser()
	{
		Short = "Small Laser Beam";
		Long = "A small laser beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 60;
		Range = 1;
	}
}