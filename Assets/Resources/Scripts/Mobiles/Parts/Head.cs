using UnityEngine;
using System.Collections.Generic;

public class Head : Part
{
	public Head () 
	{
		Short = "head";
		HitTable = new Dictionary<string,int>() {{"front", 1}, {"left", 1}, {"right", 1}};
		Proportion["ratio"] = 0.03f;
	}
	public float[] GetFiringArc()
	{
		float[] arc = new float[] {202.5f, 62.5f};
		return arc;
	}
}
