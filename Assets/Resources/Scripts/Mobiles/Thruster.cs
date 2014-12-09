using UnityEngine;
using System.Collections;
using Config;

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
		if(GetStatus() == Statuses.OK)
			Installed.Master.Thrust += Thrust;
		base.Interval();
  	}
}
