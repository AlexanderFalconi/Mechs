using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC20Shell : Component 
{
	public string Short = "20cc Shells";
	public string Long = "A bundle of 15cc ballistic shells.";
	public string DamageType = "ballistic";
	public int Damage = 400;
	public int Velocity = 2;//Affects accuracy, power degredation
	public List<string> Compatible = new List<string>() {"TC-20"};
	public int Amount = 3;
}