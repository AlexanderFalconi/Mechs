using UnityEngine;
using System.Collections;

public class Thruster : Component {
	public float Thrust;

	public override string GetSystem()
	{
		return "thruster";
	}

	public float GetThrust()
	{
		return Thrust;
	}

	public override void Interval()
	{
		if(GetStatus() == STATUS_OK)
			Installed.Master.Thrust += Thrust;
		base.Interval();
  	}
}
