using UnityEngine;
using System.Collections.Generic;
using Config;

public class Weapon : Component 
{
	public int Discharged = 0;//Has the weapon been fired?
	public int Capacity;
	public int Amount = 0;
	public Ammunition Loaded;
	public Entity Selected;
	public List<string> Ammo;
	public Dictionary<string,int> RateOfFire;
	public Dictionary<string,int> Reload;
	public DynamicWeapon UIButton;

    public override string GetSystem()
    {
        return "weapon";
    }

	public void EventReload(int max)
	{
		if(Loaded == null)
			return;//Need to load something first
		if(Reload["waiting"] > 0)
			return;//Already reloading
		if(!Installed.Master.EventDrainEnergy(Energy["reload"]))
			return;//Not enough energy
		if((max == 0) || (max >= Capacity))
			max = Capacity;
		Amount +=Loaded.EventReloading(max);//Transfer ammo from loaded bundle into weapon
		Installed.Consolidate(Loaded);//Try to consolidate ammo into the loaded ammunition
		if(Installed.Master.Environment.Phase != Phases.DEPLOY)
			Reload["waiting"] = Reload["delay"];//Set reload lag
		//else reload is free
		UpdateUI();
	}

	public void EventUnload()
	{
		Loaded.Loader = null;
		Loaded = null;
		UpdateUI();
	}

	public void EventLoad(Ammunition ammo)
	{
		if(Loaded != null)
			return;//Already loaded
		Loaded = ammo;//Load and bind new ammo into this weapon
		ammo.Loader = this;//Bind new ammo to weapon
		EventReload(ammo.Loader.Amount);
		UpdateUI();
	}

	public bool CanFire()
	{
		if(Installed.IsTapped)
			return false;//Can't shoot after certain melees
		else if(Loaded == null)
			return false;
		else if(Amount < 1)
			return false;
		else
			return true;
	}

	public void Select(Entity target)
	{
		Selected = target;
		if(target != null)
			Installed.Master.Environment.RegisterWeapon(this);
		else
			Installed.Master.Environment.UnregisterWeapon(this);
		UpdateUI();
	}

    public bool EventDischarge()
    {
        if(Amount < 1)
            return false;
        Amount--;
        if(!Installed.Master.EventDrainEnergy(Energy["fire"]))
        	return false;
        Loaded.Damage["remaining"] = Loaded.Damage["max"];//Prime the shot
        UpdateUI();
        return true;
    }

	public string GetAmmoReport()
	{
		return Amount.ToString()+"/"+Capacity.ToString();
	}

	public override void Interval()
	{

		if(GetStatus() == Statuses.OK)
		{
			if(Reload["waiting"] > 0)
	        	Reload["waiting"]--;//Tick through reload delay
		}
        base.Interval();
  	}
}
