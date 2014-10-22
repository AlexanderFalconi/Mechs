using UnityEngine;
using System.Collections.Generic;

public class Titanium : Armor 
{
	public Titanium(float mass): base(mass) 
	{
		Hardness = new Dictionary<string,int>() {
			{"impact",20}, {"ballistic",20}, {"energy",20}, {"explosive",20}, {"acid",20}
		};
	}
}