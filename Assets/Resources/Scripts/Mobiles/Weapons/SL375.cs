using UnityEngine;
using System.Collections.Generic;

public class SL375 : Weapon 
{
	public string Short = "SL-375";
	public string Long = "A small laser.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SL375()
	{
		Capacity = 1;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",10.0f}};
		SetMass(2.0f);
	}
}
