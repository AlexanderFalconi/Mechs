using UnityEngine;
using System.Collections.Generic;

public class SRM4 : Weapon 
{
	public int RateOfFire = 4;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM4()
	{
		Short = "SRM-2";
		Long = "A PointBlank SRM-4 missile battery that stores up to 4 short-range missiles.";
		Capacity = 4;
		Ammo = new List<string>() {"Shuriken-2 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}, {"reload",4.0f}};
		SetMass(1.75f);
	}
}