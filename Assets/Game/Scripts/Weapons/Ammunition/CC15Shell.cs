using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC15Shell : Component 
{
	public string Short = "15cc Shells";
	public string Long = "A bundle of 15cc ballistic shells.";
	public string DamageType = "ballistic";
	public int Damage = 300;
	public int Velocity = 3;//Affects accuracy, power degredation
	public List<string> Compatible = new List<string>() {"TC-15", "AC-15"};
	public int Amount = 5;
}