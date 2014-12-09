using UnityEngine;
using System.Collections.Generic;
using Config;

public class Reactor : Component 
{
	public float Power, Efficiency;

	public Reactor(float mass)
	{
		Efficiency = 100;//Full efficiency
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		SetMass(mass);
	}

    public override string GetSystem()
    {
        return "reactor";
    }

    public override void EventDamage(int dmg)
    {//Override
    	Efficiency -= Mathf.Pow(dmg, 2);
    	if(Efficiency < 0)
    	{
    		Efficiency = 0;
    		Status = Statuses.DESTROY;
    	}
    	else if(Efficiency < 100)
    		Status = Statuses.DAMAGE;
    	else
    		Status = Statuses.OK;
    }

	public override void Interval()
	{
		Installed.Master.AddEnergy(Power * Efficiency / 100);
		//Reactors do not recover from stun, base.Interval call is skipped.
		UpdateUI();//Need to update here because base.Interval call is skipped.
  	}
}