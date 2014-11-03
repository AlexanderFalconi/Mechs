using UnityEngine;
using System.Collections;

public class Z55Variable : Gyro 
{
	public string[] Compatibility = new string[] {"left leg", "right leg", "left torso", "right torso", "center torso"};
	public Z55Variable () 
	{
		Short = "Z55 Variable Gyro";
		Long = "A GuerillaTek Z55 Variable Gyro. Its versatile design allows for installation virtually anywhere.";
		Stabilization = 60.0f;
		SetMass(0.50f);
	}
}