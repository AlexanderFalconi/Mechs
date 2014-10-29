using UnityEngine;
using System.Collections.Generic;

public class Reactor : Component 
{
	private float Energy;
	private static Dictionary<string,float> ReactorTable = new Dictionary<string,float>() 
	{
		{"m6 fusion", 25.0f}, {"m11 fusion", 23.0f}, {"m157 fusion", 21.0f}, {"fission", 15.0f}, {"combustion", 3.0f}, {"solar", 1.0f}
	};

	public Reactor(float mass, string type)
	{
		Dictionary<string,float> increases = new Dictionary<string,float>() {{"m6 fusion",1.0f}, {"m11 fusion",1.0f}, {"m157 fusion",1.0f}, {"fission",1.0f}, {"combustion",1.0f}, {"solar",1.0f}};
		float energy = ReactorTable[type];//Energy starts at this value
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		SetMass(mass);
		for(float i = 0.5f; i <= mass; i+=0.5f)
		{//Find energy value at mass
			increases[type] *= 0.95f;
			energy += ReactorTable[type]*increases[type];
		}
		Energy = energy;
	}

	public override float EventGeneratePower()
	{
		float efficiency = 100.0f - (float)Status;
		return Energy * efficiency;
	}

    public override void EventDamage(int dmg)
    {//Override
    	Status += dmg*dmg;
    	if(Status > 100)
    		Status = 100;
    }
}