using UnityEngine;
using System.Collections;

public class M6Fusion : Reactor {
	public string[] Compatibility = new string[] {"center torso"};

	public M6Fusion(float mass): base(mass, "m6 fusion") 
	{
		Short = "Mark-6 Fusion Reactor";
		Long = "A MechTech Mark-6 fusion reactor. It has a robust, compact design and a reputation as one of the most stable energy sources.";
	}
}
