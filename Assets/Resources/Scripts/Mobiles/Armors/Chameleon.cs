using UnityEngine;
using System.Collections.Generic;

public class Chameleon : Armor 
{
	public Chameleon(float mass): base(mass) 
	{
		Short = "Chameleon";
		Hardness = new Dictionary<string,int>() {
			{"impact",6}, {"ballistic",10}, {"energy",16}, {"explosive",12}, {"acid",14}
		};
	}
}