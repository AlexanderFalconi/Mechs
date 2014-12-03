using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullets762 : Ammunition 
{
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public Bullets762()
	{
		Short = "7.62x51mm Bullets";
		Long = "A bundle of 7.62x51mm Bullets.";
		Bundle = 100;
		Ammo = new List<string>() {"MMG-20"};
		Combustibility = 0.003f;
		PrefabID = "Bullet";
		Amount = Bundle;
		DamageType = "ballistic";
		Damage["max"] = 3;
		Range = 6;
		SoundFX = "Audio/FXMediumMachineGun";
	}
}