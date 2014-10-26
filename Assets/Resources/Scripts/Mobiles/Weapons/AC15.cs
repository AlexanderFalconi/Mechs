using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC15 : Weapon 
{
	public string Short = "AC-15";
	public string Long = "An semi-automatic cannon that fires 15cc shells.";
	public int Capacity = 2;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"15cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC15()
	{
		Energy = new Dictionary<string,int>() {{"fire",4}, {"reload",4}};
		SetMass(9.0f);
	}
}
