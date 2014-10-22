using UnityEngine;
using System.Collections.Generic;

public class BlackWidow : Armor 
{
	
	public BlackWidow(float mass): base(mass) 
	{
		Hardness = new Dictionary<string,int>() {
			{"impact",14}, {"ballistic",22}, {"energy",22}, {"explosive",22}, {"acid",8}
		};
	}
}