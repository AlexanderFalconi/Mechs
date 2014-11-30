using UnityEngine;
using System.Collections;

public class M1Fission : Reactor 
{
	public string[] Compatibility = new string[] {"center torso"};

	public M1Fission(float mass): base(mass) 
	{
		Short = "Mark-1 Fission Reactor";
		Long = "A MechTech Mark-1 fission reactor. It remains in use only by service mechs.";
		float energy = 30.0f;//Energy starts at this value
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		float increases = 1.0f;
		for(float i = 0.5f; i <= mass; i+=0.5f)
		{//Find energy value at mass
			increases *= 0.95f;
			energy += 30.0f*increases;
		}
		Power = energy;
	}
}