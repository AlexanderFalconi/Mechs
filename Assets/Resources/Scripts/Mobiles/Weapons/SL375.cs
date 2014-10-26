using UnityEngine;
using System.Collections;

public class SL375 : Weapon 
{
	public string Short = "SL-375";
	public string Long = "A small laser.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SL375()
	{
		Energy = new Dictionary<string,int>() {{"fire",10}};
		SetMass(2.0f);
	}
}
