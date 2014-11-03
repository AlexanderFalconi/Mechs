using UnityEngine;
using System.Collections.Generic;

public class SRM2 : Weapon 
{
	public int RateOfFire = 2;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM2()
	{
		Short = "SRM-2";
		Long = "A PointBlank SRM-2 missile battery that stores up to 2 short-range missiles.";
		Capacity = 2;
		Ammo = new List<string>() {"Shuriken-2 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",2.0f}, {"reload",2.0f}};
		SetMass(1.75f);
	}
}