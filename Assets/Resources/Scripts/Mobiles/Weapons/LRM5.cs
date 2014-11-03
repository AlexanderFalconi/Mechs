using UnityEngine;
using System.Collections.Generic;

public class LRM5 : Weapon 
{
	public int RateOfFire = 5;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM5()
	{
		Short = "LRM-5";
		Long = "An AegisSeries LRM-5 missile battery that stores up to 5 long-range missiles.";
		Capacity = 5;
		Ammo = new List<string>() {"Arrow-1 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",5.0f}, {"reload",5.0f}};
		SetMass(1.75f);
	}
}