using UnityEngine;
using System.Collections;

public class MMG20 : Weapon 
{
	public string Short = "HMG-20";
	public string Long = "A fully automatic medium machinegun.";
	public int Capacity = 50;
	public int RateOfFire = 24;
	public List<string> Ammo = new List<string>() {"7.62x51mm Bullets"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public MMG20()
	{
		Energy = new Dictionary<string,int>() {{"fire",1}, {"reload",1}};
		SetMass(0.5f);
	}
}
