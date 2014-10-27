using UnityEngine;
using System.Collections.Generic;

public class MMG20 : Weapon 
{
	public string Short = "HMG-20";
	public string Long = "A fully automatic medium machinegun.";
	public int RateOfFire = 24;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MMG20()
	{
		Capacity = 50;
		Ammo = new List<string>() {"7.62x51mm Bullets"};
		Energy = new Dictionary<string,float>() {{"fire",0.2f}, {"reload",1.0f}};
		SetMass(0.5f);
	}
}
