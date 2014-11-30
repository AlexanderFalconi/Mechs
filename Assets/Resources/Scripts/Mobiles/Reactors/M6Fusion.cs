using UnityEngine;
using System.Collections;

public class M6Fusion : Reactor {
	public string[] Compatibility = new string[] {"center torso"};

	public M6Fusion(float mass): base(mass) 
	{
		Short = "Mark-6 Fusion Reactor";
		Long = "A MechTech Mark-6 fusion reactor. It has a robust, compact design and a reputation as one of the most stable energy sources.";
		float energy = 50.0f;//Energy starts at this value
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		float increases = 1.0f;
		for(float i = 0.5f; i <= mass; i+=0.5f)
		{//Find energy value at mass
			increases *= 0.95f;
			energy += 50.0f*increases;
		}
		Power = energy;
	}
}

