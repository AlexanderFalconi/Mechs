using UnityEngine;
using System.Collections;

public class Gyro : Component {
	public float Stabilization;

	public override float GetStabilization()
	{
		return Stabilization;
	}
}
