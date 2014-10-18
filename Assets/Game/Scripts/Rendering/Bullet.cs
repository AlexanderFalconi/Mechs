using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Transform moveTo;
	public int damage = 5;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, moveTo.position) > 0.5f)
			EventMove();
		else
		{
			if(moveTo.gameObject.tag != "Tile") 
	    		moveTo.gameObject.GetComponent<Mech>().EventDamage(this);
	    	else
	    		moveTo.gameObject.GetComponent<Tile>().EventDamage(this);
			EventDestruct();
		}
	}

	private void EventDestruct()
	{
		Destroy(gameObject);
	}

	private void EventMove()
	{
        float step = 8.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTo.position, step);		
	}
}
