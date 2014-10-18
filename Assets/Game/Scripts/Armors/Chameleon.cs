using UnityEngine;
using System.Collections.Generic;

public class Chameleon : Armor 
{
	static public Dictionary<string,int> Hardness = new Dictionary<string,int>() {
		{"impact",6}, {"ballistic",10}, {"energy",16}, {"explosive",12}, {"acid",14}
	};

	public Chameleon(float mass): base(mass) 
	{

	}
}