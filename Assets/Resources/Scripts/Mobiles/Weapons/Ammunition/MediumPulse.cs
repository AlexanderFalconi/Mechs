using UnityEngine;
using System.Collections;

public class MediumPulse : Ammunition 
{
	static public string Short = "Medium Pulse Beam";
	static public string Long = "A medium pulse beam.";
	static public List<string> Ammo = new List<string>() {"MPR-21"};
	static public int Range = 6;
	static public float Combustibility = 0.0f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 1;
	public MediumPulse()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 40;
	}
}