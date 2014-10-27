﻿using UnityEngine;
using System.Collections.Generic;

public class LMG300 : Weapon 
{
	public string Short = "HMG-20";
	public string Long = "A fully automatic light machinegun.";
	public int RateOfFire = 30;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LMG300()
	{
		Capacity = 200;
		Ammo = new List<string>() {"5.56x54mm Bullets"};
		Energy = new Dictionary<string,float>() {{"fire",0.1f}, {"reload",1.0f}};
		SetMass(0.25f);
	}
}
