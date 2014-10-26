using UnityEngine;
using System.Collections;

public class Z55Variable : Gyro 
{
	public string Short = "Z55 Variable Gyro";
	public string Long = "A GuerillaTek Z55 Variable Gyro. Its versatile design allows for installation virtually anywhere.";
	public string[] Compatibility = new string[] {"left leg", "right leg", "left torso", "right torso", "center torso"};
	public Z55Variable () 
	{
		SetMass(0.50f);
	}

	public float GetStabilization()
	{
		return 60.0f;
	}
}