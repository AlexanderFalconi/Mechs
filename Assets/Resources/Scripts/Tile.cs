using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public Vector3 Position;
	public string ID;

	// Use this for initialization
	public string GetID()
	{
		return "Tile"+(int)Position.x+"-"+(int)Position.y+"-"+(int)Position.z;
	}
	
	public int GetDodge()
	{
		return 0;
	}

	public void EventDamage(Bullet bullet)
	{
		audio.Play();
	}

	public void SetPosition(Vector3 pos)
	{
		Position = pos;
		transform.position = pos;
	}
}