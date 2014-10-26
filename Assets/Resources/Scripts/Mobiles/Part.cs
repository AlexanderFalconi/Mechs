using UnityEngine;
using System.Collections.Generic;

public class Part {
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
		float stabilization;
		foreach(Component item in Components)
			stabilization += item.GetStabilization();
		return Mathf.Floor(stabilization/Master.GetMass());
	}
	
	public int GetMeleeCR()
	{
		return 0;
	}
}