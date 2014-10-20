using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC15 : Weapon 
{
	public string Short = "TC-15";
	public string Long = "A tactical cannon that fires 15cc shells.";
	public int Capacity = 1;
	public List<string> Compatible = new List<string>() {"15cc Shell"};
	public TC15()
	{
		SetMass(7.0f);
	}
}
