using UnityEngine;
using System.Collections.Generic;

public class Mech : MonoBehaviour {
	private static List<string> Limbs = new List<string>() {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	private Dictionary<string,Dictionary<string,int>> HitTable = new Dictionary<string,Dictionary<string,int>>();
	private Dictionary<string,Dictionary<string,float>> Proportion = new Dictionary<string,Dictionary<string,float>>();
	private Dictionary<string,List<Component>> Components = new Dictionary<string,List<Component>>();
	private Dictionary<string,Dictionary<string,Armor>> Armors = new Dictionary<string,Dictionary<string,Armor>>();
	private Dictionary<string,int> Speed = new Dictionary<string,int>() {{"jump", 0}, {"walk", 0}, {"run", 0}};
	public Transform bullet;
	public Transform largeExplosion;
	public bool isDone = false;
	public bool isReady = true;
	private string Posture = "stand";
	public int Size = 0;//1: infantry, 2: suit, 3: car, 4: tank, 5: light mech, 6: medium mech, 7: heavy mech, 8: small structure, 9: large structure, 10: tile
	private float Mass = 0.0f;
	private Chassis InternalStructure;
	public int[] position;//TEMP?
	private float turn;
	private Vector3 moveTo, moveDir, facing;

	Dictionary<string,int> armor = new Dictionary<string,int>();//temp

	private void Start () 
	{
		foreach( string key in Limbs)
		{//Set up chassis dictionaries
			HitTable[key] = new Dictionary<string,int>();
			Proportion[key] = new Dictionary<string,float>() {{"max mass", 0.0f}, {"mass", 0.0f}};
			Components[key] = new List<Component>();
			Armors[key] = new Dictionary<string,Armor>() {{"internal", null}, {"external", null}, {"rear", null}};
		}
		//Chassis configuration
		HitTable["head"]["front"] = 1;
		HitTable["left arm"]["front"] = 5;
		HitTable["right arm"]["front"] = 5;
		HitTable["left leg"]["front"] = 4;
		HitTable["right leg"]["front"] = 4;
		HitTable["left torso"]["front"] = 5;
		HitTable["right torso"]["front"] = 5;
		HitTable["center torso"]["front"] = 7;
		HitTable["head"]["left"] = 1;
		HitTable["left arm"]["left"] = 9;
		HitTable["right arm"]["left"] = 3;
		HitTable["left leg"]["left"] = 5;
		HitTable["right leg"]["left"] = 2;
		HitTable["left torso"]["left"] = 7;
		HitTable["right torso"]["left"] = 4;
		HitTable["center torso"]["left"] = 5;
		HitTable["head"]["right"] = 1;
		HitTable["left arm"]["right"] = 3;
		HitTable["right arm"]["right"] = 9;
		HitTable["left leg"]["right"] = 2;
		HitTable["right leg"]["right"] = 5;
		HitTable["left torso"]["right"] = 4;
		HitTable["right torso"]["right"] = 7;
		HitTable["center torso"]["right"] = 5;
		HitTable["head"]["top"] = 6;
		HitTable["left arm"]["top"] = 6;
		HitTable["right arm"]["top"] = 6;
		HitTable["left leg"]["top"] = 0;
		HitTable["right leg"]["top"] = 0;
		HitTable["left torso"]["top"] = 6;
		HitTable["right torso"]["top"] = 6;
		HitTable["center torso"]["top"] = 6;
		HitTable["head"]["bottom"] = 0;
		HitTable["left arm"]["bottom"] = 0;
		HitTable["right arm"]["bottom"] = 0;
		HitTable["left leg"]["bottom"] = 18;
		HitTable["right leg"]["bottom"] = 18;
		HitTable["left torso"]["bottom"] = 0;
		HitTable["right torso"]["bottom"] = 0;
		HitTable["center torso"]["bottom"] = 0;
		Proportion["head"]["ratio"] = 0.03f;
		Proportion["left arm"]["ratio"] = 0.12f;
		Proportion["right arm"]["ratio"] = 0.12f;
		Proportion["left leg"]["ratio"] = 0.14f;
		Proportion["right leg"]["ratio"] = 0.14f;
		Proportion["left torso"]["ratio"] = 0.15f;
		Proportion["right torso"]["ratio"] = 0.15f;
		Proportion["center torso"]["ratio"] = 0.15f;
		//Rendering variables
		moveTo = transform.position;
		facing = new Vector3(1.0f, 0.0f, 0.0f);
		moveDir = new Vector3(1.0f, 0.0f, 0.0f);
		Speed["max"] = 5;
		Speed["remaining"] = 5;
		armor["max"] = 25;
		armor["remaining"] = 25;
		//Test mech
		SetMass(50.0f, new TitaniumBipedalMech());//Set Mass and Structure
		AddComponent("center torso", new M6Fusion(5.0f));//Add engine
		AddComponent("left leg", new M1LegActuator(1.0f));//Add actuators
		AddComponent("right leg", new M1LegActuator(1.0f));//Add actuators
		AddComponent("left leg", new M1FootActuator(0.25f));//Add actuators
		AddComponent("right leg", new M1FootActuator(0.25f));//Add actuators
		AddComponent("left leg", new M1HipActuator(0.25f));//Add actuators
		AddComponent("right leg", new M1HipActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1ArmActuator(0.5f));//Add actuators
		AddComponent("right arm", new M1ArmActuator(0.5f));//Add actuators
		AddComponent("left arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("head", new StandardCockpit());//Add cockpit
		AddComponent("head", new LifeSupport());//Add life support
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("left leg", new X1Impulse());//Add thrusters
		AddComponent("right leg", new X1Impulse());//Add thrusters
		AddComponent("left arm", new TC5());//Add weapons
		AddComponent("right arm", new TC5());//Add weapons
		AddArmor("center torso", "external", 1.0f);//Add armor
		AddArmor("center torso", "rear", 1.0f);//Add armor
		AddArmor("left torso", "external", 1.0f);//Add armor
		AddArmor("left torso", "rear", 1.0f);//Add armor
		AddArmor("right torso", "external", 1.0f);//Add armor
		AddArmor("right torso", "rear", 1.0f);//Add armor
		AddArmor("left arm", "external", 1.0f);//Add armor
		AddArmor("right arm", "external", 1.0f);//Add armor
		AddArmor("left leg", "external", 1.0f);//Add armor
		AddArmor("right leg", "external", 1.0f);//Add armor
		AddArmor("head", "external", 1.0f);//Add armor

		//Once done, LOAD ALL ENTITIES at runtime
		//THEN break Mech the object out of some kidn of rendering object
		//Then create prefabs of the specific mech types I want

		foreach(KeyValuePair<string,List<Component>> type in Components)
		{
			foreach(Component item in type.Value)
				Debug.Log(type.Key+": "+item);
			Debug.Log(Proportion[type.Key]["mass"]+"/"+Proportion[type.Key]["max mass"]);
		}
	}

	private void SetMass(float mass, Chassis chassis)
	{
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Mech mass must be in increments of 0.25.");
		else
			Debug.Log("Mech set at mass: "+mass);
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

	private float AddComponent(string limb, Component part)
	{
		Proportion[limb]["mass"] += part.Mass;//Increment used mass
		Components[limb].Add(part);
		return Proportion[limb]["max mass"] - Proportion[limb]["mass"];
	}

	private void AddArmor(string limb, string loc, float mass)
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
	
	private void Update () 
	{
		if(facing != moveDir)
			EventTurn();
		else if(moveTo != transform.position)
			EventMove();
	}

	private void Interval()
	{
		Speed["remaining"] = Speed["max"];
	}

	public void OrderMove(GameObject target)
	{
		if((isReady == false) || (Speed["remaining"] <= 0))
			return;
		else
		{
			Speed["remaining"]--;
			isReady = false;
		}
		moveDir = target.transform.position - transform.position;
		moveDir.y =0;
		//Generate a path later, but for now, cram down to one space move
		if(moveDir.x != 0.0f)
			moveDir.x /= Mathf.Abs(moveDir.x);
		if(moveDir.z != 0.0f)
			moveDir.z /= Mathf.Abs(moveDir.z);
		moveTo = transform.position + moveDir;
        Vector3 dir = Vector3.Cross(facing, moveDir);
        if(dir.y > 0.0f)
			turn = Vector3.Angle(facing, moveDir);
		else
			turn = -Vector3.Angle(facing, moveDir);
	}

	private void EventMove()
	{
        float step = 2.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTo, step);		
		if(facing == moveDir)
			isReady = true;
	}

	private void EventTurn()
	{
		float step;
        if(turn < 0.0f)
        {
       		step = -100.0f * Time.deltaTime;
	        if(step < turn)
	        	step = turn;
        }
        else
        {
       	 	step = 100.0f * Time.deltaTime;
	        if(step > turn)
	        	step = turn;
        }
        transform.Rotate(0.0f, step, 0.0f);
        turn -= step;
        if(turn == 0.0f)
        {
        	facing = moveDir;
        	isReady = true;
        }
	}

	public void OrderFire(GameObject target)
	{
		float result;
		if(isReady == false)
			return;
		else
			isReady = false;
		Transform clone;
		int gunnery = 4;//int pilot 2
		int accuracy = gunnery;
		accuracy += GetMovementPenalty();//not yet set
		accuracy += GetAccuracyPenalty();//not yet set
		if(target.tag != "Tile")
			accuracy += target.GetComponent<Mech>().GetDodge();//not yet set
		if(accuracy > 11)
			accuracy = 11;
		result = Random.Range(0.1f, 100.0f);
	    //clone = (Transform)GameObject.Instantiate(bullet, transform.position, transform.rotation);
		if(result < Engine.Random[accuracy])
		{
			Debug.Log("HIT");
	    	clone = (Transform)GameObject.Instantiate(bullet, transform.position, transform.rotation);
	    	clone.gameObject.GetComponent<Bullet>().moveTo = target.transform;
		}
		else
		{
			Debug.Log("MISS");
			/*
			Debug.Log(target.tag);
			Debug.Log(target.GetComponent<Mech>().position[0]);
			Debug.Log(target.GetComponent<Mech>().position[1]);
			Debug.Log(target.GetComponent<Mech>().position[2]);
			Debug.Log(Engine.Grid[7,0,10][0]);
			return;
			if(target.tag != "Tile")
	    		clone.gameObject.GetComponent<Bullet>().moveTo = Engine.Grid[7,0,10][0];
	    	else
	    		clone.gameObject.GetComponent<Bullet>().moveTo = Engine.Grid[target.GetComponent<Tile>().position[0]+1, 0, target.GetComponent<Tile>().position[2]-1][0];
	    	*/
		}
	    isReady = true;
	}

	public void EventDamage(Bullet bullet)
	{
		audio.Play();
		armor["remaining"] -= bullet.damage;
		if(armor["remaining"] <= 0)
			EventDestruct();
	}

	public void EventDestruct()
	{
	    GameObject.Instantiate(largeExplosion, transform.position, transform.rotation);
	    Engine.Entities.Remove(gameObject);
		Destroy(gameObject);
		//Remove from initiative? etc.
	}

	int GetMovementPenalty()
	{
		return 0;
	}

	int GetAccuracyPenalty()
	{
		return 0;
	}

	public int GetDodge()
	{
		return 0;
	}

    void OnMouseDown() {//TEMP
 		Debug.Log("Clicked");
    }
}
