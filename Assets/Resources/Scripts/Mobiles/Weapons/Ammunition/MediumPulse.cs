using UnityEngine;
using System.Collections.Generic;

public class MediumPulse : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"MPR-21"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public MediumPulse()
	{
		Short = "Medium Pulse Beam";
		Long = "A medium pulse beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 40;
		Range = 6;
	}
}