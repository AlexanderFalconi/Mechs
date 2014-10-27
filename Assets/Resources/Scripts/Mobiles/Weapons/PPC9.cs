using UnityEngine;
using System.Collections.Generic;

public class PPC9 : Weapon 
{
	public string Short = "PPC-9";
	public string Long = "A particle projection cannon.";
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public PPC9()
	{
		Capacity = 1;
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",60.0f}};
		SetMass(7.0f);
	}
}
