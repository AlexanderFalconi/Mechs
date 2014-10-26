using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
	public static float[] Random = {99.5f, 97.2f, 91.6f, 83.3f, 72.2f, 58.3f, 41.6f, 27.7f, 16.6f, 8.3f, 2.7f, 0.5f};
	public static List<Transform> Entities = new List<Transform>();
	private int turn;
	public Transform boundingBox, grass, hellfyre, bushwacker;
	private Transform boundingBoxOb;
	public static List<Transform>[,,] Grid = new List<Transform>[30, 5, 30]; 
	// Use this for initialization
	private void Start () 
	{
		Transform clone, mech;
	    for (int z = 0; z < 30; z++) 
	    {//Generate terrain
	        for (int y = 0; y < 5; y++) {
		        for (int x = 0; x < 30; x++) 
		        {
		            Grid[x,0,z] = new List<Transform>();
		            if(y == 0)
		            {
			   	 		clone = (Transform)GameObject.Instantiate(grass);
		            	clone.gameObject.GetComponent<Tile>().SetPosition(new Vector3(x, y, z));
		            	Grid[x,0,z].Add(clone);
		            }
		        }
		    }
	    }
	    //Add mech
		mech = (Transform)GameObject.Instantiate(hellfyre);
		mech.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Alex", 3, 5));
	    mech.gameObject.GetComponent<Mech>().SetPosition(new Vector3(3.0f, 0.0f, 10.0f), 0);
	    mech.gameObject.GetComponent<Mech>().ID = "Hellfyre0";
	    Entities.Add(mech);//add mech to entities list
	    GameObject.FindWithTag("Player").GetComponent<Player>().Selected = mech;//Select this mech
	    boundingBoxOb = (Transform)GameObject.Instantiate(boundingBox, mech.transform.position, mech.transform.rotation);
	    boundingBoxOb.parent = mech;//attach bounding box to mech
	    //Add mech
		mech = (Transform)GameObject.Instantiate(bushwacker);
		mech.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Mark", 3, 5));
	    mech.gameObject.GetComponent<Mech>().SetPosition(new Vector3(20.0f, 0.0f, 15.0f), 4);
	    mech.gameObject.GetComponent<Mech>().ID = "Bushwacker0";
		mech.gameObject.AddComponent<AI>();
	    Entities.Add(mech);//add mech to entities list
	    //Add mech
		mech = (Transform)GameObject.Instantiate(bushwacker);
		mech.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Tom", 4, 4));
	    mech.gameObject.GetComponent<Mech>().SetPosition(new Vector3(18.0f, 0.0f, 13.0f), 4);
	    mech.gameObject.GetComponent<Mech>().ID = "Bushwacker1";
		mech.gameObject.AddComponent<AI>();
	    Entities.Add(mech);//add mech to entities list
	    //Add mech
		mech = (Transform)GameObject.Instantiate(bushwacker);
		mech.gameObject.GetComponent<Mech>().SetPilot(new Pilot("Eric", 5, 3));
	    mech.gameObject.GetComponent<Mech>().SetPosition(new Vector3(16.0f, 0.0f, 14.0f), 4);
	    mech.gameObject.GetComponent<Mech>().ID = "Bushwacker2";
		mech.gameObject.AddComponent<AI>();
	    Entities.Add(mech);//add mech to entities list
		turn = 0;//turn starts with first in list
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
			boundingBoxOb.rotation = Entities[turn].rotation;
		}
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