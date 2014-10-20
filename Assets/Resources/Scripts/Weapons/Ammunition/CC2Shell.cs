using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC2Shell : Ammunition 
{
	static public string Short = "2cc Shells";
	static public string Long = "A bundle of 2cc ballistic shells.";
	static public string DamageType = "ballistic";
	static public int Damage = 40;
	static public int Velocity = 15;//Affects accuracy, power degredation
	static public List<string> Compatible = new List<string>() {"AC-2"};
	public int Amount = 32;
	public CC2Shell()
	{
		PrefabID = "Bullet";
	}
}