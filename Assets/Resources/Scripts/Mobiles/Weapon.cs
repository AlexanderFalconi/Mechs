using UnityEngine;
using System.Collections.Generic;

public class Weapon : Component 
{
	public int Discharged = 0;
	public int Capacity = 0;
	public Ammunition Loaded;
	public List<string> Ammo = new List<string>();
	public void EventReload(int max)
	{
		Installed.Master.Energy -= Energy["reload"];
		if(max >= Capacity)
			max = Capacity;
		Loaded.Amount += Installed.EventReload(Ammo[0], max);
	}
}
