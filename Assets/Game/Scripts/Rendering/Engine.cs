using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
	public static float[] Random = {99.5f, 97.2f, 91.6f, 83.3f, 72.2f, 58.3f, 41.6f, 27.7f, 16.6f, 8.3f, 2.7f, 0.5f};
	public static List<GameObject> Entities = new List<GameObject>();
	private int turn;
	public Transform boundingBox;
	private Transform boundingBoxOb;
	public Transform grass;
	public static List<Transform>[,,] Grid = new List<Transform>[30, 5, 30]; 
	// Use this for initialization
	private void Start () 
	{
		Reactor.Setup();//Setup reactor tables
	    for (int z = 0; z < 30; z++) 
	    {//Generate terrain
	        for (int y = 0; y < 5; y++) {
		        for (int x = 0; x < 30; x++) {
		   	 		Transform clone = (Transform)GameObject.Instantiate(grass, new Vector3(x, 0, z), Quaternion.identity);
		            Grid[x,0,z] = new List<Transform>();
		            if(y == 0)
		            {
		            	Grid[x,0,z].Add(clone);
		            	clone.gameObject.GetComponent<Tile>().SetPosition(x, 0, z);
		            }
		        }
		    }
	    }
		GameObject main = GameObject.FindWithTag("Player");
	    boundingBoxOb = (Transform)GameObject.Instantiate(boundingBox, main.transform.position, main.transform.rotation);
	    boundingBoxOb.parent = main.transform.GetChild(0);
		Entities.Add(GameObject.FindWithTag("Player"));
		//Hardcode enemies for now: later load dynamically using prefab
		Entities.Add(GameObject.Find("Enemy1"));
		Entities.Add(GameObject.Find("Enemy2"));
		Entities.Add(GameObject.Find("Enemy3"));
		//Terrain is hardcoded for now: later dynamically and/or randomly load using prefabs

		//Set the songs here?
		turn = 0;
	}
	
	// Update is called once per frame
	private void Update () {
		if((gameObject.GetComponent<AI>() as AI) != null)
		{
			if(Entities[turn].GetComponent<Mech>().isReady)
				Entities[turn].GetComponent<AI>().SimpleAction();
		}
		if(Entities[turn].transform.GetChild(0).GetComponent<Mech>().isDone)
		{
			Entities[turn].transform.GetChild(0).GetComponent<Mech>().isDone = false;
			turn++;
			if(turn >= Entities.Count)
				turn = 0;
			boundingBoxOb.transform.position = Entities[turn].transform.position;
			boundingBoxOb.transform.rotation = Entities[turn].transform.rotation;
		}
		//If song is done?
			//Change songs?
	}

	private float GetCover(int size)
	{
		return Mathf.Pow(size, 2.0f);
	}
}