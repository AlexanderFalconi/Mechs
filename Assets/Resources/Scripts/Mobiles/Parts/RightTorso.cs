using UnityEngine;
using System.Collections.Generic;

public class RightTorso : Part 
{
	public RightTorso () 
	{
		Short = "right torso";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 4}, {"right", 7}};
		Proportion["ratio"] = 0.15f;
	}
	public float[] GetFiringArc()
	{
		float[] arc = new float[] {0.0f, 62.5f};
		return arc;
	}
}
