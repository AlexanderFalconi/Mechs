using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC20 : Weapon 
{
	public string Short = "TC-20";
	public string Long = "A tactical cannon that fires 20cc shells.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC20()
	{
		Capacity = 1;
		Ammo = new List<string>() {"20cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",4.0f}};
		SetMass(10.0f);
	}
}
