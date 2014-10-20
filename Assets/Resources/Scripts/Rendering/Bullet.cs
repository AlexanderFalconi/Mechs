using UnityEngine;
using System.Collections;

public class Bullet : Mobile {
	public Bullet ()
	{
		rate = 8.0f;
	}

	public void OnAwake()
	{
		audio.Play();	
	}

	public void EndMove()
	{
		EventDestruct();
	}
}
