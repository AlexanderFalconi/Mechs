using UnityEngine;
using System.Collections;

public class X7Compact : Gyro 
{
	public string[] Compatibility = new string[] {"left torso", "right torso", "central torso"};
	public X7Compact () 
	{
		Short = "X7 Compact Gyro";
		Long = "A MantisWare X7 Compact Gyro. Its design allows for more flexible installation options. Despite its smaller size, it is as dense and heavy as MechTech's Mark-2.";
		Stabilization = 40.0f;
		SetMass(0.50f);
		Energy["passive"] = 4.0f;
	}
}
