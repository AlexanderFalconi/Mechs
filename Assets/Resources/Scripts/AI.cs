using UnityEngine;
using System.Collections.Generic;
using Config;

public class AI : MonoBehaviour 
{
	void Start () 
	{

	}
	
	public void SimpleAction()
	{
		if(GetComponent<Mech>().Environment.Phase == Phases.WEAPON)
		{ 
			foreach(KeyValuePair<string,Part> item in GetComponent<Mech>().Body)
			{
				foreach(Component component in item.Value.Components)
				{
					if(component.GetSystem() == "weapon")
					{
						if(((Weapon)component).Reload["waiting"] != 0)
							continue;
						if(((Weapon)component).Amount == 0)
							GetComponent<Mech>().AttemptReload((Weapon)component);
						else
							((Weapon)component).Select(GetComponent<Mech>().Environment.Inventory[0]);//Always fire all
					}
				}
			}	
		}
		else if(GetComponent<Mech>().Environment.Phase == Phases.DEPLOY)
		{
			foreach(KeyValuePair<string,Part> item in GetComponent<Mech>().Body)
			{
				foreach(Component component in item.Value.Components)
				{
					if(component.GetSystem() == "weapon")
						GetComponent<Mech>().AttemptLoad((Weapon)component);
				}
			}	
		}
		else if(GetComponent<Mech>().Environment.Phase == Phases.ACTION)
		{
			Entity target = GetComponent<Mech>().Environment.Inventory[0];
			float dist = Vector3.Distance(target.transform.position, transform.position);

			if(dist > 5.0f+Random.Range(1, 15))
				GetComponent<Mech>().AttemptMove(target.Position);
			//else too far, lets not move
		}
		GetComponent<Mech>().isDone = true;
	}
}