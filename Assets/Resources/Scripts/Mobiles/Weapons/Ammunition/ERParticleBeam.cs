using UnityEngine;
using System.Collections;

public class ERParticleBeam : Ammunition 
{
	static public string Short = "Focused Particle Beam";
	static public string Long = "A focused particle beam.";
	static public List<string> Ammo = new List<string>() {"PPC-9"};
	static public int Range = 6;
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public ERParticleBeam()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 240;
	}
}