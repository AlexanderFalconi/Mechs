using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC10 : Weapon 
{
	public string Short = "TC-10";
	public string Long = "A tactical cannon that fires 10cc shells.";
	public int Capacity = 1;
	public List<string> Compatible = new List<string>() {"10cc Shell"};
	public TC10()
	{
		SetMass(5.0f);
	}
}
