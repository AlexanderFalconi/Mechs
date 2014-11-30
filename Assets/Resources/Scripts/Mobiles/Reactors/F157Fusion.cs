using UnityEngine;
using System.Collections;

public class M157Fusion : Reactor 
{
	public string[] Compatibility = new string[] {"left torso", "right torso", "center torso"};

	public M157Fusion(float mass): base(mass) 
	{
		Short = "Mark-157 Fusion Reactor";
		Long = "A MechTech Mark-157 fusion reactor. It remains somewhat experimental, and its oversized design makes it appealing only to the lightest of mechs.";
		float energy = 45.0f;//Energy starts at this value
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		float increases = 1.0f;
		for(float i = 0.5f; i <= mass; i+=0.5f)
		{//Find energy value at mass
			increases *= 0.95f;
			energy += 45.0f*increases;
		}
		Power = energy;
	}
}