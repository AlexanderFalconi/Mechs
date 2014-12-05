using UnityEngine;
using System.Collections.Generic;

public class LL1 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LL1()
	{
		Short = "LL-1";
		Long = "A large laser.";
		Capacity = 1;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"large laser"};
		Energy = new Dictionary<string,float>() {{"fire",40.0f}, {"reload",40.0f}};
		SetMass(6.0f);
		Loaded = new LargeLaser();
	}
}
