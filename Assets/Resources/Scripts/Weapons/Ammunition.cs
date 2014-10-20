using UnityEngine;
using System.Collections;

public class Ammunition : Component 
{
	public string PrefabID;
	public float Combustibility;
	public int Amount;
    public void EventDamage()
    {//Override
    	float result = Random.Range(0.1f, 100.0f);
    	if(result < Combustibility * Amount)
    		eventDamage(Damage * Amount);//Ammo explodes! 
    }
}
