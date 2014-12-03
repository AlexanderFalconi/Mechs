using UnityEngine;
using System.Collections.Generic;

public class Reactor : Component 
{
	public float Power;

	public Reactor(float mass)
	{
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
    	Status += dmg*dmg;
    	if(Status > 100)
    		Status = 100;
    }

	public override void Interval()
	{
		if(GetStatus() == STATUS_OK)
		{
			float efficiency = 1.0f - (float)GetStatus();
			if(efficiency < 0.0f)
				efficiency = 0.0f;
			Installed.Master.AddEnergy(Power * efficiency);
		}
		//Reactors do not recover from stun, base.Interval call is skipped.
		UpdateUI();//Need to update here because base.Interval call is skipped.
  	}
}