using UnityEngine;
using System.Collections;

public class TitaniumBipedalMech : Chassis 
{
	public string Short = "Titanium Internal Structure";
	public string Long = "A titanium internal structure for a bipedal mech.";
	public TitaniumBipedalMech()
	{
		SetInternal(0.10f);
	}
}