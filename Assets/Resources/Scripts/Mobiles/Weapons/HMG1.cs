using UnityEngine;
using System.Collections;

public class HMG1 : Weapon 
{
	public string Short = "HMG-1";
	public string Long = "A fully automatic heavy machinegun.";
	public int Capacity = 50;
	public int RateOfFire = 20;
	public List<string> Ammo = new List<string>() {"50 Caliber Bullets"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public HMG1()
	{
		Energy = new Dictionary<string,int>() {{"fire",1}, {"reload",1}};
		SetMass(0.75f);
	}
}
