using UnityEngine;
using System.Collections.Generic;

public class LeftArm : Arm 
{
	public LeftArm() : base()
	{
		Short = "left arm";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 9}, {"right", 3}};
	}

	public override float[] GetFiringArc()
	{
		float[] arc = new float[2];
		float rotation = 0.0f;
		float expand;
		//foreach(Component item in Components)
		//	rotation += item.GetRotation();
		expand = Mathf.Floor(rotation/Master.GetMass()) * 15;//On average should be 225
		arc[0] = 337.5f - expand/2.0f;
		arc[1] = 337.5f + expand/2.0f;
		if(arc[1] >= 360)
			arc[1]-=360;
		return arc;
	}
}