using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC15 : Weapon 
{
	public string Short = "AC-15";
	public string Long = "An semi-automatic cannon that fires 15cc shells.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC15()
	{
		Capacity = 2;
		Ammo = new List<string>() {"15cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}, {"reload",4.0f}};
		SetMass(9.0f);
	}
}
