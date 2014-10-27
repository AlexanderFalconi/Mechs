using UnityEngine;
using System.Collections.Generic;

public class LRM20 : Weapon 
{
	public string Short = "LRM-20";
	public string Long = "A AegisSeries LRM-20 missile battery that stores up to 20 long-range missiles.";
	public int RateOfFire = 5;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM20()
	{
		Capacity = 20;
		Ammo = new List<string>() {"Arrow-1 Missile"};
		Energy = new Dictionary<string,float>() {{"fire",20.0f}, {"reload",20.0f}};
		SetMass(8.5f);
	}
}