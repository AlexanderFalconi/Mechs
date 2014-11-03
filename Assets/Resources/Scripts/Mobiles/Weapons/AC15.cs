using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC15 : Weapon 
{
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC15()
	{
		Short = "AC-15";
		Long = "An semi-automatic cannon that fires 15cc shells.";
		Capacity = 2;
		Ammo = new List<string>() {"15cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}, {"reload",4.0f}};
		SetMass(9.0f);
	}
}
