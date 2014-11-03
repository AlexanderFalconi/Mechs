using UnityEngine;
using System.Collections.Generic;

public class Arrow1Missile : Ammunition 
{
	static public List<string> Ammo = new List<string>() {"LRM-5", "LRM-10", "LRM-15", "LRM-20"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	static public int Bundle = 20;
	public Arrow1Missile()
	{
		Short = "Arrow-1 Missile";
		Long = "A long range Arrow-1 missile.";
		Combustibility = 0.05f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage = 20;
		Range = 24;
	}
}