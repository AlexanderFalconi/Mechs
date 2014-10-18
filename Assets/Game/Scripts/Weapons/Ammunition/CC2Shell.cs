using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC2Shell : Component 
{
	public string Short = "2cc Shells";
	public string Long = "A bundle of 2cc ballistic shells.";
	public string DamageType = "ballistic";
	public int Damage = 40;
	public int Velocity = 15;//Affects accuracy, power degredation
	public List<string> Compatible = new List<string>() {"AC-2"};
	public int Amount = 32;
}