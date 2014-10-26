using UnityEngine;
using System.Collections;

public class ML24 : Weapon 
{
	public string Short = "ML-24";
	public string Long = "A medium laser.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ML24()
	{
		Energy = new Dictionary<string,int>() {{"fire",25}};
		SetMass(4.0f);
	}
}
