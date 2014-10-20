using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC5 : Weapon 
{
	public string Short = "TC-5";
	public string Long = "A tactical cannon that fires 5cc shells.";
	public int Capacity = 1;
	public List<string> Compatible = new List<string>() {"5cc Shell"};
	public TC5()
	{
		Loaded = new CC5Shell();
		SetMass(2.0f);
	}
}
