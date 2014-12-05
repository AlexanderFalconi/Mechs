using UnityEngine;
using System.Collections.Generic;

public class LRM20 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM20()
	{
		Short = "LRM-20";
		Long = "A AegisSeries LRM-20 missile battery that stores up to 20 long-range missiles.";
		Capacity = 20;
		RateOfFire = new Dictionary<string,int>() {{"max",20}, {"set",20}};
		Reload = new Dictionary<string,int>() {{"delay", 4}, {"waiting", 0}};
		Ammo = new List<string>() {"Arrow-1 Missiles"};
		Energy = new Dictionary<string,float>() {{"fire",20.0f}, {"reload",20.0f}};
		SetMass(8.5f);
	}
}