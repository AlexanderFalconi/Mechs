using UnityEngine;
using System.Collections.Generic;

public class LightGaussRifle : Weapon 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LightGaussRifle()
	{
		Short = "Light Gauss Rifle";
		Long = "A rail gun that propels 8cc slugs by magnetic coils.";
		Capacity = 1;
		RateOfFire = new Dictionary<string,int>() {{"max",1}, {"set",1}};
		Reload = new Dictionary<string,int>() {{"delay", 1}, {"waiting", 0}};
		Ammo = new List<string>() {"8cc Slugs"};
		Energy = new Dictionary<string,float>() {{"fire",5.0f}, {"reload",1.0f}};
		SetMass(3.5f);
	}

    public override void EventDamage(int dmg)
    {//Override
     	base.EventDamage(dmg);
   		Installed.EventDamage(new AmmoExplosion(10));//Component explodes!
    }
}
