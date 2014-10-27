using UnityEngine;
using System.Collections.Generic;

public class MPR21 : Weapon 
{
	public string Short = "MPR-21";
	public string Long = "An medium pulse rifle.";
	public int RateOfFire = 3;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MPR21()
	{
		Capacity = 0;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",10.0f}};
		SetMass(3.5f);
	}
}
