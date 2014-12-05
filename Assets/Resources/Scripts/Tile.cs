using UnityEngine;
using System.Collections;

public class Tile : Entity 
{
	public int MoveCost;

	public Tile()
	{
		Short = "grass";
		Size = 10;
		MoveCost = 1;//TEMP: For now this is default
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