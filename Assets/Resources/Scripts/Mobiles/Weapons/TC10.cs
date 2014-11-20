using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC10 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC10()
	{
		Short = "TC-10";
		Long = "A tactical cannon that fires 10cc shells.";
		Capacity = 5;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 2}, {"waiting", 0}};
		Ammo = new List<string>() {"10cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",2.0f}};
		SetMass(5.0f);
	}
}
