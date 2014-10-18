using UnityEngine;
using System.Collections;

public class M1FootActuator : Actuator 
{
	public string Short = "Mark-1 Foot Actuator";
	public string Long = "A MechTech Mark-1 foot actuator. It attaches to the end of the foot and is necessary for balance and locomotion.";
	public string[] Compatibility = new string[] {"left leg", "right leg"};

	public M1FootActuator(float mass): base(mass) 
	{

	}
}
