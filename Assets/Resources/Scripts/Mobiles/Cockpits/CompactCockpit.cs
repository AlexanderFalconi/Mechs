using UnityEngine;
using System.Collections;

public class CompactCockpit : Cockpit 
{
	public string[] Compatibility = new string[] {"head"};

	public CompactCockpit () 
	{
		Short = "Compact Cockpit";
		Long = "A compact cockpit made of a light-weight steel alloy. It can house a single pilot.";
		Personell = 1;
		Ejection = "none";
		SetMass(0.75f);
	}
}
