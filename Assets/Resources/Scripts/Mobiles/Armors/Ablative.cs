using UnityEngine;
using System.Collections.Generic;

public class Ablative : Armor 
{	
	public Ablative(float mass): base(mass) 
	{
		Hardness = new Dictionary<string,int>() {
			{"impact",14}, {"ballistic",14}, {"energy",30}, {"explosive",18}, {"acid",18}
		};
	}
}