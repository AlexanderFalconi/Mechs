using UnityEngine;
using System.Collections;

public class Tile : Entity 
{
	int MoveCost;

	public Tile()
	{
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

	public override string GetEntityType()
	{
		return "tile";
	}
}