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
		float rotation;
		int expand;
		float rotation[2];
		foreach(Component item in Components)
			rotation = item.GetRotation();
		expand += Mathf.Floor(rotation/Master.GetMass()) * 15;//On average should be 225
		arc[0] = 22.5f - expand/2;
		arc[1] = 22.5f + expand/2;
		if(arc[1] >= 360)
			arc[1]-=360;
		return arc;
	}

	public float GetAccuracy()
	{
		float accuracy;
		foreach(Component item in Components)
			accuracy += item.GetAccuracy();
		return Mathf.Floor(accuracy/Master.GetMass());
	}

	public int GetMeleeCR()
	{
		return 1;
	}
}
