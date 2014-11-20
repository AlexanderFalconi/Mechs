using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC15 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC15()
	{
		Short = "AC-15";
		Long = "A semi-automatic cannon that fires 15cc shells.";
		Capacity = 2;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"15cc Shells"};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}, {"reload",4.0f}};
		SetMass(9.0f);
	}
}
