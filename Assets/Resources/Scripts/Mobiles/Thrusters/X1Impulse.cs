using UnityEngine;
using System.Collections;

public class X1Impulse : Thruster 
{
	public string[] Compatibility = new string[] {"left leg", "right leg"};
	public X1Impulse ()
	{
		Short = "X1 Impulse Thruster";
		Long = "A MantisWare X1 Impulse Thruster. MantisWare figuratively vaulted into the market on this thruster, which, when installed in a mech's legs will literally vault it into the air.";
		Thrust = 50.0f;
		SetMass(0.5f);
	}
}
