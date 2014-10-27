using UnityEngine;
using System.Collections;

public class Ammunition : Component 
{
	public string PrefabID;
	public float Combustibility;
	public int Amount;
	public int Damage = 100;
	public string DamageType;
    public int Range;

    public void EventDamage()
    {//Override
    	float result = Random.Range(0.1f, 100.0f);
    	if(result < Combustibility * Amount)
    		Installed.EventDamage(new AmmoExplosion(Damage * Amount));//Ammo explodes!
    }

    public bool EventDischarge()
    {
        if(Amount < 1)
            return false;
        Amount--;
        Installed.Master.Energy -= Energy["fire"];
        return true;
    }

    public int EventReloading(int max)
    {
        if(Amount < max)//Not enough
            max = Amount;//Take all
        Amount -= max;//Take requested
        return max;
    }
}