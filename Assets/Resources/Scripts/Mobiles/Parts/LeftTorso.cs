using UnityEngine;
using System.Collections.Generic;

public class LeftTorso : Part 
{
	public LeftTorso () 
	{
		Short = "left torso";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 7}, {"right", 4}};
		Proportion["ratio"] = 0.15f;
	}
	public float[] GetFiringArc()
	{
		float[] arc = {285.0f, 0.0f};
		return arc;
	}
}
