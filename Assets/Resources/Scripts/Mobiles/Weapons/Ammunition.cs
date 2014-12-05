using UnityEngine;
using System.Collections.Generic;

public class Ammunition : Component 
{
    public List<string> Ammo;
	public string PrefabID, SoundFX;
	public float Combustibility;
	public int Amount;
    public int Bundle;
	public Dictionary<string,int> Damage = new Dictionary<string,int>() {{"max", 0}, {"remaining", 0}};
	public string DamageType;
    public int Range;
    public Weapon Loader;

    public override string GetSystem()
    {
        return "ammunition";
    }
    
    public override float GetMass()
    {
        return 0.25f;
    }

    public override void EventDamage(int dmg)
    {//Override
    	float result = Random.Range(0.1f, 100.0f);
        base.EventDamage(dmg);
    	if(result < Combustibility * Amount)
    		Installed.EventDamage(new AmmoExplosion(Damage["max"] * Amount));//Ammo explodes!
    }

    public override int EventReloading(int max)
    {
        if(DamageType == "energy")
            return max;//Energy weapons are infinite
        else
        {
            if(Amount < max)//Not enough
                max = Amount;//Take all
            Amount -= max;//Take requested
            return max;
        }
    }

    public override string GetShort()
    {
        if(Amount == 1)
            return "1 "+Short;
        else
            return Short+" (x"+Amount+")";
    }
}