using UnityEngine;
using System.Collections.Generic;

public class LeftArm : Part 
{
	public LeftArm()
	{
		Short = "left arm";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 9}, {"right", 3}};
		Proportion["ratio"] = 0.12f;
		Melee.Add("punch");
		Melee.Add("kick");
	}
	//make sure upper and lower arm actuators exist
	//for punch damage make sure hand actuator exists
	//handle aim and accuracy with actuators
	//handle arc

	public float[] GetFiringArc()
	{
		//affected by actuators
		float[] arc = {202.5f, 62.5f};
		return arc;
	}

	public int GetMeleeCR()
	{
		return 1;
	}
}
