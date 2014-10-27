using UnityEngine;
using System.Collections;

public class StandardCockpit : Cockpit 
{
	public string Short = "Standard Cockpit";
	public string Long = "A standard cockpit made of reinforced steel. It can house a single pilot and features a manual ejection lever.";
	private int Capacity = 1;
	private string Ejection = "manual";
	public string[] Compatibility = new string[] {"head"};
	public StandardCockpit () 
	{
		SetMass(0.5f);
	}
}
