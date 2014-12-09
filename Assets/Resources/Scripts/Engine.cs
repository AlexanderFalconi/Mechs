using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Config;

public class Engine : MonoBehaviour 
{
	private static float[] Dice = {99.5f, 97.2f, 91.6f, 83.3f, 72.2f, 58.3f, 41.6f, 27.7f, 16.6f, 8.3f, 2.7f, 0.5f};
	public List<Mech> Inventory = new List<Mech>();
	public Dictionary<string,int> Interval = new Dictionary<string,int>() {{"turn", 0}, {"round", 0}};//Sentinel value 1000
	public Phases Phase = Phases.DEPLOY;
	public Transform boundingBox, grass, hellfyre, bushwacker;
	private Transform boundingBoxOb;
	public List<Entity>[,,] Grid = new List<Entity>[30, 5, 30]; 
	public bool isReady = false;
	public DynamicInput TurnOutput;
	public List<Weapon> Weapons = new List<Weapon>();
	private float delay = 0.0f;
	private bool IsGameOver = false;
	public Report ReportUI;

	// Use this for initialization
	private void Start () 
	{
		Entity entity;
		Mech mech;
	    for (int z = 0; z < 30; z++) 
	    {//Generate terrain
	        for (int y = 0; y < 5; y++) {
		        for (int x = 0; x < 30; x++) 
		        {
		            Grid[x,y,z] = new List<Entity>();
		            if(y == 0)
		            {
			   	 		entity = ((Transform)GameObject.Instantiate(grass)).GetComponent<Entity>();//Add terrain
		            	entity.SetPosition(new Vector3(x, y, z), new Vector3(0.0f, 0.0f, 0.0f));
		            	Grid[x,0,z].Add(entity);
		            }
		        }
		    }
	    }
		mech = ((Transform)GameObject.Instantiate(hellfyre)).GetComponent<Mech>();//Add mech
	    GameObject.FindWithTag("Player").GetComponent<Player>().BindControl(mech);
		EventReceive(mech, new Vector3(7.0f, 1.0f, 13.0f), new Vector3(1.0f, 0.0f, 0.0f));
		mech.gameObject.GetComponent<Mech>().LoadPilot(new Pilot("Player 1", 3, 5));
	    boundingBoxOb = (Transform)GameObject.Instantiate(boundingBox, mech.transform.position, Quaternion.identity);//Initialize bounding box object
	    boundingBoxOb.parent = mech.transform;//attach bounding box to mech
		mech = ((Transform)GameObject.Instantiate(bushwacker)).GetComponent<Mech>();//Add mech
		EventReceive(mech, new Vector3(20.0f, 1.0f, 15.0f), new Vector3(-1.0f, 0.0f, 0.0f));
		mech.gameObject.GetComponent<Mech>().LoadPilot(new Pilot("Mark AI", 3, 5));
		mech.gameObject.AddComponent<AI>();
		mech = ((Transform)GameObject.Instantiate(bushwacker)).GetComponent<Mech>();//Add mech
		EventReceive(mech, new Vector3(18.0f, 1.0f, 13.0f), new Vector3(-1.0f, 0.0f, 0.0f));
		mech.gameObject.GetComponent<Mech>().LoadPilot(new Pilot("Frank AI", 4, 4));
		mech.gameObject.AddComponent<AI>();
		/*
		mech = ((Transform)GameObject.Instantiate(bushwacker)).GetComponent<Mech>();//Add mech
		EventReceive(mech, new Vector3(16.0f, 1.0f, 14.0f), new Vector3(-1.0f, 0.0f, 0.0f));
		mech.gameObject.GetComponent<Mech>().LoadPilot(new Pilot("Eric", 5, 3));
		mech.gameObject.AddComponent<AI>();
		*/
		Phase = Phases.DEPLOY;
		StartTurn();//starts game
	}
	
	public void EventReceive(Mech entity, Vector3 position, Vector3 facing)
	{//Receive a mech
	    entity.SetPosition(position, facing);
	    Inventory.Add(entity);//add mech to inventory list
	    Debug.Log(entity.Position);
	    Grid[(int)entity.Position.x, (int)entity.Position.y, (int)entity.Position.z].Add(entity);
	    entity.Environment = this;
	}

	public void EventRelease(Mech entity)
	{//Receive a mech
	    Grid[(int)entity.Position.x, (int)entity.Position.y, (int)entity.Position.z].Remove(entity);
	    Inventory.Remove(entity);//remove mech from inventory list
	    entity.Environment = null;		
	}

	public bool IsReady()
	{
		if(!isReady || (delay != 0))
			return false;
		else
			return true;
	}
	
	private void Update () 
	{
		if(delay <= 0)
		{
			if(isReady && !IsGameOver)
			{
				Inventory[0].Controller.ActivateCamera(0);
				if(Phase == Phases.ACTION)
				{
					if(Inventory[Interval["turn"]].GetComponent<AI>() as AI != null)
						Inventory[Interval["turn"]].GetComponent<AI>().SimpleAction();
					if(Inventory[Interval["turn"]].isDone)
						NextTurn();
				}
				else if(Phase == Phases.END)
				{
					if(Weapons.Count > 0)
					{
						Inventory[0].Controller.ActivateCamera(1);
						AttemptFire();
					}
					else
						NextTurn();
				}
				else//Phases.WEAPON or Phases.DEPLOY
				{
					foreach(Mech mech in Inventory)
					{
						if(!mech.isDone)
						{
							if(mech.GetComponent<AI>() as AI != null)
								mech.GetComponent<AI>().SimpleAction();//PASS THROUGH FOR NOW
							return;//Keep waiting
						}
					}
					NextTurn();
				}
			}
		}
		else
		{
			if(delay < Time.time)
				delay = 0;
		}
	}

	private void NextTurn()
	{

		isReady = false;//Need to wait until the next turn is set up
		if((Interval["turn"] >= Inventory.Count-1) || (Phase == Phases.DEPLOY))
		{
			switch(Phase)
			{
				case Phases.ACTION:
					Phase++; break;
				case Phases.WEAPON:
					Phase++; break;
				case Phases.END:
					IsGameOver = VictoryConditions();
					Interval["turn"] = 0;//reset turns
					Interval["round"]++; 
					Phase = Phases.ACTION; break;
				default://Is deployment Phase
					Phase = Phases.ACTION; break;
			}
		}
		else//still in action phase
			Interval["turn"]++;
		StartTurn();
	}

	private bool VictoryConditions()
	{
		if((Inventory[0].Status != Statuses.OK) || (Inventory[0].PilotOb == null))
			return true;//Game over, player lost
		foreach(Mech entity in Inventory)
		{
			if(Inventory[0] == entity)
				continue;
			else if((entity.Status == Statuses.OK) && (Inventory[0].PilotOb != null))
				return false;//Game not over
		}
		return true;//Game over, player won
	}

	private void StartTurn()
	{
		if(Phase == Phases.ACTION)
		{
			boundingBoxOb.gameObject.SetActive(true);
			boundingBoxOb.position = Inventory[Interval["turn"]].transform.position - new Vector3(0.0f, 0.5f, 0.0f);
			TurnOutput.Set("Round: "+Interval["round"]+": Action Phase ("+Interval["turn"]+")");
			Inventory[Interval["turn"]].Interval();
		}
		else if(Phase == Phases.WEAPON || Phase == Phases.DEPLOY)
		{//Weapon or Deployment Phase
			boundingBoxOb.gameObject.SetActive(false);
			if(Phase == Phases.WEAPON)
				TurnOutput.Set("Round: "+Interval["round"]+": Weapon Phase");
			else
				TurnOutput.Set("Deployment Phase");
			foreach(Mech mech in Inventory)
				mech.Interval();
		}
		isReady = true;//The next turn is ready
	}

	public void RegisterWeapon(Weapon weapon)
	{
		if(!Weapons.Contains(weapon))
			Weapons.Add(weapon);
		//else is duplicate
	}

	public void UnregisterWeapon(Weapon weapon)
	{
		Weapons.Remove(weapon);
	}

	public void AttemptFire()
	{
		/*
     	Vector2 mouse;
     	RaycastHit hit;
     	float range = 100.0f;
     	LineRenderer line;
     	Material lineMaterial;
    	line = GetComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.renderer.material = lineMaterial;
        line.SetWidth(0.1f, 0.25f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        line.enabled = true;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hit.point + hit.normal);
        line.enabled = false;             
        */
		Weapon weapon = Weapons[0];
		Debug.Log("WEAPON?");
		Debug.Log(weapon);
		ReportUI.UpdateUIAction(weapon);
		GameObject shotcam = GameObject.Find("ViewFirstPerson");
		Vector3 dirToTarget = (weapon.Selected.transform.position - weapon.Installed.Master.transform.position).normalized;
		shotcam.transform.position = weapon.Installed.Master.transform.position + new Vector3(dirToTarget.x*-2.0f, 3.0f, dirToTarget.z*-2.0f);
		shotcam.transform.LookAt(weapon.Selected.transform);
		Weapons.RemoveAt(0);
		weapon.Installed.Master.AttemptFire(weapon);
		weapon.Selected = null;
		delay = Time.time+2.0f;
	}

	public void EventMove(Mech entity, List<Vector3> path, SimpleMove canMove, StepMove eventTurn, StepMove eventMove, SimpleMove eventBalance, Entity target = null)
	{
		Entity collider;
		List<Vector3> tmp = new List<Vector3>();
		foreach(Vector3 move in path)
		{
			if(!canMove())
				break;
			if(!eventTurn(entity.Position - move))
				break;
			if(!canMove())
				break;
			if(!eventMove(move))
				break;
			Grid[(int)entity.Position.x,(int)entity.Position.y,(int)entity.Position.z].Remove(entity);
			Grid[(int)move.x,(int)move.y,(int)move.z].Add(entity);
			collider = GetCollision(entity, target);
			if(collider != null)
			{
				if(!entity.EventCollisionAttack(collider, target))
					break;//The collision arrested the move
			}
			if(!eventBalance())
				break;
		}
		if(entity.Posture != Postures.PRONE || !CanOccupy(entity))
			entity.EventFall(1);//Ended up in an overloaded space, must fall
		entity.UpdateUI();
	}

	public List<Entity> GetGridLocation(Vector3 position)
	{
		return Grid[(int)position.x,(int)position.y,(int)position.z];
	}

	public static float GetThreshold(int dc)
	{
		if(dc < 0)
			dc = 0;
		else if(dc > 11)
			dc = 11;
		return Dice[dc];
	}

	public Entity GetCollision(Mech movant, Entity target)
	{
		float inevitable = 0.0f;
		List<Entity> others = Grid[(int)movant.Position.x,(int)movant.Position.y,(int)movant.Position.z];
		if(others.Count <= 1)
			return null;//Can't collide with self
		if(others.Contains(target))
			return target;//Singled out for collision
		foreach(Entity ent in others)
			inevitable += Mathf.Pow(ent.Size, 2.0f);
		if(Random.Range(0.1f, 100.0f) <= inevitable)
		{//A collision must happen
			inevitable -= Mathf.Pow(movant.Size, 2.0f);
			others.Remove((Entity)movant);
			float result = Random.Range(0.1f, inevitable);
			foreach(Entity ent in others)
			{//Pick one to collide with
				result -= Mathf.Pow(ent.Size, 2.0f);
				if(result <= 0.0f)
					return ent;
			}
		}
		return null;//No collision
	}

	public bool OnLand(Vector3 locator)
	{
		if(Grid[(int)locator.x,(int)locator.y,(int)locator.z].Count < 1 || !(Grid[(int)locator.x,(int)locator.y,(int)locator.z] is Tile))//air
			return false;//In air
		else
			return true;//On ground
	}

	public bool CanOccupy(Mech movant)
	{
		int occupance = 0;
		List<Entity> others = Grid[(int)movant.Position.x,(int)movant.Position.y,(int)movant.Position.z];
		foreach(Entity ent in others)
		{
			if(((Mech)ent).Posture != Postures.PRONE)
				occupance += ent.Size;
		}
		if(occupance > 10)
			return false;//Too crowded
		else
			return true;
	}

	static public Vector3 Inverse(Vector3 dir)
	{
		return -dir;
	}
}