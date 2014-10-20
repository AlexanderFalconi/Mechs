using UnityEngine;
using System.Collections.Generic;

public class Mech : Mobile {
	public static List<string> Limbs = new List<string>() {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Dictionary<string,Dictionary<string,int>> HitTable = new Dictionary<string,Dictionary<string,int>>();
	public Dictionary<string,Dictionary<string,float>> Proportion = new Dictionary<string,Dictionary<string,float>>();
	public Dictionary<string,List<Component>> Components = new Dictionary<string,List<Component>>();
	public Dictionary<string,Dictionary<string,Armor>> Armors = new Dictionary<string,Dictionary<string,Armor>>();
	public Dictionary<string,int> Speed = new Dictionary<string,int>() {{"jump", 0}, {"walk", 0}, {"run", 0}, {"momentum", 0}, {"moved", 0}};
	private string Posture = "stand";
	public int Size = 0;//1: infantry, 2: suit, 3: car, 4: tank, 5: light mech, 6: medium mech, 7: heavy mech, 8: small structure, 9: large structure, 10: tile
	private float Mass = 0.0f;
	private Chassis InternalStructure;
	public Pilot PilotOb;
	public Weapon SelectedWeapon;
	public int[] position;//TEMP?

	public Mech() 
	{
		foreach(KeyValuePair<string,List<Component>> type in Components)
		{
			foreach(Component item in type.Value)
				Debug.Log(type.Key+": "+item);
			Debug.Log(Proportion[type.Key]["mass"]+"/"+Proportion[type.Key]["max mass"]);
		}
		//Hardcode movement temporarily
		Speed["jump"] = 1;//Actually jump jet based
		Speed["walk"] = 3;//Energy/reactor based
		Speed["run"] = 5;
	}

	public void SetPilot(Pilot pilot)
	{
		PilotOb = pilot;
	}

	public void SetMass(float mass, Chassis chassis)
	{
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Mech mass must be in increments of 0.25.");
		float totalMassRem = 100.0f;//Total mech mass
		float totalIntRem = totalMassRem * chassis.Internal;//Total internal structure portion
		totalIntRem -= totalIntRem%0.25f;//Round down to 0.25.
		InternalStructure = chassis;//Set internal
		Mass = mass;//Set mass
		if(mass < 10.0f)
			Debug.LogError("Mech mass must be at least 10.0.");
		else if(mass <= 40.0f)
			Size = 5;
		else if(mass <= 70.0f)
			Size = 6;
		else if(mass <= 100.0f)
			Size = 7;
		else
			Debug.LogError("Mech mass must be at most 100.0.");
		foreach(string item in Proportion.Keys)
		{
			float tmp = Proportion[item]["ratio"] * mass;//Multiply total by limb ratio
			tmp -= tmp%0.25f;//Round down to minimums of 0.25
			Proportion[item]["max mass"] = tmp;//Set limb ratio
			totalMassRem -= tmp;//Reduce total accordingly
			tmp *= chassis.Internal;//Get the portion of internal structure
			tmp -= tmp%0.25f;//Round down to minimums of 0.25
			totalIntRem -= tmp;//Reduce total accordingly
			Armors[item]["internal"] = new Armor(tmp);
			Proportion[item]["mass"] = tmp;//Set mass equal to internal structure as initial
		}
		Proportion["center torso"]["max mass"] += totalMassRem;//Add excess to center torso
		Armors["center torso"]["internal"].AddArmor(totalIntRem);
		Proportion["center torso"]["mass"] += totalIntRem;//Add excess to center torso
	}

	public float AddComponent(string limb, Component part)
	{
		Proportion[limb]["mass"] += part.Mass;//Increment used mass
		Components[limb].Add(part);
		return Proportion[limb]["max mass"] - Proportion[limb]["mass"];
	}

	public void AddArmor(string limb, string loc, float mass)
	{
		if(Armors[limb][loc] == null)
		{
			Armors[limb][loc] = new Armor(mass);
			Proportion[limb]["mass"] += mass;
		}
		else
		{
			Armors[limb][loc].AddArmor(mass);
			Proportion[limb]["mass"] += mass;
		}
	}

	public string GetClass()
	{
		if(Mass < 10.0f)
			return "Ultra-Light";
		else if(Mass <= 20.0f)
			return "Super-Light";
		else if(Mass <= 40.0f)
			return "Light";
		else if(Mass <= 70.0f)
			return "Medium";
		else if(Mass <= 90.0f)
			return "Heavy";
		else// if(Mass <= 100.0f)
			return "Super-Heavy";
	}

	private void Interval()
	{
		Speed["momentum"] = 0;
		Speed["moved"] = 0;
		//Reset firing
	}

	public void OrderMove(GameObject target)
	{
		Debug.Log(isReady);
		Debug.Log(Speed);
		if((isReady == false) || (Speed["moved"] >= Speed["run"]))
			return;//Can't move anymore
		else
		{
			Speed["moved"]++;
			isReady = false;
		}
		base.OrderMove(target);
	}

	public void OrderFire(GameObject target)
	{
		//This needs to set and follow a route, checking targets along the way.
		base.OrderFire(target, SelectedWeapon.Loaded);
	}

	private void EventCharge()
	{

	}

	private void EventCrush()
	{
		
	}

	private void EventAttack(GameObject target, Ammunition ammo)
	{
		float result;
		int accuracy = PilotOb.Gunnery;//Initialize at skill
		accuracy += GetRangePenalty();
		accuracy += GetMovementPenalty();
		accuracy += GetAccuracyPenalty();//Lost actuators or other circumstances
		if(target.tag != "Tile")
			accuracy += target.GetComponent<Mech>().GetDodge();//not yet set
		if(accuracy > 11)
			accuracy = 11;
		result = Random.Range(0.1f, 100.0f);
		//if hit
		//eventDamage on target
	}

	public void EventDamage(Bullet bullet)
	{
		audio.Play();
		//determine hit table to use
		//determine where hit on table
		//apply damage
		//if extra, apply damage to internal
		//if internal, check crit
		//if crit
		//eventCritical

		//deal with overflow damage

		//if(armor["remaining"] <= 0)
		//	EventDestruct();
	}

	private void EventCritical()
	{
		//get mass of limb
		//determine random start point
		//apply damage amount and see what components were hit
		//eventDamage on component which updates status of it or if reactor handles differently
		//or if ammo can explode ammo and continue thsi process
	}

	public void EventManeuver()
	{
		//try is piloting
		//apply actuator issues and other conditionals
		//if success, yay
		//if fail
		//eventFall
	}

	private void EventFall()
	{
		//determine fall FACING
		//determine hull up or down
		//eventDamage from fall

	}

	public int GetDodge()
	{
		if(Speed["momentum"] <= 1)
			return 0;
		else if(Speed["momentum"] <= 3)
			return 1;
		else if(Speed["momentum"] <= 6)
			return 2;
		else if(Speed["momentum"] <= 10)
			return 3;
		else if(Speed["momentum"] <= 15)
			return 4;
		else if(Speed["momentum"] <= 21)
			return 5;
		else if(Speed["momentum"] <= 28)
			return 6;
		else if(Speed["momentum"] <= 36)
			return 7;
		else if(Speed["momentum"] <= 45)
			return 8;
		else
			return 9;
	}

	public int GetAccuracyPenalty()
	{
		//if(Speed["moved"] == 0)
			return 0;//no penalty
	}

	public int GetRangePenalty()
	{
		//if(Speed["moved"] == 0)
			return 0;//no penalty
	}

	public int GetMovementPenalty()
	{
		if(Speed["moved"] == 0)
			return 0;//no penalty
		else if(Speed["moved"] <= Speed["walk"])
			return 1;//moved
		else if(Posture == "jump")
			return 3;//in midair
		else
			return 2;//is running
	}
}
