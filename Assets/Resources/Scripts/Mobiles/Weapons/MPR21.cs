using UnityEngine;
using System.Collections;

public class MPR21 : Weapon 
{
	public string Short = "MPR-21";
	public string Long = "An medium pulse rifle.";
	public int Capacity = 0;
	public int RateOfFire = 3;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MPR21()
	{
		Energy = new Dictionary<string,int>() {{"fire",10}};
		SetMass(3.5f);
	}
}
