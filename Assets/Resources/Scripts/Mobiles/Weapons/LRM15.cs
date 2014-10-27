using UnityEngine;
using System.Collections.Generic;

public class LRM15 : Weapon 
{
	public string Short = "LRM-15";
	public string Long = "An AegisSeries LRM-15 missile battery that stores up to 15 long-range missiles.";
	public int RateOfFire = 5;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM15()
	{
		Capacity = 15;
		Ammo = new List<string>() {"Arrow-1 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",15.0f}, {"reload",15.0f}};
		SetMass(6.0f);
	}
}