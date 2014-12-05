using UnityEngine;
using System.Collections.Generic;

public class LPR357 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LPR357()
	{
		Short = "LPR-357";
		Long = "A light pulse rifle.";
		Capacity = 15;
		RateOfFire = new Dictionary<string,int>() {{"max",3}, {"set",3}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"light pulse"};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}, {"reload",4.0f}};
		SetMass(1.25f);
		Loaded = new LightPulse();
	}
}
