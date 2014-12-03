using UnityEngine;
using System.Collections;

public class StandardCockpit : Cockpit 
{
	public string[] Compatibility = new string[] {"head"};
	public StandardCockpit () 
	{
		Short = "Standard Cockpit";
		Long = "A standard cockpit made of reinforced steel. It can house a single pilot.";
		Personell = 1;
		Ejection = "auto";
		SetMass(1.0f);
	}
}
