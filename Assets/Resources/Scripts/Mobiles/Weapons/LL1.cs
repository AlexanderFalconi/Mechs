using UnityEngine;
using System.Collections;

public class LL1 : Weapon 
{
	public string Short = "LL-1";
	public string Long = "A large laser.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LL1()
	{
		Energy = new Dictionary<string,int>() {{"fire",40}};
		SetMass(6.0f);
	}
}
