using UnityEngine;
using System.Collections.Generic;

public class Chameleon : Armor 
{
	public Chameleon(float mass): base(mass) 
	{
		Short = "Chameleon";
		Hardness = new Dictionary<string,int>() {
			{"impact",14}, {"ballistic",18}, {"energy",18}, {"explosive",18}, {"acid",14}
		};
	}
	//PREVENTS PENETRATION
}