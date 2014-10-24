using UnityEngine;
using System.Collections;

public class Component 
{
    private float Mass;
    public int Status = 0;//0 = OK, 1 = Stunned, 2 = Disabled, 3 = Destroyed
    public int Power;
    public Part Installed;

    public void EventInstall(Part part)
    {
        Installed = part;//What is it attached to
    }

    public void SetMass(float mass)
    {
    	Mass = mass;
    }

    public float GetMass()
    {
        return Mass;
    }

    public void EventDamage(int dmg)
    {
        Status += dmg;
    	if(Status > 3)
    		Status = 3;//0: ok, 1: stun, 2: damaged, 3: destroyed
    }
}