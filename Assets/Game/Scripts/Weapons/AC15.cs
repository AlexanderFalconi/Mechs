using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC15 : Weapon 
{
	public string Short = "AC-15";
	public string Long = "An semi-automatic cannon that fires 15cc shells.";
	public int Capacity = 2;
	public List<string> Compatible = new List<string>() {"15cc Shell"};
	public AC15()
	{
		SetMass(9.0f);
	}
}
