using UnityEngine;
using System.Collections.Generic;

public class HeavyPulse : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HeavyPulse()
	{
		Short = "Heavy Pulse Beam";
		Long = "A heavy pulse beam.";
		Bundle = 1;
		Ammo = new List<string>() {"HPR-9"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 60;
		Range = 9;
		SoundFX = "Audio/FXPulseLaser";
	}
}