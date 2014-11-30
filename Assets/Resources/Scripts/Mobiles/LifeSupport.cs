using UnityEngine;
using System.Collections;

public class LifeSupport : Component 
{
	public string[] Compatibility = new string[] {"head", "center torso"};

	public LifeSupport () 
	{
		Short = "Life Support";
		Long = "A life support module that provides heat insulation as well as a reserve of oxygen.";
		SetMass(0.50f);
	}
}
