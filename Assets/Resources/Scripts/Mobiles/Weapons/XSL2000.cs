using UnityEngine;
using System.Collections;

public class XSL2000 : Weapon 
{
	public string Short = "XSL-2000";
	public string Long = "An extra-small laser.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public XSL2000()
	{
		Energy = new Dictionary<string,int>() {{"fire",6}};
		SetMass(1.0f);
	}
}
