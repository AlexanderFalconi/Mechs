using UnityEngine;
using System.Collections.Generic;

public class SRM2 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM2()
	{
		Short = "SRM-2";
		Long = "A PointBlank SRM-2 missile battery that stores up to 2 short-range missiles.";
		Capacity = 2;
		RateOfFire = new Dictionary<string,int>() {{"max",2}, {"set",2}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"Shuriken-2 Missiles"};
		Energy = new Dictionary<string,float>() {{"fire",2.0f}, {"reload",2.0f}};
		SetMass(1.75f);
	}
}