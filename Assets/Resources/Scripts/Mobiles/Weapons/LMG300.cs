using UnityEngine;
using System.Collections;

public class LMG300 : Weapon 
{
	public string Short = "HMG-20";
	public string Long = "A fully automatic light machinegun.";
	public int Capacity = 200;
	public int RateOfFire = 30;
	public List<string> Ammo = new List<string>() {"5.56x54mm Bullets"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LMG300()
	{
		Energy = new Dictionary<string,int>() {{"fire",1}, {"reload",1}};
		SetMass(0.25f);
	}
}
