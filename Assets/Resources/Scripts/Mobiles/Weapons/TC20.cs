using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC20 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC20()
	{
		Short = "TC-20";
		Long = "A tactical cannon that fires 20cc shells.";
		Capacity = 2;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 2}, {"waiting", 0}};
		Ammo = new List<string>() {"20cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",4.0f}};
		SetMass(10.0f);
	}
}
