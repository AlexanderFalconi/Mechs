using UnityEngine;
using System.Collections.Generic;

public class HeavyPulse : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"HPR-9"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public HeavyPulse()
	{
		Short = "Heavy Pulse Beam";
		Long = "A heavy pulse beam.";
		Combustibility = 0.0f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 60;
		Range = 9;
	}
}