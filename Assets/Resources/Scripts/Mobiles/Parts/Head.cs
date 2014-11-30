using UnityEngine;
using System.Collections.Generic;

public class Head : Part
{
	public Head () 
	{
		Short = "Head";
		HitTable = new Dictionary<string,int>() {{"front", 1}, {"left", 1}, {"right", 1}};
		Proportion["ratio"] = 0.04f;
	}
	public override float[] GetFiringArc()
	{
		float[] arc = new float[] {202.5f, 62.5f};
		return arc;
	}
}
