using UnityEngine;
using System.Collections;

public class Actuator : Component 
{
	public Actuator (float mass) 
	{
		SetMass(mass);
	}

    public override string GetSystem()
    {
        return "actuator";
    }
}