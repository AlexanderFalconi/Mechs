using UnityEngine;
using System.Collections.Generic;

public class Part 
{
	public const int STATUS_OK = 0;
	public const int STATUS_DESTROY = 1;
	public const int STATUS_SEVER = 2;
	public string Short;
	public Dictionary<string,int> HitTable;
	public Dictionary<string,float> Proportion = new Dictionary<string,float>() {{"max mass", 0.0f}, {"mass", 0.0f}};
	public List<Component> Components = new List<Component>();
	public Dictionary<string,Armor> Armors = new Dictionary<string,Armor>() {{"internal", null}, {"external", null}, {"rear", null}};
	public List<string> Melee = new List<string>();
	public Part Parent;//Connected to
	public float Force = 0.0f;
	public List<Part> Children = new List<Part>();
	public List<Interface> UI = new List<Interface>();
	public bool IsTapped = false;
	public int Status = STATUS_OK;
	public float Accuracy = 0.0f;
	public float Rotation = 0.0f;
	public Mech Master;

	public int GetStatus()
	{
		if(Parent != null && (Parent.GetStatus() != STATUS_OK))
			return STATUS_SEVER;
		else
			return Status;//OK
	}

	public void Attach(Part limb, Mech who)
	{
		Master = who;
		Parent = limb;
		limb.Children.Add(Parent);
	}

	public void Attach(Mech who)
	{//This is the core component
		Master = who;
		Parent = null;
	}

	public string GetShort()
	{
		return Short;
	}

	public float GetMass()
	{
		return Proportion["mass"];
	}

	public virtual float Install(Component comp)
	{
		Proportion["mass"] += comp.GetMass();//Increment used mass
		Components.Add(comp);//Add to inventory
		comp.EventInstall(this);//Attach to part
		return Proportion["max mass"] - Proportion["mass"];
	}

	public void AddArmor(string loc, Armor armor)
	{
		if(Armors[loc] != null)
			Proportion["mass"] -= Armors[loc].Mass;
		Armors[loc] = armor;
		Proportion["mass"] += armor.Mass;
	}
	
	public virtual int GetMeleeCR()
	{
		return 0;
	}

	public void Consolidate(Ammunition ammo)
	{
		int max = ammo.Bundle - ammo.Amount;
		foreach(Component item in Components)
		{
			if(item.Short == ammo.Short)//Same types
				ammo.Amount += item.EventReloading(max);
			if(ammo.Amount >= ammo.Bundle)
				return;//Done, found all we can
		}
	}

	public virtual int EventDamage(Ammunition ammo, string side = "external")
	{
		int inflicted = 0;
		int crit = 0;
		int damage, hardness;
		if(Armors[side] != null)
		{
			Debug.Log(Armors[side].Short);
			hardness = Armors[side].Hardness[ammo.DamageType];
			if(ammo.Damage["remaining"] < hardness)
				return 0;//Armor absorbs the blow, but its ineffective.
			damage = ammo.Damage["remaining"] / hardness;//Convert to relative damage based on armor hardness
			if(Armors[side].HP >= damage)
			{//External armor soaks
				inflicted += damage;//Record damage
				Armors[side].HP -= damage;
				ammo.Damage["remaining"] = 0;//Entire hit absorbed
			}
			else
			{
				inflicted += Armors[side].HP;//Record damage
				ammo.Damage["remaining"] -= damage * Armors[side].HP;//Part of the hit absorbed
				Armors[side].HP = 0;//Shear off all armor
			}
			Debug.Log(side+": "+Armors[side].HP);
		}
		if(ammo.Damage["remaining"] > 0)//Continue to internal
		{
			Debug.Log("ENTERED INTERNAL");
			hardness = Armors["internal"].Hardness[ammo.DamageType];
			if(ammo.Damage["remaining"] < hardness)
				return 0;//Armor absorbs the blow, but its ineffective.
			damage = ammo.Damage["remaining"] / hardness;//Convert to relative damage based on armor hardness
			if(Armors["internal"].HP >= damage)
			{//Internal armor soaks
				inflicted += damage;//Record damage
				crit = damage;
				Armors["internal"].HP -= damage;
				ammo.Damage["remaining"] = 0;//Entire hit absorbed
			}
			else
			{
				crit = Armors["internal"].HP;
				inflicted += Armors["internal"].HP;//Record damage
				damage -= Armors["internal"].HP;
				ammo.Damage["remaining"] -= Armors["internal"].HP * hardness;//Absorm some of the blow
				Armors["internal"].HP = 0;//Shear off all armor
			}
			Debug.Log("Internal: "+Armors[side].HP);
		}
		Debug.Log("Inflicted: "+inflicted);
		if(crit > 0)
			EventCritical(crit);//Check for crits last because of possible ammo explosions
		if(Armors["internal"].HP < 1)
			EventDestroyed();//Destroyed
		return inflicted;
	}

	private void EventCritical(int damage)
	{
		Debug.Log("Criticals: "+damage);
		float possible = Proportion["max mass"];
		float result;
		Dictionary<Component,int> crits = new Dictionary<Component,int>();
		for(int i = 0; i < damage; i++)
		{
			result = Random.Range(0.0f, possible);
			Debug.Log("Try: "+i+" Rand: "+result);
			foreach(Component item in Components)
			{
				result -= item.GetMass();
				if(result <= 0)
				{
					Debug.Log("Crit on "+item);
					if(crits.ContainsKey(item))
						crits[item]++;
					else
						crits[item]=1;
					break;//Finished
				}
			}
		}
		foreach(KeyValuePair<Component,int> specific in crits)
			specific.Key.EventDamage(specific.Value);
	}

	public virtual void EventDestroyed()
	{
		foreach(Part limb in Children)
			limb.EventDestroyed();
		if(Parent == null)//Core destroyed
			Master.EventDestroyed();
	}	

	public virtual int GetMeleeDamage()
	{
		return 0;
	}

	public virtual void EventMeleeBacklash()
	{
		
	}

	public virtual float GetBalance()
	{
		return 0.0f;
	}

	public virtual float GetLocomotion()
	{
		return 0.0f;
	}

	public virtual float GetMobility()
	{
		return 0.0f;
	}
	public virtual int GetAccuracy()
	{
		return 0;
	}

	public virtual float[] GetFiringArc()
	{
		float[] arc = new float[] {0.0f, 0.0f};
		return arc;
	}

	public string GetUILong()
	{
		if(Armors["rear"] != null)
			return Armors["external"].HP+"/"+Armors["rear"].HP+"\n"+Armors["internal"].HP;
		else
			return Armors["external"].HP+"\n"+Armors["internal"].HP;
	}

    public void BindUI(Interface ui)
    {
        UI.Add(ui);
    }

    public virtual void InitActions()
    {
    	//TEMP: Some day dynamically generate the armor tables here
    }

    public virtual void Interval()
    {
    	IsTapped = false;
    	Accuracy = 0.0f;
    	Rotation = 0.0f;
		Force = 0.0f;//Reset limb attributes
		foreach(Component component in Components)
			component.Interval();
    }

    public virtual void UpdateUI()
    {
        foreach(Interface iface in UI)
            iface.UpdateUI();
    }
}