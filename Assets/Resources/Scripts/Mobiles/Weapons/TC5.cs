using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC5 : Weapon 
{
	public string Short = "TC-5";
	public string Long = "A tactical cannon that fires 5cc shells.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"5cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC5()
	{
		Energy = new Dictionary<string,int>() {{"fire",1}, {"reload",1}};
		SetMass(2.0f);
	}
}
