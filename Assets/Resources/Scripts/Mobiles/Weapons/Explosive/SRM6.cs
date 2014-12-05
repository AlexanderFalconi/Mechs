using UnityEngine;
using System.Collections.Generic;

public class SRM6 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM6()
	{
		Short = "SRM-6";
		Long = "A PointBlank SRM-6 missile battery that stores up to 6 short-range missiles.";
		Capacity = 6;
		RateOfFire = new Dictionary<string,int>() {{"max",6}, {"set",6}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"Shuriken-2 Missiles"};
		Energy = new Dictionary<string,float>() {{"fire",6.0f}, {"reload",6.0f}};
		SetMass(1.75f);
	}
}