using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC10 : Weapon 
{
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC10()
	{
		Short = "AC-10";
		Long = "An semi-automatic cannon that fires 10cc shells.";
		Capacity = 3;
		Ammo = new List<string>() {"10cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",3.0f}, {"reload",3.0f}};
		SetMass(7.0f);
	}
}