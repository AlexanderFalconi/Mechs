using UnityEngine;
using System.Collections;

public class Thruster : Component {
	public float Thrust;

	public override string GetSystem()
	{
		return "thruster";
	}

	public override float GetThrust()
	{
		return Thrust;
	}
}
