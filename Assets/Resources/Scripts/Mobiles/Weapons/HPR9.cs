using UnityEngine;
using System.Collections;

public class HPR9 : Weapon 
{
	public string Short = "HPR-9";
	public string Long = "An heavy pulse rifle.";
	public int Capacity = 0;
	public int RateOfFire = 3;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HPR9()
	{
		Energy = new Dictionary<string,int>() {{"fire",16}};
		SetMass(2.75f);
	}
}
