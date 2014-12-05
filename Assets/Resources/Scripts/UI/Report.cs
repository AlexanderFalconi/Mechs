using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Report : MonoBehaviour 
{
	public Text ActionOutput, ResultOutput;

	public void UpdateUIAction(Weapon weapon)
	{
		Mech mech = weapon.Installed.Master;
		Mech target = weapon.Selected as Mech;
		if(target == null)
			ActionOutput.text = mech.Short + "["+mech.PilotOb.Name+"] firing "+weapon.Loaded+"("+weapon.Short+") at grass.";
		else
			ActionOutput.text = mech.Short + "["+mech.PilotOb.Name+"] firing "+weapon.Loaded+"("+weapon.Short+") at "+target.Short+" ["+target.PilotOb.Name+"].";
	}

	public void UpdateUIResult(int hits, float damage)
	{
		if(hits < 1)
		{
			ResultOutput.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
			ResultOutput.text = "MISSED!";
		}
		else
		{
			ResultOutput.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			ResultOutput.text = hits+" HITS for "+(int)damage+" DAMAGE!";
		}
	}
}