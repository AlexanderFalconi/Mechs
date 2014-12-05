using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC5 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC5()
	{
		Short = "AC-5";
		Long = "A semi-automatic cannon that fires 5cc shells.";
		Capacity = 6;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"5cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",2.0f}, {"reload",2.0f}};
		SetMass(4.0f);
	}
}