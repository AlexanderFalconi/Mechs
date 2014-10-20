using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC5 : Weapon 
{
	public string Short = "AC-5";
	public string Long = "An semi-automatic cannon that fires 5cc shells.";
	public int Capacity = 6;
	public List<string> Compatible = new List<string>() {"5cc Shell"};
	public AC5()
	{
		SetMass(4.0f);
	}
}