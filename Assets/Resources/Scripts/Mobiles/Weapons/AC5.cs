using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC5 : Weapon 
{
	public string Short = "AC-5";
	public string Long = "An semi-automatic cannon that fires 5cc shells.";
	public int Capacity = 6;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"5cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC5()
	{
		Energy = new Dictionary<string,int>() {{"fire",2}, {"reload",2}};
		SetMass(4.0f);
	}
}