using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AC10 : Weapon 
{
	public string Short = "AC-10";
	public string Long = "An semi-automatic cannon that fires 10cc shells.";
	public int Capacity = 3;
	public List<string> Compatible = new List<string>() {"10cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public AC10()
	{
		SetMass(7.0f);
	}
}