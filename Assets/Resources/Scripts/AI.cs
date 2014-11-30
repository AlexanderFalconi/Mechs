using UnityEngine;
using System.Collections.Generic;

public class AI : MonoBehaviour 
{
	void Start () 
	{

	}
	
	public void SimpleAction()
	{
		if(GetComponent<Mech>().Environment.Interval["phase"] == Engine.PHASE_WEAPON)
		{
			foreach(KeyValuePair<string,Part> item in GetComponent<Mech>().Body)
			{
				foreach(Component component in item.Value.Components)
				{
					if(component.GetSystem() == "weapon")
						component.Selected = true;//Always fire all
				}
			}	
			GetComponent<Mech>().AttemptFire(GetComponent<Mech>().Environment.Inventory[0]);	
		}
		else if(GetComponent<Mech>().Environment.Interval["phase"] == Engine.PHASE_DEPLOY)
		{
			foreach(KeyValuePair<string,Part> item in GetComponent<Mech>().Body)
			{
				foreach(Component component in item.Value.Components)
				{
					if(component.GetSystem() == "weapon")
					{
						component.Selected = true;//Always fire all
						GetComponent<Mech>().OrderLoad((Weapon)component);
					}
				}
			}	
		}
		GetComponent<Mech>().isDone = true;
	}
}