using UnityEngine;
using System.Collections.Generic;

public class RightLeg : Part 
{
	public RightLeg () 
	{
		Short = "right leg";
		HitTable = new Dictionary<string,int>() {{"front", 4}, {"left", 2}, {"right", 5}};
		Proportion["ratio"] = 0.14f;
		Melee.Add("kick");
	}
	public float[] GetFiringArc()
	{
		float[] arc = {0.0f, 62.5f};
		return arc;
	}
	public int GetMeleeCR()
	{
		return 0;
	}
	//handle movement
}
