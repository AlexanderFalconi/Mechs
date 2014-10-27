using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC10 : Weapon 
{
	public string Short = "TC-10";
	public string Long = "A tactical cannon that fires 10cc shells.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC10()
	{
		Capacity = 1;
		Ammo = new List<string>() {"10cc Shell"};
		Energy = new Dictionary<string,float>() {{"fire",1.0f}, {"reload",2.0f}};
		SetMass(5.0f);
	}
}
