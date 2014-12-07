using UnityEngine;
using System.Collections.Generic;

public class Reactive : Armor 
{
	public Reactive(float mass): base(mass) 
	{
		Short = "Reactive";
		Hardness = new Dictionary<string,int>() {
			{"impact",18}, {"ballistic",16}, {"energy",16}, {"explosive",16}, {"acid",16}
		};
		//PREVENTS PENETRATION
	}
}