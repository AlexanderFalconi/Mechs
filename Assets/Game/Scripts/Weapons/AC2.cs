using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC2 : Weapon 
{
	public string Short = "AC-2";
	public string Long = "An semi-automatic cannon that fires 2cc shells.";
	public int Capacity = 15;
	public List<string> Compatible = new List<string>() {"2cc Shell"};
	public AC2()
	{
		SetMass(3.0f);
	}
}