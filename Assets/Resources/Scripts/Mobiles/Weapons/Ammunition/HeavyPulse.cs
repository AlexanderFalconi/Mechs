using UnityEngine;
using System.Collections;

public class HeavyPulse : Ammunition 
{
	static public string Short = "Heavy Pulse Beam";
	static public string Long = "A heavy pulse beam.";
	static public List<string> Ammo = new List<string>() {"HPR-9"};
	static public int Range = 9;
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public HeavyPulse()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 60;
	}
}