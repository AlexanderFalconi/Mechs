using UnityEngine;
using System.Collections.Generic;

public class Electroreactive : Armor 
{
	public Electroreactive(float mass): base(mass) 
	{
		Short = "Chameleon";
		Hardness = new Dictionary<string,int>() {
			{"impact",14}, {"ballistic",18}, {"energy",18}, {"explosive",18}, {"acid",14}
		};
	}
	//PREVENTS PENETRATION
}