using UnityEngine;
using System.Collections.Generic;

public class ML24 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ML24()
	{
		Short = "ML-24";
		Long = "A medium laser.";
		Capacity = 1;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",25.0f}};
		SetMass(4.0f);
	}
}
