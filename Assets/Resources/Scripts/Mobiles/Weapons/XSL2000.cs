using UnityEngine;
using System.Collections.Generic;

public class XSL2000 : Weapon 
{
	public string Short = "XSL-2000";
	public string Long = "An extra-small laser.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public XSL2000()
	{
		Capacity = 1;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",6.0f}};
		SetMass(1.0f);
	}
}
