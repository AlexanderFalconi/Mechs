using UnityEngine;
using System.Collections;

public class CompactCockpit : Cockpit 
{
	public string Short = "Compact Cockpit";
	public string Long = "A compact cockpit made of a light-weight steel alloy. It can house a single pilot.";
	private int Capacity = 1;
	private string Ejection = "none";
	public string[] Compatibility = new string[] {"head"};

	public CompactCockpit () {
		SetMass(0.25f);
	}
}
