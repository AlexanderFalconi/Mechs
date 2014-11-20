using UnityEngine;
using System.Collections;

public class Tile : Entity {

	public Tile()
	{
		Size = 10;
	}
	
	public int GetDodge()
	{
		return 0;
	}

	public void EventDamage(Bullet bullet)
	{
		audio.Play();
	}

}