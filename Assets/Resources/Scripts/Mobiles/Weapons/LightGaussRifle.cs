using UnityEngine;
using System.Collections;

public class LightGaussRifle : Weapon 
{
	public string Short = "Light Gauss Rifle";
	public string Long = "An rail gun that propels 8cc slugs by magnetic coils.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"8cc Slug"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public GaussRifle()
	{
		Energy = new Dictionary<string,int>() {{"fire",5}, {"reload",1}};
		SetMass(3.5f);
	}
}
