using UnityEngine;
using System.Collections.Generic;

public class Component 
{
    private float Mass;
    public int Status = 0;//0 = OK, 1 = Stunned, 2 = Disabled, 3 = Destroyed
    public Dictionary<string,float> Energy = new Dictionary<string,float>();
    public Part Installed;
    public string Short, Long;

    public virtual void EventInstall(Part part)
    {
        Installed = part;//What is it attached to
    }

    public virtual void EventUninstall()
    {
        Installed = null;//What is it attached to
    }

    public void SetMass(float mass)
    {
    	Mass = mass;
    }

    public float GetMass()
    {
        return Mass;
    }

    public virtual void EventDamage(int dmg)
    {
        Status += dmg;
    	if(Status > 3)
    		Status = 3;//0: ok, 1: stun, 2: damaged, 3: destroyed
    }

    public virtual float GetBalance()
    {
        return 0.0f;
    }
    
    public virtual float GetRotation()
    {
        return 0.0f;
    }

    public virtual float GetMobility()
    {
        return 0.0f;
    }

    public virtual float GetStabilization()
    {
        return 0.0f;
    }

    public virtual float GetLocomotion()
    {
        return 0.0f;
    }

    public virtual float GetAccuracy()
    {
        return 0.0f;
    }

    public virtual float EventGeneratePower()
    {
        return 0.0f;
    }

    public virtual bool IsMeleeWeapon()
    {
        return false;
    }

    public virtual int EventReloading(int max)
    {
        return 0;
    }
}