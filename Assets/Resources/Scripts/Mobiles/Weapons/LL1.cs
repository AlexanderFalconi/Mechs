using UnityEngine;
using System.Collections.Generic;

public class LL1 : Weapon 
{
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LL1()
	{
		Short = "LL-1";
		Long = "A large laser.";
		Capacity = 1;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",40.0f}};
		SetMass(6.0f);
	}
}
