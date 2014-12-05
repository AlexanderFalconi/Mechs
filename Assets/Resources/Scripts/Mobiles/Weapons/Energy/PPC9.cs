using UnityEngine;
using System.Collections.Generic;

public class PPC9 : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public PPC9()
	{
		Short = "PPC-9";
		Long = "A particle projection cannon.";
		Capacity = 1;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 2}, {"waiting", 0}};
		Ammo = new List<string>() {};
		Energy = new Dictionary<string,float>() {{"fire",60.0f}, {"reload",60.0f}};
		SetMass(7.0f);
		Loaded = new ParticleBeam();
	}
}
