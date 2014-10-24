using UnityEngine;
using System.Collections.Generic;

public class Mech : Mobile {
	public Dictionary<string,Part> Body = new Dictionary<string,Part>() {{"head", new Head()}, {"left arm", new LeftArm()}, {"right arm", new RightArm()}, {"left leg", new LeftLeg()}, {"right leg", new RightLeg()}, {"left torso", new LeftTorso()}, {"right torso", new RightTorso()}, {"center torso", new CenterTorso()}};
	public Dictionary<string,int> Speed = new Dictionary<string,int>() {{"jump", 0}, {"walk", 0}, {"run", 0}, {"momentum", 0}, {"moved", 0}};
	private int Posture = 1;//0: prone, 1: stand, 2: jump
	public int Size = 0;//1: infantry, 2: suit, 3: car, 4: tank, 5: light mech, 6: medium mech, 7: heavy mech, 8: small structure, 9: large structure, 10: tile
	private float Mass = 0.0f;
	private Chassis InternalStructure;
	public Pilot PilotOb;
	public Weapon SelectedWeapon;
	public Vector3 Pos;
	public int Face;

	public Mech() 
	{
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
		foreach(string item in Body.Keys)
		{
			float tmp = Body[item].Proportion["ratio"] * mass;//Multiply total by limb ratio
			tmp -= tmp%0.25f;//Round down to minimums of 0.25
			Body[item].Proportion["max mass"] = tmp;//Set limb ratio
			totalMassRem -= tmp;//Reduce total accordingly
			tmp *= chassis.Internal;//Get the portion of internal structure
			tmp -= tmp%0.25f;//Round down to minimums of 0.25
			totalIntRem -= tmp;//Reduce total accordingly
			Body[item].Armors["internal"] = new Armor(tmp);
			Body[item].Proportion["mass"] = tmp;//Set mass equal to internal structure as initial
		}
		Body["center torso"].Proportion["max mass"] += totalMassRem;//Add excess to center torso
		Body["center torso"].Armors["internal"].AddArmor(totalIntRem);
		Body["center torso"].Proportion["mass"] += totalIntRem;//Add excess to center torso
	}

	public float AddComponent(string limb, Component part)
	{
		return Body[limb].Install(part);
	}

	public void AddArmor(string limb, string loc, float mass)
	{
		Body[limb].AddArmor(loc, mass);
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

	public void EventJump()
	{
		if(Posture == 0)
			return;//Can't jump while prone
		Posture = 2;
		//event move
		Posture = 1;
	}

	public void OrderFire(GameObject target)
	{
		//This needs to set and follow a route, checking targets along the way.
		base.OrderFire(target, SelectedWeapon.Loaded);
	}

	public void EventMeleeAttack()
	{
		//pilot after kick charge crush attacks
	}

    public void EventMeleeAttack(Mech target, Component limb)
    {
        float result;
        int accuracy = PilotOb.Piloting + limb.MeleePenalty;//kick +0; punch push +1; charge +2
    }

	private void EventRangedAttack(Mech target, Ammunition ammo)
	{
		int accuracy = PilotOb.Gunnery;//Initialize at skill
		accuracy += GetRangePenalty();
		accuracy += GetMovementPenalty();
		accuracy += GetAccuracyPenalty();//Lost actuators or other circumstances
		if(target.tag != "Tile")
			accuracy += target.GetComponent<Mech>().GetDodge();//not yet set
		if(accuracy > 11)
			accuracy = 11;
		else if(accuracy < 0)
			accuracy = 0;
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
		{
			if(target.EventDamage(this, ammo) >= Mass)
			{
				if(EventManeuver(0))
					EventFall(1);
			}			
		}
	}

	//if pilot is unconscious check again at every turn
	//where is cockpit? handle hits to that component (head) with a pilot damage roll?

	private void EventCollisionDamage(Mech target)
	{
		//use a subtraction algorithm between facing and nonfacing to determine the hit table
		//break damage into clusters
	}

	public int EventDamage(Mech attacker, Ammunition ammo)
	{
		int inflicted = 0;
		int crit = 0;
		audio.Play();//TEMP: this should be moved to render
		string table = GetHitTable(attacker);//Get hit table
		string location = "none";
		string side = "external";//Flag to take from ordinary external
		int result, damage, damageR, hardness;
		if(table == "rear")
		{
			side = "rear";//Flag to take from rear armor
			table = "front";//Rear table is same as front in most cases, just need to set the above flag to ensure rear armor is hit
		}
		result = Random.Range(1, 36);
		foreach(KeyValuePair<string,Part> item in Body)
		{//Determine hit location
			result -= item.Value.HitTable[table];
			if(result <= 0)
			{
				location = item.Key;
				break;//Done
			}
		}
		hardness = Body[location].Armors[side].Hardness[ammo.DamageType];
		if(ammo.Damage < Body[location].Armors[side].Hardness[ammo.DamageType])
		{
			ammo.Damage = 0;
			return 0;//Armor absorbs the blow, but its ineffective.
		}
		damage = ammo.Damage / hardness;//Convert to relative damage based on armor hardness
		damageR = ammo.Damage % hardness;//The remainder does not necessary truncate
		result = Random.Range(1, hardness);//Chance of it applying depends on how high
		if(result <= damageR)//Check to see if extra damage
			damage++;//Add 1 extra damage
		if(Body[location].Armors[side].HP >= damage)
		{//External armor soaks
			inflicted += damage;//Record damage
			damage = 0;
			Body[location].Armors[side].HP -= damage;
			ammo.Damage = 0;//Armor absorbs the blow
		}
		else
		{
			inflicted += Body[location].Armors[side].HP;//Record damage
			damage -= Body[location].Armors[side].HP;
			ammo.Damage -= Body[location].Armors[side].HP * hardness;//Absorm some of the blow
			Body[location].Armors[side].HP = 0;//Shear off all armor
			if(Body[location].Armors["internal"].HP >= damage)
			{//Internal armor soaks
				inflicted += damage;//Record damage
				crit = damage;
				Body[location].Armors["internal"].HP -= damage;
				ammo.Damage = 0;
			}
			else
			{
				crit = Body[location].Armors["internal"].HP;
				inflicted += Body[location].Armors["internal"].HP;//Record damage
				damage -= Body[location].Armors["internal"].HP;
				ammo.Damage -= Body[location].Armors["internal"].HP * hardness;//Absorm some of the blow
				Body[location].Armors["internal"].HP = 0;//Shear off all armor
				//TEMP: Damage transfer into mech?
			}
		}
		if(crit > 0)
			EventCritical(location, crit);//Check for crits last because of possible ammo explosions
		return inflicted;
	}

	private string GetHitTable(Mech other)
	{
		float angle = Vector3.Angle(other.transform.position, transform.position);
		if(angle < 90.0f || angle > 270.0f)
			return "front";
		else if(angle >= 90.0f && angle <= 150.0f)
			return "right";
		else if(angle > 150.0f && angle < 210.0f)
			return "rear";
		else if(angle >= 210.0f && angle <= 270.0f)
			return "left";
		else
			return "none";
	}

	private void EventCritical(string location, int damage)
	{
		float possible = Body[location].Proportion["max mass"];
		float result;
		//THIS DAMAGE NEEDS TO BE STACKED
		for(int i = 0; i < damage; i++)
		{
			result = Random.Range(0.0f, possible);
			foreach(Component item in Body[location].Components)
			{
				result -= item.GetMass();
				if(result <= 0)
					item.EventDamage(1);
			}
		}
	}

	public bool EventManeuver(int dc)
	{
		int attempt = PilotOb.Piloting + dc;
		//apply actuator issues and other conditionals
		if(Random.Range(0.0f, 100.0f) <= Engine.GetThreshold(attempt))
			return true;
		else
			return false;
	}

	public void EventStand()
	{
		//costs 2 MP or minimum movement
		if(EventManeuver(0))
			Posture = 1;
		//else failed to stand
	}

	private void EventFall(int height)
	{
		Face = Random.Range(0,7); 
		//EventCollisionDamage(Mathf.Floor(Mass/10*height));
		if(!EventManeuver(height))
			PilotOb.EventDamage(1);
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
		else if(Posture == 2)
			return 3;//in midair
		else
			return 2;//is running
	}
}
