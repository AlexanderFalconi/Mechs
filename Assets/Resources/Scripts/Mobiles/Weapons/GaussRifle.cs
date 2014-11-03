using UnityEngine;
using System.Collections.Generic;

public class GaussRifle : Weapon 
{
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public GaussRifle()
	{
		Short = "Gauss Rifle";
		Long = "An rail gun that propels 16cc slugs by magnetic coils.";
		Capacity = 1;
		Ammo = new List<string>() {"16cc Slug"};
		Energy = new Dictionary<string,float>() {{"fire",6.0f}, {"reload",3.0f}};
		SetMass(8.5f);
	}

    public override void EventDamage(int dmg)
    {//Override
    	base.EventDamage(dmg);
   		Installed.EventDamage(new AmmoExplosion(20));//Component explodes!
    }
}
