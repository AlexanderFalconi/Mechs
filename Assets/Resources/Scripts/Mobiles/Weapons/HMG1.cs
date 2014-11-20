using UnityEngine;
using System.Collections.Generic;

public class HMG1 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HMG1()
	{
		Short = "HMG-1";
		Long = "A fully automatic heavy machinegun.";
		Capacity = 50;
		RateOfFire = new Dictionary<string,int>() {{"max",10}, {"set",10}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"50 Caliber Bullets"};
		Energy = new Dictionary<string,float>() {{"fire",0.3f}, {"reload",1.0f}};
		SetMass(0.75f);
	}
}
