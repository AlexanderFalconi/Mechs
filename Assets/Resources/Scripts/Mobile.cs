using UnityEngine;
using System.Collections.Generic;

public class Mobile : Entity {
	private float turnTo;
	public Vector3 moveDir, faceDir;
	public List<Vector3> moveTo;
	public bool isDone = false;
	public bool isReady = true;
	public float rate = 2.0f;

	public override void Update () 
	{
		if(faceDir != moveDir)
			EventTurn();
		else if(moveTo.Count > 0)
		{
			if(Vector3.Distance(transform.position, moveTo[0]) > 0.05f)
				EventMove();
			else
				NextMove();
		}
	}

	public void EventDestruct()
	{
	    //GameObject.Instantiate(largeExplosion, transform.position, transform.rotation);
	    //Engine.Entities.Remove(transform);//Remove from initiative
		Destroy(transform);
	}

	public void NextFace()
	{
		moveDir = moveTo[0] - transform.position;
		moveDir.y =0;
        Vector3 dir = Vector3.Cross(faceDir, moveDir);
        if(dir.y > 0.0f)
			turnTo = Vector3.Angle(faceDir, moveDir);
		else
			turnTo = -Vector3.Angle(faceDir, moveDir);
	}

	public void NextMove()
	{
		moveTo.RemoveAt(0);
		if(moveTo.Count > 0)
			NextFace();
		else
			isReady = true;
	}

	public void OrderFire(GameObject target, Ammunition bullet)//TEMP: later call it EventFire
	{
		Transform clone = (Transform)GameObject.Instantiate(Resources.Load(bullet.PrefabID), transform.position, transform.rotation); 
		Debug.Log(target.transform.position);
		//clone.gameObject.GetComponent<Mobile>().moveTo = target.transform.position;
	}

	public virtual void EventStand()
	{
		transform.Rotate(0, 0, -90);
		transform.position += new Vector3(0.0f, 0.5f, 0.0f);
	}

	public virtual void EventProne()
	{
		transform.Rotate(0, 0, 90);
		transform.position += new Vector3(0.0f, -0.5f, 0.0f);
	}

	public virtual void EventFall(int height)
	{
		transform.Rotate(0, 0, 90);
		transform.position += new Vector3(0.0f, -0.5f, 0.0f);
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
        	faceDir = moveDir;
	}

	public override void SetPosition(Vector3 pos, Vector3 face)
	{
		faceDir = face;
		moveDir = face;
		base.SetPosition(pos, face);
	}
}
