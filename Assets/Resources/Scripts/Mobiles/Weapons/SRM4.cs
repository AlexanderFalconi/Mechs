using UnityEngine;
using System.Collections.Generic;

public class SRM4 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM4()
	{
		Short = "SRM-2";
		Long = "A PointBlank SRM-4 missile battery that stores up to 4 short-range missiles.";
		Capacity = 4;
		RateOfFire = new Dictionary<string,int>() {{"max",4}, {"set",4}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"Shuriken-2 Missiles"};
		Energy = new Dictionary<string,float>() {{"fire",4.0f}, {"reload",4.0f}};
		SetMass(1.75f);
	}
}