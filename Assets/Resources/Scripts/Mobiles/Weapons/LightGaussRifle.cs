using UnityEngine;
using System.Collections.Generic;

public class LightGaussRifle : Weapon 
{
	public int RateOfFire = 1;
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public LightGaussRifle()
	{
		Short = "Light Gauss Rifle";
		Long = "An rail gun that propels 8cc slugs by magnetic coils.";
		Capacity = 1;
		Ammo = new List<string>() {"8cc Slug"};
		Energy = new Dictionary<string,float>() {{"fire",5.0f}, {"reload",1.0f}};
		SetMass(3.5f);
	}

    public override void EventDamage(int dmg)
    {//Override
     	base.EventDamage(dmg);
   		Installed.EventDamage(new AmmoExplosion(10));//Component explodes!
    }
}
