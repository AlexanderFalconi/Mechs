using UnityEngine;
using System.Collections;

public class Z1000Micro : Gyro 
{
	public string[] Compatibility = new string[] {"left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Z1000Micro () 
	{
		Short = "Z1000 Micro Gyro";
		Long = "A GuerillaTek Z1000 Micro Gyro. A lightweight gyro typically installed in super-light mechs.";
		Stabilization = 25.0f;
		SetMass(0.25f);
	}
}
