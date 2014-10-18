using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC5Shell : Component 
{
	public string Short = "5cc Shells";
	public string Long = "A bundle of 5cc ballistic shells.";
	public string DamageType = "ballistic";
	public int Damage = 100;
	public int Velocity = 8;//Affects accuracy, power degredation
	public List<string> Compatible = new List<string>() {"TC-15", "AC-15"};
	public int Amount = 16;
}