﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CC10Shell : Component 
{
	public string Short = "10cc Shells";
	public string Long = "A bundle of 10cc ballistic shells.";
	public string DamageType = "ballistic";
	public int Damage = 200;
	public int Velocity = 5;//Affects accuracy, power degredation
	public List<string> Compatible = new List<string>() {"TC-10", "AC-10"};
	public int Amount = 8;
}