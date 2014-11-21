using UnityEngine;
using System.Collections.Generic;

public class Weapon : Component 
{
	public int Discharged = 0;//Has the weapon been fired?
	public int Capacity;
	public int Amount = 0;
	public Ammunition Loaded;
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
		if(!Installed.Master.AddEnergy(-Energy["reload"]))
			return;//Not enough energy
		if((max == 0) || (max >= Capacity))
			max = Capacity;
		Amount +=Loaded.EventReloading(max);//Transfer ammo from loaded bundle into weapon
		Installed.Consolidate(Loaded);//Try to consolidate ammo into the loaded ammunition
		Reload["waiting"] = Reload["delay"];//Set reload lag
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
		UpdateUI();
	}

	public void Select()
	{
		if(Loaded == null)
			Installed.Master.OrderLoad(this);
		else if(Amount < 1)
			Installed.Master.OrderReload(this);
		else
		{
			if(Selected)
				Selected = false;
			else
				Selected = true;	
		}
		UpdateUI();
	}

    public bool EventDischarge()
    {
        if(Amount < 1)
            return false;
        Amount--;
        if(!Installed.Master.AddEnergy(-Energy["fire"]))
        	return false;
        Loaded.Damage["remaining"] = Loaded.Damage["max"];//Prime the shot
        UpdateUI();
        return true;
    }

	public string GetAmmoReport()
	{
		return Amount.ToString()+"/"+Capacity.ToString();
	}
}
