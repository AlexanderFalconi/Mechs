using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC5 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC5()
	{
		Short = "TC-5";
		Long = "A tactical cannon that fires 5cc shells.";
		Capacity = 9;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 2}, {"waiting", 0}};
		Ammo = new List<string>() {"5cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",1.0f}};
		SetMass(2.0f);
	}
}
