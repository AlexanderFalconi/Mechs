using UnityEngine;
using System.Collections.Generic;

public class SRM6 : Weapon 
{
	public string Short = "SRM-6";
	public string Long = "A PointBlank SRM-6 missile battery that stores up to 6 short-range missiles.";
	public int RateOfFire = 6;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM6()
	{
		Capacity = 6;
		Ammo = new List<string>() {"Shuriken-2 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",6.0f}, {"reload",6.0f}};
		SetMass(1.75f);
	}
}