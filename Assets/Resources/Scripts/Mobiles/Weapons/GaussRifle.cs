using UnityEngine;
using System.Collections;

public class GaussRifle : Weapon 
{
	public string Short = "Gauss Rifle";
	public string Long = "An rail gun that propels 16cc slugs by magnetic coils.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {"16cc Slug"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public GaussRifle()
	{
		Energy = new Dictionary<string,int>() {{"fire",6}, {"reload",3}};
		SetMass(8.5f);
	}
}
