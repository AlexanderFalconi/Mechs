using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC15 : Weapon 
{
	public string Short = "TC-15";
	public string Long = "A tactical cannon that fires 15cc shells.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC15()
	{
		Capacity = 1;
		Ammo = new List<string>() {"15cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",3.0f}};
		SetMass(7.0f);
	}
}
