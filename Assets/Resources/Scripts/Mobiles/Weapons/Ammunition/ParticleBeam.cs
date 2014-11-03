using UnityEngine;
using System.Collections.Generic;

public class ParticleBeam : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"PPC-9"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public ParticleBeam()
	{
		Short = "Particle Beam";
		Long = "A particle beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 240;
		Range = 4;
	}
}