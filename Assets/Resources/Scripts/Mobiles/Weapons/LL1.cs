using UnityEngine;
using System.Collections.Generic;

public class LL1 : Weapon 
{
	public string Short = "LL-1";
	public string Long = "A large laser.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LL1()
	{
		Capacity = 1;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",40.0f}};
		SetMass(6.0f);
	}
}
