using UnityEngine;
using System.Collections.Generic;

public class LRM10 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM10()
	{
		Short = "LRM-10";
		Long = "An AegisSeries LRM-10 missile battery that stores up to 10 long-range missiles.";
		Capacity = 10;
		RateOfFire = new Dictionary<string,int>() {{"max",10}, {"set",10}};
		Reload = new Dictionary<string,int>() {{"delay", 2}, {"waiting", 0}};
		Ammo = new List<string>() {"Arrow-1 Missiles"};
		Energy = new Dictionary<string,float>() {{"fire",10.0f}, {"reload",10.0f}};
		SetMass(4.5f);
	}
}