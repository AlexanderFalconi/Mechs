using UnityEngine;
using System.Collections;

public class Chassis 
{
	public float Internal = 0.10f;//Supports 10 mass per 1
	public delegate Armor ArmorGenerator(float mass);
	public ArmorGenerator Generate;

	public void SetInternal(float inter)
	{
		Internal = inter;
	}
}
