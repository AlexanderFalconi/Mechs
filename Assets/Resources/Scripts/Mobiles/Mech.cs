using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mech : Mobile {
	public Dictionary<string,Part> Body = new Dictionary<string,Part>() {{"head", new Head()}, {"left arm", new LeftArm()}, {"right arm", new RightArm()}, {"left leg", new LeftLeg()}, {"right leg", new RightLeg()}, {"left torso", new LeftTorso()}, {"right torso", new RightTorso()}, {"center torso", new CenterTorso()}};
	public Dictionary<string,int> Speed = new Dictionary<string,int>() {{"jump", 0}, {"walk", 0}, {"run", 0}, {"momentum", 0}, {"moved", 0}};
	private int Posture = 1;//0: prone, 1: stand, 2: jump
	public int Size = 0;//1: infantry, 2: suit, 3: car, 4: tank, 5: light mech, 6: medium mech, 7: heavy mech, 8: small structure, 9: large structure, 10: tile
	private float Mass = 0.0f;
	public float Energy = 0.0f;
	public float Rotation, Stabilization, Balance, Mobility, Locomotion;//Mech attributes
	public Pilot PilotOb = null;
	public Weapon SelectedWeapon;
	public Vector3 Position, Facing;
	public Engine Environment;
	public delegate void UpdateUIOutput(string output); // declare delegate type
	public Player Controller;

	public bool LoadPilot(Pilot pilot)
	{
		foreach(KeyValuePair<string,Part> item in Body)
		{
			foreach(Component component in item.Value.Components)
			{
				if(component.AddPersonell(pilot))
				{//Found a cockpit
					PilotOb = pilot;
					UpdateInterface();
					return true;//Done
				}
			}
		}
		return false;//Couldn't find a cockpit
	}

	public Transform BindController(Player who)
	{
		Controller = who;
		UpdateInterface();
		return transform;
	}

	public void UpdateInterface()
	{
		if(Controller)
		{
			Controller.UpdateUIMass(Mass, Size);
			Controller.UpdateUIEnergy(Energy);
			Controller.UpdateUIBalance(Balance);
			Controller.UpdateUIStabilization(Stabilization);
			Controller.UpdateUIRotation(Rotation);
			Controller.UpdateUIMobility(Mobility);
			Controller.UpdateUILocomotion(Locomotion);
			Controller.UpdateUISpeed(Speed["walk"], Speed["run"], Speed["jump"], Speed["momentum"], Speed["moved"]);
			Controller.UpdateUIPilot(PilotOb);
		}
		//else passthrough
	}

	public void SetPosition(Vector3 pos, Vector3 face)
	{
		Position = pos;
		transform.position = pos;
		Facing = face;
		faceDir = face;
		moveDir = face;
	}

	public void SetMass(float mass, Chassis chassis)
	{
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Mech mass must be in increments of 0.25.");
		float totalMassRem = 100.0f;//Total mech mass
		float totalIntRem = totalMassRem * chassis.Internal;//Total internal structure portion
		totalIntRem -= totalIntRem%0.25f;//Round down to 0.25.
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
		UpdateInterface();
	}

	public float GetMass()
	{
		return Mass;
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
		if(GetMass() < 10.0f)
			return "Ultra-Light";
		else if(GetMass() <= 20.0f)
			return "Super-Light";
		else if(GetMass() <= 40.0f)
			return "Light";
		else if(GetMass() <= 70.0f)
			return "Medium";
		else if(GetMass() <= 90.0f)
			return "Heavy";
		else// if(Mass <= 100.0f)
			return "Super-Heavy";
	}

	public void Interval()
	{
		Speed["momentum"] = 0;
		Speed["moved"] = 0;
		foreach(Weapon weapon in Weapons)
			weapon.Discharged = 0;//Reset firing
		if(!PilotOb.Conscious)
		{//Knocked out
			PilotOb.EventConsciousness();//Try to wake up
			isDone = true;//Skip this turn
		}
		Energy = 0;//Later on create alternate component and store power in batteries
		foreach(KeyValuePair<string,Part> gen in Body)
			Energy += gen.Value.EventGeneratePower();
		UpdateInterface();
		isDone = false;
	}

	public void OrderMove(Vector3 pos)
	{
		if(isReady == false || Position == pos)
			return;//Too busy to move
		EventMove(GetMovementPath(GetDirectSteps(Position, pos)));
	}

	public void EventMove(List<Vector3> path)
	{
		List<Vector3> tmp = new List<Vector3>();
		foreach(Vector3 move in path)
		{
			if(Speed["moved"] >= Speed["run"])
				break;
			else
				tmp.Add(move);
			Speed["moved"]++;
			Environment.EventMove(this.transform, move);
			Position = move;
			Facing = Position - move;
		}
		if(tmp.Count > 0)
		{
			isReady = false;
			moveTo = tmp;
			NextFace();			
		}//else can't move
		UpdateInterface();
	}

	public void OrderJump(Vector3 pos)
	{
		if(isReady == false)
			return;//Can't move
		if(Posture == 0)
			return;//Can't jump while pron
		Posture = 2;//Airborne
		isReady = false;
		moveTo = GetMovementPath(GetDirectSteps(Position, pos));
	}	

	public void OrderFire(Transform target, Weapon weapon, int shots)
	{
		if(!CanFire(weapon, target.position))
			return;
		Ammunition ammo = weapon.Loaded;
		if(ammo.Amount < shots)
			shots = ammo.Amount;
		for(int i = 0; i < shots; i++)
		{
			if(ammo.EventDischarge())
			{
				float result;
				List<Vector3> steps = GetDirectSteps(Position, target.GetComponent<Mech>().Position);
				Dictionary<string,float[]> scan = new Dictionary<string,float[]>() {{"x", new float[] {0.0f, 0.0f} },{"y", new float[] {0.0f, 0.0f} },{"z", new float[] {0.0f, 0.0f} }};
				Dictionary<string,float[]> partial = new Dictionary<string,float[]>() {{"x", new float[] {0.0f, 0.0f}},{"y", new float[] {0.0f, 0.0f}},{"z", new float[] {0.0f, 0.0f}}};
				List<float[]> chance;
				foreach(Vector3 step in steps)
				{//For each step in the path
					chance = new List<float[]>();
					scan["x"][0] = Mathf.Floor(step.x);
					scan["x"][1] = Mathf.Ceil(step.x);
					partial["x"][0] = 1.0f - step.x%1.0f;
					partial["x"][1] = step.x%1.0f;
					scan["y"][0] = Mathf.Floor(step.y);
					scan["y"][1] = Mathf.Ceil(step.y);
					partial["y"][0] = 1.0f - step.y%1.0f;
					partial["y"][1] = step.y%1.0f;
					scan["z"][0] = Mathf.Floor(step.z);
					scan["z"][1] = Mathf.Ceil(step.z);
					partial["z"][0] = 1.0f - step.z%1.0f;
					partial["z"][1] = step.z%1.0f;
					for(int y = 0; y <= 1; y++)
					{//Foreach possible tile that could be hit, get a random chance and assign to the tile
						for(int z = 0; z <= 1; z++)
						{
							for(int x = 0; x <= 1; x++)
								chance.Add(new float[] {x, y, z, scan["x"][x]*partial["x"][x]*scan["y"][y]*partial["y"][y]*scan["z"][z]*partial["z"][z]});
						}
					}
					result = Random.Range(0.1f, 100.0f);
					foreach(float[] ch in chance)
					{//Take the random chances to hit each tile, and find the tile that's hit
						result -= ch[3];
						if(result <= 0)
						{//Found the tile to hit, see if an entity is there
							if(Environment.Grid[(int)ch[0],(int)ch[1],(int)ch[2]] != null)//An entity is here
							{
								Transform potential = Environment.Grid[(int)ch[0], (int)ch[1], (int)ch[2]][0];//Takes the first element of the list for now
								if(potential == target)
									EventRangedAttack(target, ammo);//Try to hit intended target
								else
									EventIndirectAttack(potential, ammo);//See if accidentally hit wrong target
							}
							break;//Else, no entity is here
						}
					}
				}
				//base.OrderFire(target, SelectedWeapon.Loaded); GENERATE THE ANIMATION				
			}
		}
	}

	//handle amo expenditure

	public void OrderReload(Weapon weapon, int max)
	{
		if(CanReload(weapon))
			weapon.EventReload(max);
	}

	public bool CanFire(Weapon weapon, Vector3 target)
	{
		float[] arc = new float[2];
		float degree;
		if(Energy < weapon.Energy["fire"])
			return false;//Not enough energy
		arc = weapon.Installed.GetFiringArc();
		degree = Vector3.Angle(Position, target);
		if(degree < arc[0] || degree > arc[1])
			return true;
		else
			return false;
	}

	public bool CanReload(Weapon weapon)
	{
		if(Energy < weapon.Energy["reload"])
			return false;//Not enough energy
		else
			return false;
	}

	public void EventLand()
	{
		Posture = 1;//Land
		if(Environment.Grid[(int)Position.x,(int)Position.y,(int)Position.z].Count > 0)
		{//There's another mech in this space
			if(!EventManeuver(2))//Try to avoid falling
				EventFall(1);//Failed, fall
		}
	}

    public void EventMeleeAttack(Transform target, Part limb)
    {
        int accuracy = PilotOb.Piloting + limb.GetMeleeCR();
        Ammunition simulate = new Bludgeoning(limb.GetMeleeDamage());
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
		{
	 		EventDamage(target.GetComponent<Mech>(), simulate);//If actually hit
	 		limb.EventMeleeBacklash();//Sometimes can hurt self
 		}
    }

    public void EventCollisionAttack(Transform target)
    {
        int accuracy = PilotOb.Piloting - target.GetComponent<Mech>().PilotOb.Piloting + Body["center torso"].GetMeleeCR();
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
		{
			target.GetComponent<Mech>().EventDamage(this, new Bludgeoning(Body["center torso"].GetMeleeDamage()));
		 	Body["center torso"].EventMeleeBacklash();//Sometimes can hurt self
		}
    }

    public void EventCollision(int damage)
    {
        Ammunition cluster;
		while(damage > 0)
		{
			if(damage > Mathf.FloorToInt(GetMass()/10.0f))
			{
				cluster = new Bludgeoning(Mathf.FloorToInt(GetMass()/10.0f));
				damage -= cluster.Amount;
			}
			else
			{
				cluster = new Bludgeoning(damage);
				damage = 0;
			}
	 		EventDamage(this, cluster);//If actually hit
		}
    }    

	public float EventRangedAttack(Transform target, Ammunition ammo)
	{//Indirect fire
		int accuracy = PilotOb.Gunnery;//Initialize at skill
		accuracy += GetRangePenalty(target, ammo);
		accuracy += GetMovementPenalty();
		accuracy += GetAccuracyPenalty(ammo);//Lost actuators or other circumstances
		if(target.tag != "Tile")
			accuracy += target.GetComponent<Mech>().GetDodge();//not yet set
		if(accuracy > 11)
			accuracy = 11;
		else if(accuracy < 0)
			accuracy = 0;
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
			return target.GetComponent<Mech>().EventDamage(this, ammo);
		else
			return 0.0f;
	}

	public float EventIndirectAttack(Transform potential, Ammunition ammo)
	{//Indirect fire
		if(Random.Range(0.1f, 100.0f) <= potential.GetComponent<Mech>().Size*potential.GetComponent<Mech>().Size)
			return potential.GetComponent<Mech>().EventDamage(this, ammo);
		else
			return 0.0f;
	}


	public void UpdateActuators()
	{
		Balance = Stabilization = Rotation = Mobility = Locomotion = 0.0f;
		foreach(KeyValuePair<string,Part> item in Body)
		{
			foreach(Component component in item.Value.Components)
			{
				Balance += component.GetBalance();
				Stabilization += component.GetStabilization();
				Rotation += component.GetRotation();
				Mobility += component.GetMobility();
				Locomotion += component.GetLocomotion();
			}
		}
		Speed["walk"] = Mathf.FloorToInt(Locomotion/GetMass());
		Speed["run"] = Speed["walk"] *3 / 2;
		UpdateInterface();
	}

	public float GetMovementPower()
	{
		if(Speed["moved"] < Speed["walk"])
			return Mass;
		else
			return (Speed["moved"] - Speed["walk"] + 1) * GetMass();
	}

	public void EventStand()
	{
		Speed["moved"] += 2;
		if(EventManeuver(0))
			Posture = 1;//else failed to stand
	}

	private void EventFall(int height)
	{
		//Facing = Random.Range(0,7); 
		EventDamage(this, new Bludgeoning(Mathf.FloorToInt(GetMass()/10*height)));
		if(!EventManeuver(height))
			PilotOb.EventDamage(1);
	}

	public bool CanMove(int amount)
	{
		if(Speed["moved"] == 0 || (Speed["moved"] + amount <= Speed["run"]))
			return true;
		else
			return false;
	}

	public int EventDamage(Mech attacker, Ammunition ammo)
	{
		audio.Play();//TEMP: this should be moved to render
		string table = GetHitTable(attacker);//Get hit table
		string location = "none";
		string side = "external";//Flag to take from ordinary external
		int result;
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
		return Body[location].EventDamage(ammo, side);
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

	public bool EventManeuver(int dc)
	{
		int attempt = PilotOb.Piloting + dc;
		if(Stabilization/GetMass() < 0.25f)
			attempt += 4;
		else if(Stabilization/GetMass() < 0.5f)
			attempt += 2;
		else if(Stabilization/GetMass() < 1.0f)
			attempt += 1;
		if(Random.Range(0.0f, 100.0f) <= Engine.GetThreshold(attempt))
			return true;
		else
			return false;
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

	public int GetAccuracyPenalty(Ammunition ammo)
	{
		if(ammo.Installed.GetAccuracy() >= GetMass() * 2.0f)
			return 0;
		else if(ammo.Installed.GetAccuracy() >= GetMass())
			return 1;
		else
			return 2;
	}

	public int GetRangePenalty(Transform target, Ammunition ammo)
	{
		float distance = Vector3.Distance(transform.position, target.position);
		return Mathf.FloorToInt(distance/ammo.Range);
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

	public List<Vector3> GetDirectSteps(Vector3 from, Vector3 to)
	{
		float dX = to.x - from.x;
		float dZ = to.z - from.z;
		float slope;
		List<Vector3> path = new List<Vector3>();
		if(Mathf.Abs(dZ) > Mathf.Abs(dX))
		{
			slope = dX/Mathf.Abs(dZ);
			for(var i = 0; i < Mathf.Abs(dZ); i++)
			{
				from.z += dZ/Mathf.Abs(dZ);
				from.x+=slope;
				path.Add(from);
			}
		}
		else
		{
			slope = dZ/Mathf.Abs(dX);
			for(var i = 0; i < Mathf.Abs(dX); i++)
			{
				from.x+= dX/Mathf.Abs(dX);
				from.z+=slope;
				path.Add(from);
			}
		}
		return path;
	}

	public List<Vector3> GetMovementPath(List<Vector3> steps)
	{//Simplified pathing algorithm
		List<Vector3> path = new List<Vector3>();
		foreach(Vector3 step in steps)
			path.Add(new Vector3(Mathf.Round(step.x), Mathf.Round(step.y), Mathf.Round(step.z)));
		return path;
	}
}