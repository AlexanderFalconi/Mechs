using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TC10 : Weapon 
{
	public string Short = "TC-10";
	public string Long = "A tactical cannon that fires 10cc shells.";
	public int Capacity = 1;
	public List<string> Ammo = new List<string>() {"10cc Shell"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public TC10()
	{
		SetMass(5.0f);
	}
}
