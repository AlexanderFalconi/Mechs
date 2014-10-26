using UnityEngine;
using System.Collections;

public class LRM5 : Weapon 
{
	public string Short = "LRM-5";
	public string Long = "A missile battery that stores up to 5 long-range missiles.";
	public int Capacity = 5;
	public int RateOfFire = 5;
	public List<string> Ammo = new List<string>() {"A-1 Missile"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LRM5()
	{
		Energy = new Dictionary<string,int>() {{"fire",5}, {"reload",5}};
		SetMass(1.75f);
	}
}