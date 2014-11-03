using UnityEngine;
using System.Collections;

public class X4LateralImpulse : Thruster 
{
	public string[] Compatibility = new string[] {"left leg", "right leg", "left torso", "right torso", "center torso"};
	public X4LateralImpulse ()
	{
		Short = "X4 Lateral Impulse Thruster";
		Long = "A MantisWare X4 Lateral Impulse Thruster. This cutting edge thruster can be installed in the torso as well as the legs.";
		Thrust = 40.0f;
		SetMass(0.5f);
	}
}
