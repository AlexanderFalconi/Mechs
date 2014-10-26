using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC15 : Weapon 
{
	public string Short = "TC-15";
	public string Long = "A tactical cannon that fires 15cc shells.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"15cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC15()
	{
		Energy = new Dictionary<string,int>() {{"fire",1}, {"reload",3}};
		SetMass(7.0f);
	}
}
