using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC10 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC10()
	{
		Short = "AC-10";
		Long = "A semi-automatic cannon that fires 10cc shells.";
		Capacity = 3;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"10cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",3.0f}, {"reload",3.0f}};
		SetMass(7.0f);
	}
}