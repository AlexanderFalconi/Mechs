using UnityEngine;
using System.Collections;

public class X7Compact : Gyro 
{
	public int Stabilization = 80;
	public string Short = "X7 Compact Gyro";
	public string Long = "A MantisWare X7 Compact Gyro. Its design allows for more flexible installation options. Despite its smaller size, it is as dense and heavy as MechTech's Mark-2.";
	public string[] Compatibility = new string[] {"left torso", "right torso", "central torso"};
	public X7Compact () 
	{
		SetMass(0.5f);
	}
}
