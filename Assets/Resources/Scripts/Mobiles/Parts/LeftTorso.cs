using UnityEngine;
using System.Collections.Generic;

public class LeftTorso : Part 
{
	public LeftTorso () 
	{
		Short = "Left Torso";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 7}, {"right", 4}};
		Proportion["ratio"] = 0.14f;
	}
	public override float[] GetFiringArc()
	{
		float[] arc = new float[] {285.0f, 0.0f};
		return arc;
	}
}
