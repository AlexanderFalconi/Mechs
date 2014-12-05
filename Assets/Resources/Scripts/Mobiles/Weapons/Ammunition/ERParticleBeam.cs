using UnityEngine;
using System.Collections.Generic;

public class ERParticleBeam : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ERParticleBeam()
	{
		Short = "Focused Particle Beam";
		Long = "A focused particle beam.";
		Bundle = 1;
		Ammo = new List<string>() {"PPC-9"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "energy";
		Damage["max"] = 240;
		Range = 6;
		SoundFX = "Audio/FXPPC";
	}
}