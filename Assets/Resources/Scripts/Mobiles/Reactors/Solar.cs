using UnityEngine;
using System.Collections;

public class Solar : Reactor 
{
	public string[] Compatibility = new string[] {"left torso", "right torso", "center torso"};

	public Solar(float mass): base(mass) 
	{
		Short = "Solar Reactor";
		Long = "A solar reactor employed for use typically on stationary units and structures.";
		float energy = 1.0f;//Energy starts at this value
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		float increases = 1.0f;
		for(float i = 0.5f; i <= mass; i+=0.5f)
		{//Find energy value at mass
			increases *= 0.95f;
			energy += 1.0f*increases;
		}
		Power = energy;
	}
}