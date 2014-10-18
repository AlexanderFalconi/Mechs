using UnityEngine;
using System.Collections;

public class LifeSupport : Component 
{
	public string Short = "Life Support";
	public string Long = "A life support module that provides heat insulation as well as a reserve of oxygen.";
	public string[] Compatibility = new string[] {"head", "center torso"};

	public LifeSupport () 
	{
		SetMass(0.25f);
	}
}
