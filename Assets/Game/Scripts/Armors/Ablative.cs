using UnityEngine;
using System.Collections.Generic;

public class Ablative : Armor 
{
	static public Dictionary<string,int> Hardness = new Dictionary<string,int>() {
		{"impact",14}, {"ballistic",14}, {"energy",30}, {"explosive",18}, {"acid",18}
	};
	
	public Ablative(float mass): base(mass) 
	{

	}
}