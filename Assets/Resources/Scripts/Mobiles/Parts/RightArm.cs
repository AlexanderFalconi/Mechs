using UnityEngine;
using System.Collections.Generic;

public class RightArm : Arm
{
	public RightArm () : base()
	{
		Short = "Right Arm";
		HitTable = new Dictionary<string,int>() {{"front", 5}, {"left", 3}, {"right", 9}};
	}

	public override float[] GetFiringArc()
	{
		float[] arc = new float[2];
		float rotation = 0.0f;
		float expand;
		//foreach(Component item in Components)
		//	rotation += item.GetRotation();
		expand = rotation/Master.GetMass() * 15.0f;//On average should be 225
		arc[0] = 22.5f - expand/2.0f;
		arc[1] = 22.5f + expand/2.0f;
		if(arc[1] >= 360)
			arc[1]-=360;
		return arc;
	}
}
