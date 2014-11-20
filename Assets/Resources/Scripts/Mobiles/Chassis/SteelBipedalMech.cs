using UnityEngine;
using System.Collections;

public class SteelBipedalMech : Chassis 
{
	public string Short = "Steel Internal Structure";
	public string Long = "A steel internal structure for a bipedal mech.";
	public SteelBipedalMech()
	{
		SetInternal(0.12f);
		Generate = new ArmorGenerator(GenerateSteelArmor);
	}

	public Armor GenerateSteelArmor(float mass)
	{
		return new Steel(mass);
	}
}
