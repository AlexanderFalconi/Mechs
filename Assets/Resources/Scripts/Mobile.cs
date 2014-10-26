using UnityEngine;
using System.Collections.Generic;

public class Mobile : MonoBehaviour {
	private float turnTo;
	public Vector3 moveDir, facing;
	public List<Vector3> moveTo;
	public bool isDone = false;
	public bool isReady = true;
	public float rate = 2.0f;

	private void Update () 
	{
		if(facing != moveDir)
			EventTurn();
		else if(moveTo.Count > 0)
		{
			if(Vector3.Distance(transform.position, moveTo[0]) > rate)
				EventMove();
			else
				NextMove();
		}
	}

	public void EventDestruct()
	{
	    //GameObject.Instantiate(largeExplosion, transform.position, transform.rotation);
	    Engine.Entities.Remove(transform);//Remove from initiative
		Destroy(transform);
	}

	public void NextMove()
	{
		moveTo.RemoveAt(0);
		if(moveTo.Count > 0)
		{
			moveDir = moveTo[0] - transform.position;
			moveDir.y =0;
	        Vector3 dir = Vector3.Cross(facing, moveDir);
	        if(dir.y > 0.0f)
				turnTo = Vector3.Angle(facing, moveDir);
			else
				turnTo = -Vector3.Angle(facing, moveDir);
		}
		else
			isReady = true;
	}

	public void OrderFire(GameObject target, Ammunition bullet)
	{
		Transform clone = (Transform)GameObject.Instantiate(Resources.Load(bullet.PrefabID), transform.position, transform.rotation); 
		Debug.Log(target.transform.position);
		//clone.gameObject.GetComponent<Mobile>().moveTo = target.transform.position;
	}

	private void EventMove()
	{
        float step = rate * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTo[0], step);		
	}

	private void EventTurn()
	{
		float step;
        if(turnTo < 0.0f)
        {
       		step = -100.0f * Time.deltaTime;
	        if(step < turnTo)
	        	step = turnTo;
        }
        else
        {
       	 	step = 100.0f * Time.deltaTime;
	        if(step > turnTo)
	        	step = turnTo;
        }
        transform.Rotate(0.0f, step, 0.0f);
        turnTo -= step;
        if(turnTo == 0.0f)
        {
        	facing = moveDir;
        	isReady = true;
        }
	}

    void OnMouseDown() {//TEMP
 		Debug.Log("Clicked");
    }
}
