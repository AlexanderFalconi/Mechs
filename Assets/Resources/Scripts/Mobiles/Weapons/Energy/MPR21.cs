using UnityEngine;
using System.Collections.Generic;

public class MPR21 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MPR21()
	{
		Short = "MPR-21";
		Long = "A medium pulse rifle.";
		Capacity = 8;
		RateOfFire = new Dictionary<string,int>() {{"max",3}, {"set",3}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"medium pulse"};
		Energy = new Dictionary<string,float>() {{"fire",10.0f}, {"reload",10.0f}};
		SetMass(3.5f);
		Loaded = new MediumPulse();
	}
}
