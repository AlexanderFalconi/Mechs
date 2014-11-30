using UnityEngine;
using System.Collections.Generic;

public class RightLeg : Leg 
{
	public RightLeg () : base () 
	{
		Short = "Right Leg";
		HitTable = new Dictionary<string,int>() {{"front", 4}, {"left", 2}, {"right", 5}};

	}

	public override float[] GetFiringArc()
	{
		float[] arc = new float[] {0.0f, 62.5f};
		return arc;
	}
}