using UnityEngine;
using System.Collections.Generic;

public class LRM10 : Weapon 
{
	public string Short = "LRM-10";
	public string Long = "An AegisSeries LRM-10 missile battery that stores up to 10 long-range missiles.";
	public int RateOfFire = 5;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM10()
	{
		Capacity = 10;
		Ammo = new List<string>() {"Arrow-1 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",10.0f}, {"reload",10.0f}};
		SetMass(4.5f);
	}
}