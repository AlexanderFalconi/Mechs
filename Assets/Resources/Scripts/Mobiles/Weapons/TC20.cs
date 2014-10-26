using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC20 : Weapon 
{
	public string Short = "TC-20";
	public string Long = "A tactical cannon that fires 20cc shells.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"20cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC20()
	{
		Energy = new Dictionary<string,int>() {{"fire",1}, {"reload",4}};
		SetMass(10.0f);
	}
}
