using UnityEngine;
using System.Collections.Generic;

public class XSL2000 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public XSL2000()
	{
		Short = "XSL-2000";
		Long = "An extra-small laser.";
		Capacity = 1;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",6.0f}, {"reload",6.0f}};
		SetMass(1.0f);
		Loaded = new ExtraSmallLaser();
	}
}
