using UnityEngine;
using System.Collections.Generic;

public class Part 
{
	public string Short;
	public Dictionary<string,int> HitTable;
	public Dictionary<string,float> Proportion = new Dictionary<string,float>() {{"max mass", 0.0f}, {"mass", 0.0f}};
	public List<Component> Components = new List<Component>();
	public Dictionary<string,Armor> Armors = new Dictionary<string,Armor>() {{"internal", null}, {"external", null}, {"rear", null}};
	public List<string> Melee = new List<string>();
	public Part Parent;//Connected to
	public List<Part> Children = new List<Part>();
	public Mech Master;

	public void Attach(Part limb, Mech who)
	{
		Master = who;
		Parent = limb;
		limb.Children.Add(Parent);
	}

	public float Install(Component part)
	{
		Proportion["mass"] += part.GetMass();//Increment used mass
		Components.Add(part);//Add to inventory
		part.EventInstall(this);//Attach to part
		return Proportion["max mass"] - Proportion["mass"];
	}

	public void AddArmor(string loc, float mass)
	{
		if(Armors[loc] == null)
		{
			Armors[loc] = new Armor(mass);
			Proportion["mass"] += mass;
		}
		else
		{
			Armors[loc].AddArmor(mass);
			Proportion["mass"] += mass;
		}
	}

	public float GetStabilization()
	{
		float stabilization = 0.0f;
		foreach(Component item in Components)
			stabilization += item.GetStabilization();
		return Mathf.Floor(stabilization/Master.GetMass());
	}
	
	public int GetMeleeCR()
	{
		return 0;
	}

	public int EventReload(string compatible, int max)
	{
		int found = 0;
		int total = 0;
		foreach(Component item in Components)
		{
			if(item.Short == compatible)
			{
				found = item.EventReloading(max);
				total += found;
				max -= found;
			}
			if(max < 1)
				break;
		}
		return total;
	}

	public int EventDamage(Ammunition ammo, string side = "external")
	{
		int inflicted = 0;
		int crit = 0;
		int result, damage, damageR, hardness;
		hardness = Armors[side].Hardness[ammo.DamageType];
		if(ammo.Damage < Armors[side].Hardness[ammo.DamageType])
		{
			ammo.Damage = 0;
			return 0;//Armor absorbs the blow, but its ineffective.
		}
		damage = ammo.Damage / hardness;//Convert to relative damage based on armor hardness
		damageR = ammo.Damage % hardness;//The remainder does not necessary truncate
		result = Random.Range(1, hardness);//Chance of it applying depends on how high
		if(result <= damageR)//Check to see if extra damage
			damage++;//Add 1 extra damage
		if(Armors[side].HP >= damage)
		{//External armor soaks
			inflicted += damage;//Record damage
			damage = 0;
			Armors[side].HP -= damage;
			ammo.Damage = 0;//Armor absorbs the blow
		}
		else
		{
			inflicted += Armors[side].HP;//Record damage
			damage -= Armors[side].HP;
			ammo.Damage -= Armors[side].HP * hardness;//Absorm some of the blow
			Armors[side].HP = 0;//Shear off all armor
			if(Armors["internal"].HP >= damage)
			{//Internal armor soaks
				inflicted += damage;//Record damage
				crit = damage;
				Armors["internal"].HP -= damage;
				ammo.Damage = 0;
			}
			else
			{
				crit = Armors["internal"].HP;
				inflicted += Armors["internal"].HP;//Record damage
				damage -= Armors["internal"].HP;
				ammo.Damage -= Armors["internal"].HP * hardness;//Absorm some of the blow
				Armors["internal"].HP = 0;//Shear off all armor
			}
		}
		if(crit > 0)
			EventCritical(crit);//Check for crits last because of possible ammo explosions
		return inflicted;
	}

	private void EventCritical(int damage)
	{
		float possible = Proportion["max mass"];
		float result;
		Dictionary<Component,int> crits = new Dictionary<Component,int>();
		for(int i = 0; i < damage; i++)
		{
			result = Random.Range(0.0f, possible);
			foreach(Component item in Components)
			{
				result -= item.GetMass();
				if(result <= 0)
				{
					if(crits.ContainsKey(item))
						crits[item]++;
					else
						crits[item]=1;
				}
			}
		}
		foreach(KeyValuePair<Component,int> specific in crits)
			specific.Key.EventDamage(specific.Value);
	}	

	public float EventGeneratePower()
	{
		float power = 0.0f;
		foreach(Component gen in Components)
			power += gen.EventGeneratePower();
		return power;
	}

	public int GetMeleeDamage()
	{
		return 0;
	}

	public void EventBacklash()
	{
		
	}

	public int GetAccuracy()
	{
		return 0;
	}

	public float[] GetFiringArc()
	{
		float[] arc = new float[] {0.0f, 0.0f};
		return arc;
	}
}