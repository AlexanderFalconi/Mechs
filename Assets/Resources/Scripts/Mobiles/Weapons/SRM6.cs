using UnityEngine;
using System.Collections;

public class SRM6 : MonoBehaviour 
{
	public string Short = "SRM-6";
	public string Long = "A PointBlank SRM-6 missile battery that stores up to 6 short-range missiles.";
	public int Capacity = 6;
	public int RateOfFire = 6;
	public List<string> Ammo = new List<string>() {"Shuriken-2 Missile"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM6()
	{
		Energy = new Dictionary<string,int>() {{"fire",6}, {"reload",6}};
		SetMass(1.75f);
	}
}