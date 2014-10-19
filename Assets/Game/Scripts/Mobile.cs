using UnityEngine;
using System.Collections.Generic;

public class Mobile : MonoBehaviour {
	public Transform bullet;
	public Transform largeExplosion;
	private float turnTo;
	private Vector3 moveTo, moveDir, facing;
	public bool isDone = false;
	public bool isReady = true;

	private void Start () 
	{
		moveTo = transform.position;
		facing = new Vector3(1.0f, 0.0f, 0.0f);
		moveDir = new Vector3(1.0f, 0.0f, 0.0f);
	}

	private void Update () 
	{
		if(facing != moveDir)
			EventTurn();
		else if(moveTo != transform.position)
			EventMove();
	}

	public void EventDestruct()
	{
	    GameObject.Instantiate(largeExplosion, transform.position, transform.rotation);
	    Engine.Entities.Remove(transform);
		Destroy(transform);
		//Remove from initiative? etc.
	}

	public void OrderMove(GameObject target)
	{
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
			turnTo = Vector3.Angle(facing, moveDir);
		else
			turnTo = -Vector3.Angle(facing, moveDir);
	}

	public void OrderFire(GameObject target)
	{
		//Instantiate projectile
		Transform clone;
	    isReady = true;
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
