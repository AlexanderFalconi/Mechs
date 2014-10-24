using UnityEngine;
using System.Collections.Generic;

public class RightArm : Part
{
	public RightArm () 
	{
		Short = "right arm";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 3}, {"right", 9}};
		Proportion["ratio"] = 0.12f;
		Melee.Add("punch");
		Melee.Add("kick");
	}
	public float[] GetFiringArc()
	{
		//affected by actuators
		float[] arc = {292.5f, 157.5f};
		return arc;
	}
	public int GetMeleeCR()
	{
		return 1;
	}
}
