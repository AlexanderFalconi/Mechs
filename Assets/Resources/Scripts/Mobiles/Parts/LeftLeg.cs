using UnityEngine;
using System.Collections.Generic;

public class LeftLeg : Leg
{
	public LeftLeg () : base()
	{
		Short = "Left Leg";
		HitTable = new Dictionary<string,int>() {{"front", 4}, {"left", 5}, {"right", 2}};
	}

	public override float[] GetFiringArc()
	{
		float[] arc = new float[] {285.0f, 0.0f};
		return arc;
	}
}
