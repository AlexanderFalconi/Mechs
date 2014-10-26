using UnityEngine;
using System.Collections;

public class LPR357 : Weapon 
{
	public string Short = "LPR-357";
	public string Long = "An light pulse rifle.";
	public int Capacity = 0;
	public int RateOfFire = 3;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LPR357()
	{
		Energy = new Dictionary<string,int>() {{"fire",4}};
		SetMass(1.25f);
	}
}
