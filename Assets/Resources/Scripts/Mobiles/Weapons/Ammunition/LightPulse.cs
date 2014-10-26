using UnityEngine;
using System.Collections;

public class LightPulse : Ammunition 
{
	static public string Short = "Light Pulse Beam";
	static public string Long = "A light pulse beam.";
	static public List<string> Ammo = new List<string>() {"LPR-375"};
	static public int Range = 3;
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public LightPulse()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 20;
	}
}