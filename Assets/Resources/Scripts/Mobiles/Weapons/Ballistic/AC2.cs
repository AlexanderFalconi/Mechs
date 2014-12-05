using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC2 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC2()
	{
		Short = "AC-2";
		Long = "A semi-automatic cannon that fires 2cc shells.";
		Capacity = 15;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"2cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",1.0f}};
		SetMass(3.0f);
	}
}