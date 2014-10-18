using UnityEngine;
using System.Collections;

public class Z1000Micro : Gyro 
{
	public int Stabilization = 25;
	public string Short = "Z1000 Micro Gyro";
	public string Long = "A GuerillaTek Z1000 Micro Gyro. A lightweight gyro typically installed in super-light mechs.";
	public string[] Compatibility = new string[] {"left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Z1000Micro () 
	{
		SetMass(0.25f);
	}
}
