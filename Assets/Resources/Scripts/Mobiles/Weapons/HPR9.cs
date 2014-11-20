using UnityEngine;
using System.Collections.Generic;

public class HPR9 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HPR9()
	{
		Short = "HPR-9";
		Long = "A heavy pulse rifle.";
		Capacity = 5;
		RateOfFire = new Dictionary<string,int>() {{"max",3}, {"set",3}};
		Reload = new Dictionary<string,int>() {{"auto", 1}, {"waiting", 0}};
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",16.0f}};
		SetMass(2.75f);
	}
}
