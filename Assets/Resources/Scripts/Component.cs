using UnityEngine;
using System.Collections;

public class Component 
{
    private float Mass;
    public int Status = 0;//0 = OK, 1 = Stunned, 2 = Disabled, 3 = Destroyed
    public int Power;
    public Mech Installed;
    public string Attached;

    public void EventAttach(Mech who, string location)
    {
        Installed = who;//What is it attached to
        Attached = location;//Where is it attached
    }

    public void SetMass(float mass)
    {
    	Mass = mass;
    }

    public float GetMass()
    {
        return Mass;
    }

    public void EventDamage()
    {
    	if(Status < 3)
    		Status++;
    }
}