using UnityEngine;
using System.Collections;

public class Actuator : Component 
{
	//Standard actuator puts out 50 force per ton. ratio of total mass to actuator outage is speed. i.e. 1T outputs 50 so for 10T mech thats ratio 5.0 for speed 5.
	//energy to walk within ratio, mass*spd; to run its doubling up each step.

	//arm actuator, same rating to move arm, excess factors into climbing and punching
	//so extra does move into punch damage
	//hand actuator allows grabbing; safe to punch or claw
	//hip actuator allows for rotating twisting
	//foot actuator allows balancing, safely kicking
	public Actuator (float mass) 
	{
		SetMass(mass);
	}
}
