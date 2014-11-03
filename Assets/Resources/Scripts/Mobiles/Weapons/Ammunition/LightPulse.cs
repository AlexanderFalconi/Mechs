using UnityEngine;
using System.Collections.Generic;

public class LightPulse : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"LPR-375"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public LightPulse()
	{
		Short = "Light Pulse Beam";
		Long = "A light pulse beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 20;
		Range = 3;
	}
}