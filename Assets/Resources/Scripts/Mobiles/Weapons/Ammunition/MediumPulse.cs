using UnityEngine;
using System.Collections.Generic;

public class MediumPulse : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MediumPulse()
	{
		Short = "Medium Pulse Beam";
		Long = "A medium pulse beam.";
		Bundle = 1;
		Ammo = new List<string>() {"MPR-21"};
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 40;
		Range = 6;
	}
}