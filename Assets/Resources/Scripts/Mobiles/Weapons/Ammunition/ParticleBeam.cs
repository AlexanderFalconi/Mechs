using UnityEngine;
using System.Collections.Generic;

public class ParticleBeam : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ParticleBeam()
	{
		Short = "Particle Beam";
		Long = "A particle beam.";
		Bundle = 1;
		Ammo = new List<string>() {"PPC-9"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 240;
		Range = 4;
		SoundFX = "Audio/FXPulseLaser";
	}
}