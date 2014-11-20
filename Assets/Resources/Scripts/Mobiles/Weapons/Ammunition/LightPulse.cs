using UnityEngine;
using System.Collections.Generic;

public class LightPulse : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LightPulse()
	{
		Short = "Light Pulse Beam";
		Long = "A light pulse beam.";
		Bundle = 1;
		Ammo = new List<string>() {"LPR-375"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 20;
		Range = 3;
	}
}