using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
	private static float[] Random = {99.5f, 97.2f, 91.6f, 83.3f, 72.2f, 58.3f, 41.6f, 27.7f, 16.6f, 8.3f, 2.7f, 0.5f};
	public List<Transform> Entities = new List<Transform>();
	private int turn;
	public Transform boundingBox, grass, hellfyre, bushwacker;
	private Transform boundingBoxOb;
	public List<Transform>[,,] Grid = new List<Transform>[30, 5, 30]; 
	// Use this for initialization
	private void Start () 
	{
		Transform entity;
	    for (int z = 0; z < 30; z++) 
	    {//Generate terrain
	        for (int y = 0; y < 5; y++) {
		        for (int x = 0; x < 30; x++) 
		        {
		            Grid[x,0,z] = new List<Transform>();
		            if(y == 0)
		            {
			   	 		entity = (Transform)GameObject.Instantiate(grass);
		            	entity.gameObject.GetComponent<Tile>().SetPosition(new Vector3(x, y, z));
		            	Grid[x,0,z].Add(entity);
		            }
		        }
		    }
	    }
		entity = (Transform)GameObject.Instantiate(hellfyre);//Add mech
		EventReceive(entity, new Vector3(3.0f, 0.0f, 10.0f), new Vector3(1.0f, 0.0f, 0.0f));
		entity.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Alex", 3, 5));
	    GameObject.FindWithTag("Player").GetComponent<Player>().Selected = entity;//Select this mech
	    boundingBoxOb = (Transform)GameObject.Instantiate(boundingBox, entity.transform.position, Quaternion.identity);
	    boundingBoxOb.parent = entity;//attach bounding box to mech
		entity = (Transform)GameObject.Instantiate(bushwacker);//Add mech
		EventReceive(entity, new Vector3(20.0f, 0.0f, 15.0f), new Vector3(-1.0f, 0.0f, 0.0f));
		entity.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Mark", 3, 5));
		entity.gameObject.AddComponent<AI>();
		entity = (Transform)GameObject.Instantiate(bushwacker);//Add mech
		EventReceive(entity, new Vector3(18.0f, 0.0f, 13.0f), new Vector3(-1.0f, 0.0f, 0.0f));
		entity.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Frank", 4, 4));
		entity.gameObject.AddComponent<AI>();
		entity = (Transform)GameObject.Instantiate(bushwacker);//Add mech
		EventReceive(entity, new Vector3(16.0f, 0.0f, 14.0f), new Vector3(-1.0f, 0.0f, 0.0f));
		entity.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Eric", 5, 3));
		entity.gameObject.AddComponent<AI>();
		turn = 0;//turn starts with first in list
	}
	
	public void EventReceive(Transform entity, Vector3 position, Vector3 facing)
	{
	    entity.gameObject.GetComponent<Mech>().SetPosition(position, facing);
	    Entities.Add(entity);//add mech to entities list
	    Grid[(int)entity.position.x, (int)entity.position.y, (int)entity.position.z].Add(entity);
	    entity.gameObject.GetComponent<Mech>().Environment = this;
	}

	public void EventRelease(Transform entity)
	{
	    Grid[(int)entity.position.x, (int)entity.position.y, (int)entity.position.z].Remove(entity);
	    Entities.Remove(entity);//remove mech from entities list
	    entity.gameObject.GetComponent<Mech>().Environment = null;		
	}
	
	// Update is called once per frame
	private void Update () {
		if((gameObject.GetComponent<AI>() as AI) != null)
		{
			if(Entities[turn].GetComponent<Mech>().isReady)
				Entities[turn].GetComponent<AI>().SimpleAction();
		}
		if(Entities[turn].GetComponent<Mobile>().isDone)
		{
			Entities[turn].GetComponent<Mobile>().isDone = false;
			turn++;
			if(turn >= Entities.Count)
				turn = 0;
			boundingBoxOb.position = Entities[turn].position;
		}
	}

	public void EventMove(Transform entity, Vector3 to)
	{
		Grid[(int)entity.GetComponent<Mech>().Position.x,(int)entity.GetComponent<Mech>().Position.y,(int)entity.GetComponent<Mech>().Position.z].Remove(entity);
		Grid[(int)to.x,(int)to.y,(int)to.z].Add(entity);
	}

	private float GetCover(int size)
	{
		return Mathf.Pow(size, 2.0f);
	}

	public static float GetThreshold(int dc)
	{
		if(dc < 0)
			dc = 0;
		else if(dc > 11)
			dc = 11;
		return Random[dc];
	}
}