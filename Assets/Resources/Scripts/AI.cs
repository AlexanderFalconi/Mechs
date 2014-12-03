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
						((Weapon)component).Select(GetComponent<Mech>().Environment.Inventory[0]);//Always fire all
				}
			}	
		}
		else if(GetComponent<Mech>().Environment.Interval["phase"] == Engine.PHASE_DEPLOY)
		{
			foreach(KeyValuePair<string,Part> item in GetComponent<Mech>().Body)
			{
				foreach(Component component in item.Value.Components)
				{
					if(component.GetSystem() == "weapon")
						GetComponent<Mech>().OrderLoad((Weapon)component);
				}
			}	
		}
		GetComponent<Mech>().isDone = true;
	}
}