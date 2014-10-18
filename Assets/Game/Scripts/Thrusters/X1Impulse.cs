using UnityEngine;
using System.Collections;

public class X1Impulse : Thruster 
{
	public string Short = "X1 Impulse Thruster";
	public string Long = "A MantisWare X1 Impulse Thruster. MantisWare figuratively vaulted into the market on this thruster, which, when installed in a mech's legs will literally vault it into the air.";
	private int Thrust = 50;
	public string[] Compatibility = new string[] {"left leg", "right leg"};
	public X1Impulse ()
	{
		SetMass(0.5f);
	}
}
