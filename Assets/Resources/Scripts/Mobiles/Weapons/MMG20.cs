using UnityEngine;
using System.Collections.Generic;

public class MMG20 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MMG20()
	{
		Short = "HMG-20";
		Long = "A fully automatic medium machinegun.";
		Capacity = 50;
		RateOfFire = new Dictionary<string,int>() {{"max",16}, {"set",16}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"7.62x51mm Bullets"};
		Energy = new Dictionary<string,float>() {{"fire",0.2f}, {"reload",1.0f}};
		SetMass(0.5f);
	}
}
