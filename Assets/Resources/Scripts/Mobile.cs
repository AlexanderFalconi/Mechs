using UnityEngine;
using System.Collections.Generic;

public class Mobile : Entity {
	private float turnTo;
	public Vector3 moveDir, faceDir;
	public List<Vector3> moveTo;
	public bool isDone = false;
	public bool isReady = true;
	public float rate = 2.0f;
    public Dictionary<string,AudioClip> SoundFX = new Dictionary<string,AudioClip>();

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

	public virtual void EventDestroyed()
	{
		audio.PlayOneShot(SoundFX["destruct"]);
	}

	public void NextFace()
	{
	    //audio.PlayOneShot(SoundFX["short motion"]);
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
		int step = Random.Range(0, 4);
	    audio.PlayOneShot(SoundFX["move "+step]);
	    audio.loop = true;
		moveTo.RemoveAt(0);
		if(moveTo.Count > 0)
			NextFace();
		else
			isReady = true;
	}

	public virtual void EventRangedAttack(Entity target, Ammunition bullet)
	{
		SoundFX["ranged attack"] = Resources.Load(bullet.SoundFX) as AudioClip;
		audio.PlayOneShot(SoundFX["ranged attack"]);
	}

	public virtual void EventDamage(Entity attacker, Ammunition bullet)
	{
		SoundFX["ranged attack"] = Resources.Load(bullet.SoundFX) as AudioClip;
		audio.PlayOneShot(SoundFX["ranged attack"]);
	}

	public virtual void EventStand()
	{
	    audio.PlayOneShot(SoundFX["long motion"]);
		transform.Rotate(0, 0, -90);
		transform.position += new Vector3(0.0f, 0.5f, 0.0f);
	}


	public virtual void EventProne()
	{
	    audio.PlayOneShot(SoundFX["long motion"]);
		transform.Rotate(0, 0, 90);
		transform.position += new Vector3(0.0f, -0.5f, 0.0f);
	}

	public virtual void EventFall(int height)
	{
	    audio.PlayOneShot(SoundFX["fall"]);
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
