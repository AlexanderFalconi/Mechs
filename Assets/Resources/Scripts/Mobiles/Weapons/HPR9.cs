using UnityEngine;
using System.Collections.Generic;

public class HPR9 : Weapon 
{
	public int RateOfFire = 3;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HPR9()
	{
		Short = "HPR-9";
		Long = "An heavy pulse rifle.";
		Capacity = 0;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",16.0f}};
		SetMass(2.75f);
	}
}
