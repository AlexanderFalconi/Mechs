using UnityEngine;
using System.Collections;

public class LRM10 : Weapon 
{
	public string Short = "LRM-10";
	public string Long = "An AegisSeries LRM-10 missile battery that stores up to 10 long-range missiles.";
	public int Capacity = 10;
	public int RateOfFire = 5;
	public List<string> Ammo = new List<string>() {"Arrow-1 Missile"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM10()
	{
		Energy = new Dictionary<string,int>() {{"fire",10}, {"reload",10}};
		SetMass(4.5f);
	}
}