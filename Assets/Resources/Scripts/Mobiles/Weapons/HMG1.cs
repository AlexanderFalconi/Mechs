using UnityEngine;
using System.Collections.Generic;

public class HMG1 : Weapon 
{
	public string Short = "HMG-1";
	public string Long = "A fully automatic heavy machinegun.";
	public int RateOfFire = 20;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HMG1()
	{
		Capacity = 50;
		Ammo = new List<string>() {"50 Caliber Bullets"};
		Energy = new Dictionary<string,float>() {{"fire",0.3f}, {"reload",1.0f}};
		SetMass(0.75f);
	}
}
