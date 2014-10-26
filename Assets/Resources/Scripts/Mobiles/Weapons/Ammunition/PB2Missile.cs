using UnityEngine;
using System.Collections;

public class PB2Missile : Ammunition
{
	static public string Short = "PB-2 Missile";
	static public string Long = "A short range PointBlank Series-2 Missile.";
	static public List<string> Ammo = new List<string>() {"SRM-2", "SRM-4", "SRM-6"};
	static public int Range = 6;
	static public float Combustibility = 0.1f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 20;
	public ParticleBeam()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 40;
	}
}