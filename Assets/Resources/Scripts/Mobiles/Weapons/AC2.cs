using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC2 : Weapon 
{
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC2()
	{
		Short = "AC-2";
		Long = "An semi-automatic cannon that fires 2cc shells.";
		Capacity = 15;
		Ammo = new List<string>() {"2cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",1.0f}};
		SetMass(3.0f);
	}
}