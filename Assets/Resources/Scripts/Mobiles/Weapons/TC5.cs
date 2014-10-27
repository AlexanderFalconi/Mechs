﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC5 : Weapon 
{
	public string Short = "TC-5";
	public string Long = "A tactical cannon that fires 5cc shells.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC5()
	{
		Capacity = 1;
		Ammo = new List<string>() {"5cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",1.0f}};
		SetMass(2.0f);
	}
}
