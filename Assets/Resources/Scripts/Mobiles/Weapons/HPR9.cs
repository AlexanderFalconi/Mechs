using UnityEngine;
using System.Collections.Generic;

public class HPR9 : Weapon 
{
	public string Short = "HPR-9";
	public string Long = "An heavy pulse rifle.";
	public int RateOfFire = 3;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HPR9()
	{
		Capacity = 0;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",16.0f}};
		SetMass(2.75f);
	}
}
