using UnityEngine;
using System.Collections;

public class MediumLaser : Ammunition 
{
	static public string Short = "Medium Laser Beam";
	static public string Long = "A medium laser beam.";
	static public List<string> Ammo = new List<string>() {"ML-24"};
	static public int Range = 2;
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public MediumLaser()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 120;
	}
}