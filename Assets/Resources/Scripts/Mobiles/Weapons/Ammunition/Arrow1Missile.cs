using UnityEngine;
using System.Collections;

public class Arrow1Missile : Ammunition 
{
	static public string Short = "Arrow-1 Missile";
	static public string Long = "A long range Arrow-1 missile.";
	static public List<string> Ammo = new List<string>() {"LRM-5", "LRM-10", "LRM-15", "LRM-20"};
	static public int Range = 24;
	static public float Combustibility = 0.05f;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 20;
	public Arrow1Missile()
	{
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 20;
	}
}