using UnityEngine;
using System.Collections;

public class Ammunition : Component 
{
	public string PrefabID;
	public float Combustibility;
	public int Amount;
	public int Damage = 100;
	public string DamageType;

    public void EventDamage()
    {//Override
    	float result = Random.Range(0.1f, 100.0f);
    	if(result < Combustibility * Amount)
    		Installed.EventDamage(Installed, new AmmoExplosion(Damage * Amount));//Ammo explodes!
    }
}