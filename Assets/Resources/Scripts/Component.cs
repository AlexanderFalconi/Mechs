using UnityEngine;
using System.Collections;

public class Component 
{
    public float Mass;
    public int Status = 0;//0 = OK, 1 = Stunned, 2 = Disabled, 3 = Destroyed
    public int Power;
    public void SetMass(float mass)
    {
    	Mass = mass;
    }
    public void EventDamage()
    {
    	if(Status < 3)
    		Status++;
    }
}