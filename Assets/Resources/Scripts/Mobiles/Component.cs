using UnityEngine;
using System.Collections.Generic;

public class Component 
{
    private float Mass;
    public int Status = 0;//0 = OK, 1 = Stunned, 2 = Disabled, 3 = Destroyed
    public Dictionary<string,float> Energy = new Dictionary<string,float>();
    public Part Installed;
    public bool Selected = false;
    public string Short, Long;
    public List<Interface> UI = new List<Interface>();

    public virtual string GetSystem()
    {
        return "component";
    }

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

    public virtual float GetMass()
    {
        return Mass;
    }

    public virtual void EventDamage(int dmg)
    {
        Status += dmg;
    	if(Status > 3)
    		Status = 3;//0: ok, 1: stun, 2: damaged, 3: destroyed
        Debug.Log("CRIT ON: "+this+" "+Status);
    }

    public virtual bool IsMeleeWeapon()
    {
        return false;//Isn't a melee weapon
    }

    public virtual int EventReloading(int max)
    {
        return 0;//Doesn't reload
    }

    public virtual bool AddPersonell(Pilot pilot)
    {
        return false;//Doesn't hold personell
    }

    public string GetStatusLong()
    {
        switch(Status)
        {
            case 0:
                return "OK";
            case 1:
                return "Stunned";
            case 2: 
                return "Damaged";
            default: 
                return "Destroyed";
        }
    }

    public virtual string GetShort()
    {
        return Short;
    }

    public void BindUI(Interface ui)
    {
        UI.Add(ui);
    }

    public void UpdateUI()
    {
        foreach(Interface ui in UI)
            ui.UpdateUI();
    }

    public virtual void Interval()
    {
        if(Status == 1)
            Status = 0;//Recover from stun
        if(Energy.ContainsKey("passive"))//If uses passive energy, drain
            Installed.Master.EventDrainEnergy(Energy["passive"]);
        UpdateUI();
    }
}