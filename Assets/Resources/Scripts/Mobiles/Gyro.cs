using UnityEngine;
using System.Collections;
using Config;

public class Gyro : Component {
	public float Stabilization;

    public override string GetSystem()
    {
        return "gyro";
    }

	public float GetStabilization()
	{
		return Stabilization;
	}

	public override void Interval()
	{
		if(GetStatus() == Statuses.OK)
			Installed.Master.Stabilization += Stabilization;
		base.Interval();
  	}
}
