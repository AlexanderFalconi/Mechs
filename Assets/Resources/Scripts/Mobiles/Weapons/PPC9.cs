using UnityEngine;
using System.Collections;

public class PPC9 : Weapon 
{
	public string Short = "PPC-9";
	public string Long = "A particle projection cannon.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public PPC9()
	{
		Energy = new Dictionary<string,int>() {{"fire",60}};
		SetMass(7.0f);
	}
}
