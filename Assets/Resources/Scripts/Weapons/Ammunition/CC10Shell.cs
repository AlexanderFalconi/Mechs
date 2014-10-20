using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC10Shell : Ammunition 
{
	static public string Short = "10cc Shells";
	static public string Long = "A bundle of 10cc ballistic shells.";
	static public string DamageType = "ballistic";
	static public int Damage = 200;
	static public int Velocity = 5;//Affects accuracy, power degredation
	static public List<string> Compatible = new List<string>() {"TC-10", "AC-10"};
	public int Amount = 8;
	public CC10Shell()
	{
		PrefabID = "Bullet";
	}
}