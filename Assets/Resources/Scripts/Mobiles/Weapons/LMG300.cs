using UnityEngine;
using System.Collections.Generic;

public class LMG300 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LMG300()
	{
		Short = "HMG-20";
		Long = "A fully automatic light machinegun.";
		Capacity = 200;
		RateOfFire = new Dictionary<string,int>() {{"max",30}, {"set",30}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"5.56x54mm Bullets"};
		Energy = new Dictionary<string,float>() {{"fire",0.1f}, {"reload",1.0f}};
		SetMass(0.25f);
	}
}
