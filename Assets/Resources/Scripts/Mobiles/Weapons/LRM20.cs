using UnityEngine;
using System.Collections;

public class LRM20 : Weapon 
{
	public string Short = "LRM-20";
	public string Long = "A missile battery that stores up to 20 long-range missiles.";
	public int Capacity = 20;
	public int RateOfFire = 5;
	public List<string> Ammo = new List<string>() {"A-1 Missile"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM20()
	{
		Energy = new Dictionary<string,int>() {{"fire",20}, {"reload",20}};
		SetMass(8.5f);
	}
}