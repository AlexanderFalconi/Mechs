using UnityEngine;
using System.Collections;

public class ExtraSmallLaser : Ammunition 
{
	static public string Short = "Extra Small Laser Beam";
	static public string Long = "An extra small laser beam.";
	static public List<string> Ammo = new List<string>() {"XSL-2000"};
	static public int Range = 1;
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public ExtraSmallLaser()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 20;
	}
}