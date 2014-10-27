using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC5 : Weapon 
{
	public string Short = "AC-5";
	public string Long = "An semi-automatic cannon that fires 5cc shells.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC5()
	{
		Capacity = 6;
		Ammo = new List<string>() {"5cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",2.0f}, {"reload",2.0f}};
		SetMass(4.0f);
	}
}