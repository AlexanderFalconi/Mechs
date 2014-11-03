using UnityEngine;
using System.Collections;

public class M2Central : Gyro 
{
	public string[] Compatibility = new string[] {"central torso"};
	public M2Central () 
	{
		Short = "Mark-2 Central Gyro";
		Long = "A Mark-2 MechTech Central Gyro. The first line of gyros developed by MechTech remains one of the most effective and efficient; its only drawback being that it must be housed in a Mech's core.";
		Stabilization = 100.0f;
		SetMass(0.5f);
	}
}
