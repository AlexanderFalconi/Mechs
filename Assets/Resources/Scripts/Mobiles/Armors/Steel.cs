﻿using UnityEngine;
using System.Collections.Generic;

public class Steel : Armor 
{
	public Steel(float mass): base(mass) 
	{
		Hardness = new Dictionary<string,int>() {
			{"impact",18}, {"ballistic",20}, {"energy",20}, {"explosive",20}, {"acid",16}
		};
	}
}