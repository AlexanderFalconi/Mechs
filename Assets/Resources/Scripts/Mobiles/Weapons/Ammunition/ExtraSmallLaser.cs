using UnityEngine;
using System.Collections.Generic;

public class ExtraSmallLaser : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"XSL-2000"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public ExtraSmallLaser()
	{
		Short = "Extra Small Laser Beam";
		Long = "An extra small laser beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 20;
		Range = 1;
	}
}