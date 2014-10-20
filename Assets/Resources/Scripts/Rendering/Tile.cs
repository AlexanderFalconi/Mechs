using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public int[] position;

	// Use this for initialization
	void Start () {
		
	}
	
	public int GetDodge()
	{
		return 0;
	}

	public void EventDamage(Bullet bullet)
	{
		audio.Play();
	}

	public void SetPosition(int x, int y, int z)
	{
		position = new int[3];
		position[0] = x;
		position[1] = y;
		position[2] = z;
	}
}