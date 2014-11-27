using UnityEngine;
using System.Collections;

public class Combustion : Reactor 
{
	public string[] Compatibility = new string[] {"center torso"};

	public Combustion(float mass): base(mass) 
	{
		Short = "Combustion Reactor";
		Long = "A powerful combustion reactor still in use by wheeled and tracked vehicles.";
		float energy = 3.0f;//Energy starts at this value
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		float increases = 1.0f;
		for(float i = 0.5f; i <= mass; i+=0.5f)
		{//Find energy value at mass
			increases *= 0.95f;
			energy += 3.0f*increases;
		}
		Power = energy;
	}
}