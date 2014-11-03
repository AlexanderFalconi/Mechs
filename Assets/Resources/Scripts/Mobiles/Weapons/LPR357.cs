using UnityEngine;
using System.Collections.Generic;

public class LPR357 : Weapon 
{
	public int RateOfFire = 3;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LPR357()
	{
		Short = "LPR-357";
		Long = "An light pulse rifle.";
		Capacity = 0;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}};
		SetMass(1.25f);
	}
}
