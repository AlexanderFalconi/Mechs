using UnityEngine;
using System.Collections.Generic;

public class SL375 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SL375()
	{
		Short = "SL-375";
		Long = "A small laser.";
		Capacity = 1;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"small laser"};
		Energy = new Dictionary<string,float>() {{"fire",10.0f}, {"reload",10.0f}};
		SetMass(2.0f);
		Loaded = new SmallLaser();
	}
}
