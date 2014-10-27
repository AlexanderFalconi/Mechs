using UnityEngine;
using System.Collections.Generic;

public class ML24 : Weapon 
{
	public string Short = "ML-24";
	public string Long = "A medium laser.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ML24()
	{
		Capacity = 1;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",25.0f}};
		SetMass(4.0f);
	}
}
