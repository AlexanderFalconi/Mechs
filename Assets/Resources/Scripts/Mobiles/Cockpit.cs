using UnityEngine;
using System.Collections;

public class Cockpit : Component 
{
	public int Personell;
	public string Ejection;
	public Pilot PilotOb;

	public override bool AddPersonell(Pilot pilot)
	{
		if(PilotOb == null)
		{//Enough room
			PilotOb = pilot;
			return true;
		}
		else//Full
			return false;
	}

	public void RemovePersonell()
	{
		PilotOb = null;
	}

	public void EjectPilot()
	{
		RemovePersonell();
	}

	public override void EventDamage(int damage)
	{
		if(PilotOb != null)//Pilot inside
			PilotOb.EventDamage(damage*damage);//Could kill
		base.EventDamage(damage);
	}
}
