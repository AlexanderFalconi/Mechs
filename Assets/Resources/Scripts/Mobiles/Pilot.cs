using UnityEngine;
using System.Collections;

public class Pilot {
	public string Name;
	public int HP, Piloting, Gunnery;
	public bool Conscious = true;

	public Pilot (string name, int piloting, int gunnery) 
	{
		Name = name;
		Piloting = piloting;
		Gunnery = gunnery;
		HP = 6;
	}

	public void EventDamage(int dmg)
	{
		HP -= dmg;
		EventConsciousness();
	}

	public void EventConsciousness()
	{
		int dmg = 6 - HP;
		if(Random.Range(0.1f, 100.0f) <= Engine.GetThreshold(1+dmg*2))
			Conscious =  true;
		else
			Conscious = false;		
	}
}