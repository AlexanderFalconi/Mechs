using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC5Shell : Ammunition 
{
	static public string Short = "5cc Shells";
	static public string Long = "A bundle of 5cc ballistic shells.";
	static public string DamageType = "ballistic";
	static public int Damage = 100;
	static public int Velocity = 8;//Affects accuracy, power degredation
	static public List<string> Compatible = new List<string>() {"TC-15", "AC-15"};
	public int Amount = 16;
	public CC5Shell()
	{
		PrefabID = "Bullet";
	}
}