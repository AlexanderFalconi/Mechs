using UnityEngine;
using System.Collections;

public class X4LateralImpulse : Thruster 
{
	public string Short = "X4 Lateral Impulse Thruster";
	public string Long = "A MantisWare X4 Lateral Impulse Thruster. This cutting edge thruster can be installed in the torso as well as the legs.";
	private int Thrust = 40;
	public string[] Compatibility = new string[] {"left leg", "right leg", "left torso", "right torso", "center torso"};
	public X4LateralImpulse ()
	{
		SetMass(0.5f);
	}
}
