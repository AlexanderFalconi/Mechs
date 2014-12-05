using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mech : Mobile {
	public const int POSTURE_PRONE = 0;
	public const int POSTURE_STAND = 1;
	public const int POSTURE_JUMP = 2;
	public const int STATUS_OK = 0;
	public const int STATUS_DESTROY = 1;
	public int Status = STATUS_OK;
	public Dictionary<string,Part> Body = new Dictionary<string,Part>() {{"head", new Head()}, {"left arm", new LeftArm()}, {"right arm", new RightArm()}, {"left leg", new LeftLeg()}, {"right leg", new RightLeg()}, {"left torso", new LeftTorso()}, {"right torso", new RightTorso()}, {"center torso", new CenterTorso()}};
	public Dictionary<string,int> Speed = new Dictionary<string,int>() {{"jump", 0}, {"walk", 0}, {"run", 0}, {"momentum", 0}, {"moved", 0}};
	public int Posture = POSTURE_STAND;
	private float Mass;
	private Dictionary<string,float> Energy = new Dictionary<string,float>() {{"stored", 0}, {"current", 0}};
	public float Rotation, Stabilization, Balance, Mobility, Locomotion, Thrust;//Mech attributes
	public Pilot PilotOb = null;
	public GameObject muzzleFlash;
	public delegate void UpdateUIOutput(string output); // declare delegate type

	public Mech()
	{
		SoundFX["short motion"] = Resources.Load("Audio/FXShortMotion") as AudioClip;
		SoundFX["long motion"] = Resources.Load("Audio/FXLongMotion") as AudioClip;
		SoundFX["fall"] = Resources.Load("Audio/FXFall") as AudioClip;
		SoundFX["move 0"] = Resources.Load("Audio/FXMechMove0") as AudioClip;
		SoundFX["move 1"] = Resources.Load("Audio/FXMechMove1") as AudioClip;
		SoundFX["move 2"] = Resources.Load("Audio/FXMechMove2") as AudioClip;
		SoundFX["move 3"] = Resources.Load("Audio/FXMechMove3") as AudioClip;
		SoundFX["move 4"] = Resources.Load("Audio/FXMechMove4") as AudioClip;
		SoundFX["destruct"] = Resources.Load("Audio/FXMechExplosion") as AudioClip;
		SoundFX["reload"] = Resources.Load("Audio/FXReloadBallistic") as AudioClip;
		SoundFX["eject"] = Resources.Load("Audio/FXEject") as AudioClip;
		SoundFX["damage"] = Resources.Load("Audio/FXBallisticImpact") as AudioClip;
	}

	public new Mech BindController(Player who)
	{
		base.BindController(who);
		Controller.Initialize(Body);//TEMP: Need to just have this run at completion.
		return this;
	}

	public override void EventEject()
	{
		PilotOb = null;
		base.EventEject();
	}

	public bool LoadPilot(Pilot pilot)
	{
		Debug.Log("Trying to load pilot");
		foreach(KeyValuePair<string,Part> item in Body)
		{
			foreach(Component component in item.Value.Components)
			{

				if(component.AddPersonell(pilot))
				{//Found a cockpit
					Debug.Log("found cockpit"+component.Short);
					PilotOb = pilot;
					return true;//Done
				}
				else
					Debug.Log("didn't find cockpit"+component.Short);
			}
		}
		return false;//Couldn't find a cockpit
	}

	public void UpdateUI()
	{
		if(Controller)
		{
			if(Environment.Interval["phase"] == Engine.PHASE_ACTION)
			{
				Controller.PanelWeapons.transform.parent.gameObject.SetActive(false);
				Controller.PanelActions.transform.parent.gameObject.SetActive(true);
			}
			else
			{
				Controller.PanelWeapons.transform.parent.gameObject.SetActive(true);
				Controller.PanelActions.transform.parent.gameObject.SetActive(false);
			}
			foreach(KeyValuePair<string,Part> part in Body)
				part.Value.UpdateUI();
			//TEMP: These stats need to eventually convert to the callback system being used for mech actions
			Controller.UpdateUIMass(Mass, Size);
			Controller.UpdateUIEnergy(Energy["current"]);
			Controller.UpdateUIBalance(Balance);
			Controller.UpdateUIStabilization(Stabilization);
			Controller.UpdateUIThrust(Thrust);
			Controller.UpdateUIMobility(Mobility);
			Controller.UpdateUILocomotion(Locomotion);
			Controller.UpdateUISpeed(Speed["walk"], Speed["run"], Speed["jump"], Speed["momentum"], Speed["moved"]);
			Controller.UpdateUIPilot(PilotOb);
			Controller.UpdateUIArmor(Body);
		}//else passthrough
	}

	public void SetMass(float mass, Chassis chassis)
	{
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Mech mass must be in increments of 0.25.");
		float totalMassRem;
		float totalIntRem = mass * chassis.Internal;//Total internal structure portion
		Mass = mass;//Set mass
		totalIntRem -= totalIntRem%0.25f;//Round down to 0.25.
		totalMassRem = mass - totalIntRem;//Total mech mass
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
			AddArmor(item, "internal", chassis.Generate(tmp));//Set internal armor
			Body[item].Proportion["mass"] = tmp;//Set mass equal to internal structure as initial
		}
		Body["center torso"].Proportion["max mass"] += totalMassRem;//Add excess to center torso
		AddArmor("center torso", "internal", chassis.Generate(totalIntRem));//Set internal armor
		Body["center torso"].Proportion["mass"] += totalIntRem;//Add excess to center torso
		UpdateUI();
	}

	public override void EventDestroyed()
	{
		Environment.EventRelease(this);
		Status = STATUS_DESTROY;
		base.EventDestroyed();		
	}

	public bool EventDrainEnergy(float energy)
	{
		if(Energy["current"]-energy < 0.0f)
			return false;
		else
			Energy["current"] -= energy;
		return true;
	}

	public void AddEnergy(float energy)
	{
		Energy["current"] += energy;
	}

	public float GetMass()
	{
		return Mass;
	}

	public float AddComponent(string limb, Component part)
	{
		return Body[limb].Install(part);
	}

	public void AddArmor(string limb, string loc, Armor armor)
	{
		Body[limb].AddArmor(loc, armor);
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
		float mass = GetMass();
		isDone = false;
		if(Environment.Interval["phase"] <= Engine.PHASE_ACTION)//Includes Engine.PHASE_DEPLOY
		{
			Speed["momentum"] = Speed["moved"] = Speed["jumped"] = 0;
			if((PilotOb == null) || (Status != STATUS_OK))
				isDone = true;
			else if(!PilotOb.Conscious)
			{//Knocked out
				PilotOb.EventConsciousness();//Try to wake up
				isDone = true;//Skip this turn
			}
			Balance = Stabilization = Rotation = Mobility = Locomotion = Thrust = 0.0f;//Reset mech attributes
			Energy["current"] = 0;
			foreach(KeyValuePair<string,Part> part in Body)
				part.Value.Interval();
			Speed["walk"] = Mathf.FloorToInt(Locomotion/GetMass());
			Speed["run"] = Speed["walk"] *3 / 2;
			if(Speed["walk"] *3 % 2 > 0)
				Speed["run"]++;//Round up run speed
			Speed["jump"] = Mathf.FloorToInt(Thrust/mass);//Round down for jump distance
		}
		UpdateUI();
	}

	public override string GetEntityType()
	{
		return "mech";
	}

	public void AttemptMove(Vector3 position)
	{
		EventMove(GetMovementPath(GetDirectSteps(Position, position))); 
	}

	private int GetMovementCost(Vector3 position)
	{
		if(Posture == POSTURE_STAND)
		{
			position.y-=1;//Need the ground underneath where the mech's feet will be; not empty space
			return ((Tile)Environment.GetGridLocation(position)[0]).MoveCost;
		}
		else if(Posture == POSTURE_JUMP)
			return 1;//In midair all costs are 1
		else
			return 4;//Crawling
	}

	public void AttemptJump(List<Vector3> path)
	{
		Speed["jumped"] = 1;
		Posture = POSTURE_JUMP;
		EventMove(path);
		Posture = POSTURE_STAND;
		if(((Stabilization/GetMass() < 2.0f) || (Balance/GetMass() < 2.0f)) && (!EventManeuver(3)))
			EventFall(1);
	}

	//Also accidental collisions
	//when kick check other leg and disable kick
	//click button--SELECT TARGET? logo or something?
	//case "turn":///////////////
	//dont do jump until we have new terrain maps

	public void EventMove(List<Vector3> path)
	{
		int cost;
		List<Vector3> tmp = new List<Vector3>();
		foreach(Vector3 move in path)
		{
			if(((Posture == POSTURE_JUMP) && (Speed["moved"] >= Speed["jump"])) || ((Posture != POSTURE_JUMP) && (Speed["moved"] >= Speed["run"])))
				break;
  			cost = GetMovementCost(move);
			if(!EventDrainEnergy(GetMovementEnergyCost(cost)))
				break;//Not enough energy
			Speed["moved"]+=cost;
			Speed["momentum"]++;
			tmp.Add(move);
			Environment.EventMove(this, move);
			Position = move;
			//Debug.Log()
			Facing = Position - move;
			if(((Speed["moved"] > Speed["walk"]) && (Balance/GetMass() < 2.0f) && !EventManeuver(2)) || 
				((Speed["moved"] <= Speed["walk"]) && (Balance/GetMass() < 1.0f) && !EventManeuver(1)))
			{
				EventFall(1);
				break;//Can't move anymore, fell down
			}
		}
		if(tmp.Count > 0)
		{
			isReady = false;
			moveTo = tmp;
			NextFace();			
		}//else can't move
		UpdateUI();
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

	public void AttemptFire(Weapon weapon)
	{
		Debug.Log("Weapon: "+weapon);
		int hits = 0;
		float damage = 0;
		int shots = weapon.RateOfFire["set"];
		Entity target = weapon.Selected;
		Debug.Log("Target: "+target);
		if(!CanFire(weapon, target.Position))
			return;
		Ammunition ammo = weapon.Loaded;
		base.EventRangedAttack((Entity)target, weapon.Loaded);		
		Debug.Log("Yep, can fire.");
		for(int i = 0; i < shots; i++)
		{
			if(weapon.EventDischarge())
			{
				GameObject.Instantiate(muzzleFlash, transform.position + new Vector3(0.5f, 0.0f, 0.5f), transform.rotation);//Add mech
				float result;
				float inflicted = 0;
				Debug.Log(target.Position);
				List<Vector3> steps = GetDirectSteps(Position, target.Position);
				Dictionary<string,int[]> scan = new Dictionary<string,int[]>() {{"x", new int[] {0, 0} },{"y", new int[] {0, 0} },{"z", new int[] {0, 0} }};
				Dictionary<string,float[]> partial = new Dictionary<string,float[]>() {{"x", new float[] {0.0f, 0.0f}},{"y", new float[] {0.0f, 0.0f}},{"z", new float[] {0.0f, 0.0f}}};
				foreach(Vector3 step in steps)
				{//For each step in the path
					//Debug.Log("STEP: "+step);
					scan["x"][0] = Mathf.FloorToInt(step.x);
					scan["x"][1] = Mathf.CeilToInt(step.x);
					partial["x"][1] = step.x%1.0f;
					partial["x"][0] = 1.0f - partial["x"][1];
					scan["y"][0] = Mathf.FloorToInt(step.y);
					scan["y"][1] = Mathf.CeilToInt(step.y);
					partial["y"][1] = step.y%1.0f;
					partial["y"][0] = 1.0f - partial["y"][1];
					scan["z"][0] = Mathf.FloorToInt(step.z);
					scan["z"][1] = Mathf.CeilToInt(step.z);
					partial["z"][1] = step.z%1.0f;
					partial["z"][0] = 1.0f - partial["z"][1];
					result = Random.Range(0.01f, 1.00f);
					//Debug.Log("Core Result: "+result);
					for(int y = 0; y <= 1; y++)
					{//Foreach possible tile that could be hit, get a random chance and assign to the tile
						for(int z = 0; z <= 1; z++)
						{
							for(int x = 0; x <= 1; x++)
							{
								//Debug.Log(scan["x"][x]+", "+scan["y"][y]+", "+scan["z"][z]);
								//Debug.Log(partial["x"][x]+", "+partial["y"][y]+", "+partial["z"][z]);
								//Debug.Log(partial["x"][x]*partial["y"][y]*partial["z"][z]);
								result -= partial["x"][x]*partial["y"][y]*partial["z"][z];
								//Debug.Log("Result: "+result);
								if(result <= 0)
								{//Found the tile to hit, see if an entity is there
									//Debug.Log("Try to hit...");
									if(Environment.Grid[scan["x"][x],scan["y"][y],scan["z"][z]].Count > 0)//An entity is here
									{
										//Debug.Log("An entity is here...");
										Entity potential = Environment.Grid[scan["x"][x],scan["y"][y],scan["z"][z]][0];//Takes the first element of the list for now
										if(potential == target)
											inflicted += EventRangedAttack((Mech)target, ammo);//Try to hit intended target
										else
											inflicted += EventIndirectAttack(potential, ammo);//See if accidentally hit wrong target
									}//Else, no entity is here
									x = y = z = 2;//Force a break out of these 3 loops; move on to next step
								}
							}
						}
					}
					if(inflicted > 0.0f)
					{
						hits++;
						damage += inflicted;
					}
					if(ammo.Damage["remaining"] < 1)
						break;//This round is spent, try next round
				}
				Environment.ReportUI.UpdateUIResult(hits, damage);
			}
			else
				break;//Out of rounds
		}
	}

	public bool OrderLoad(Weapon weapon)
	{
		foreach(Component component in weapon.Installed.Components)
		{
			if(component.GetSystem() == "ammunition")
			{
				if(((Ammunition)component).Ammo.Contains(weapon.GetShort()))
				{
					weapon.EventLoad((Ammunition)component);
					return true;
				}
			}
		}
		return false;//Couldn't find
	}

	public bool OrderReload(Weapon weapon, int max = 0)
	{
		if(CanReload(weapon))
		{
			weapon.EventReload(max);
			return true;
		}
		else
			return false;
	}

	public bool CanFire(Weapon weapon, Vector3 target)
	{
		float[] arc = new float[2];
		float degree;
		Debug.Log("Loaded: "+weapon.Loaded);
		if(!weapon.CanFire())
			return false;
		Debug.Log("passed weapon canfire subroutine");
		arc = weapon.Installed.GetFiringArc();
		degree = Vector3.Angle(Position, target);
		return true;
		//TEMPORARY--skip the firing arc for now
		if(degree < arc[0] || degree > arc[1])
			return true;
		else
			return false;
	}

	public bool CanReload(Weapon weapon)
	{
		if((weapon.Loaded == null) || (weapon.Loaded.Amount < 1))
			return false;//Not enough energy or nothing loaded or not enough remaining in the loaded ammo
		else
			return true;
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

    public void EventMeleeAttack(Mech target, Part limb)
    {
        int accuracy = PilotOb.Piloting + limb.GetMeleeCR();
        Ammunition simulate = new Bludgeoning(limb.GetMeleeDamage());
        Debug.Log(accuracy);
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
		{
	 		EventDamage(target, simulate);//If actually hit
	 		limb.EventMeleeBacklash();//Sometimes can hurt self
	 		Debug.Log("MELEE HIT!");
 		}
 		else
 			Debug.Log("MELEE MISS!");
 		UpdateUI();
    }

    /*
    also do accidental charge
    also do ram
    for charge need 1 extra hex past target
    also do reverse move
    also do turning
    also do on a charge miss; fall or both balance penalties go to you
    also pilot check per 5%tonnage damage taken.
    on pounce based on jump hex hit
    ratio of balance locomotion for how high you can go
    add sensors
    add electro reactive armor
    add guerilla-tek chameleon plating
	*/
	public void EventCharge(Vector3 pos, Entity target)
	{
		//(Vector3.Distance(Master.Position, target.Position) < 2.0f)

	}

	public void EventPounce(Vector3 pos, Entity target)
	{
		//(Vector3.Distance(Master.Position, target.Position) < 2.0f)
	}


    public void EventCollisionAttack(Mech target)
    {
        int accuracy = PilotOb.Piloting - target.PilotOb.Piloting + Body["center torso"].GetMeleeCR();
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
		{
			target.EventDamage(this, new Bludgeoning(Body["center torso"].GetMeleeDamage()));
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

	public float EventRangedAttack(Mech target, Ammunition ammo)
	{//Direct fire
		int accuracy = PilotOb.Gunnery;//Initialize at skill
		accuracy += GetRangePenalty(target, ammo);
		accuracy += GetMovementPenalty();
		accuracy += GetAccuracyPenalty(ammo);//Lost actuators or other circumstances
		accuracy += target.GetDodge();//not yet set
		Debug.Log("Accuracy: "+accuracy);
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(accuracy))
			return target.EventDamage(this, ammo);
		else
			return 0.0f;
	}

	//NOTE, the returns are a problem because they dont soak the ammo discharge.

	public float EventIndirectAttack(Entity potential, Ammunition ammo)
	{//Indirect fire
		if(Random.Range(0.1f, 100.0f) <= potential.Size*potential.Size)
			return potential.GetComponent<Mech>().EventDamage(this, ammo);
		else
			return 0.0f;
	}

	public float GetMovementEnergyCost(int mm)
	{
		float mass = GetMass();
		float cost = 0.0f;
		for(int i = 1; i <= mm; i++)
		{
			if(Speed["moved"]+i <= Speed["walk"])
				cost += mass;
			else
				cost += mass * (Speed["moved"]+i+1-Speed["walk"]);
		}
		return cost;
	}

	public override void EventStand()
	{
		if(!EventDrainEnergy(GetMovementEnergyCost(2)))
			return;//Not enough energy
		Speed["moved"] += 2;
		if(EventManeuver(0))
			Posture = POSTURE_STAND;//else failed to stand
		base.EventStand();
		UpdateUI();
	}

	public override void EventProne()
	{
		if(!EventDrainEnergy(GetMovementEnergyCost(1)))
			return;//Not enough energy
		Speed["moved"] += 1;
		if(EventManeuver(-2))
			Posture = POSTURE_PRONE;
		else
			EventFall(1);
		base.EventProne();
		UpdateUI();
	}

	public override void EventFall(int height)
	{
		Facing = faceDir = GetRandomFacing();
		EventDamage(this, new Bludgeoning(Mathf.FloorToInt(GetMass()/10*height)));
		if(!EventManeuver(height))
			PilotOb.EventDamage(1);
		base.EventFall(height);
	}

	public Vector3 GetRandomFacing()
	{
		int result = Random.Range(0, 8);
		switch(result)
		{
			case 0:
				return new Vector3(1.0f, 0.0f, 1.0f);
			case 1:
				return new Vector3(1.0f, 0.0f, 0.0f);
			case 2:
				return new Vector3(1.0f, 0.0f, -1.0f);
			case 3:
				return new Vector3(0.0f, 0.0f, 1.0f);
			case 4:
				return new Vector3(0.0f, 0.0f, -1.0f);
			case 5:
				return new Vector3(-1.0f, 0.0f, 1.0f);
			case 6:
				return new Vector3(-1.0f, 0.0f, 0.0f);
			case 7:
				return new Vector3(-1.0f, 0.0f, -1.0f);
			default:
				return new Vector3(0.0f, 0.0f, 0.0f);
		}
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
		Debug.Log("UNIT HIT: "+this);
		base.EventDamage();
		string table = GetHitTable(attacker);//Get hit table
		string location = "none";
		string side = "external";//Flag to take from ordinary external
		int result;
		Debug.Log("Hit table: "+table);
		if(table == "rear")
		{
			side = "rear";//Flag to take from rear armor
			table = "front";//Rear table is same as front in most cases, just need to set the above flag to ensure rear armor is hit
		}
		result = Random.Range(1, 36);
		Debug.Log("Dice roll: "+result);
		foreach(KeyValuePair<string,Part> item in Body)
		{//Determine hit location
			result -= item.Value.HitTable[table];
			if(result <= 0)
			{
				location = item.Key;
				break;//Done
			}
		}
		Debug.Log("Body part hit: "+location);
		return Body[location].EventDamage(ammo, side);
	}

	private string GetHitTable(Mech other)
	{
		float angle = Vector3.Angle(other.transform.position, transform.position);
		if(angle < 90.0f || angle > 270.0f)
		{
			if(Posture == POSTURE_PRONE)
				return "rear";//Face down, has to hit rear
			else
				return "front";
		}
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
		float mass = GetMass();
		int attempt = PilotOb.Piloting + dc;
		if(Stabilization/mass < 0.5f)
			attempt += 4;
		else if(Stabilization/mass < 1.0f)
			attempt += 3;
		else if(Stabilization/mass < 1.5f)
			attempt += 2;
		else if(Stabilization/mass < 2.0f)
			attempt += 1;
		if(Random.Range(0.0f, 100.0f) <= Engine.GetThreshold(attempt))
			return true;
		else
			return false;
	}

	public int GetDodge()
	{
		if(Speed["momentum"] <= 1)
			return 0 + Speed["jumped"];
		else if(Speed["momentum"] <= 3)
			return 1 + Speed["jumped"];
		else if(Speed["momentum"] <= 6)
			return 2 + Speed["jumped"];
		else if(Speed["momentum"] <= 10)
			return 3 + Speed["jumped"];
		else if(Speed["momentum"] <= 15)
			return 4 + Speed["jumped"];
		else if(Speed["momentum"] <= 21)
			return 5 + Speed["jumped"];
		else if(Speed["momentum"] <= 28)
			return 6 + Speed["jumped"];
		else if(Speed["momentum"] <= 36)
			return 7 + Speed["jumped"];
		else if(Speed["momentum"] <= 45)
			return 8 + Speed["jumped"];
		else
			return 9 + Speed["jumped"];
	}

	public int GetAccuracyPenalty(Ammunition ammo)
	{
		int proneness = 0;
		if(Posture == POSTURE_PRONE)
			proneness = 2;
		if(ammo.Installed.GetAccuracy() >= GetMass() * 2.0f)
			return 0 + proneness;
		else if(ammo.Installed.GetAccuracy() >= GetMass())
			return 1 + proneness;
		else
			return 2 + proneness;
	}

	public int GetRangePenalty(Mech target, Ammunition ammo)
	{
		float distance = Vector3.Distance(Position, target.Position);
		int proneness = 0;
		if(target.Posture == POSTURE_PRONE)
		{
			if(distance <= 1.0f)
				proneness = -2;
			else if(distance <= 2.0f)
				proneness = -1;
			else if(distance <= 3.0f)
				proneness = 0;
			else if(distance <= 4.0f)
				proneness = 1;
			else
				proneness = 2;
		}
		return Mathf.FloorToInt(distance/ammo.Range) + proneness;
	}

	public int GetMovementPenalty()
	{
		if(Speed["jumped"] > 0)
			return 3;//jumped
		else if(Speed["moved"] == 0)
			return 0;//no penalty
		else if(Speed["moved"] <= Speed["walk"])
			return 1;//moved
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