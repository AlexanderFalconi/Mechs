using UnityEngine;
using System.Collections;

public class Cockpit : Component 
{
	public Pilot PilotOb;
	private void EventDamage(int damage)
	{
		if(PilotOb != null)//Pilot inside
			PilotOb.EventDamage(damage*damage);//Could kill
		base.EventDamage(damage);
	}
}
