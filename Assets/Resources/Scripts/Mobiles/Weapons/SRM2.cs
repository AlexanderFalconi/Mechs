using UnityEngine;
using System.Collections;

public class SRM2 : MonoBehaviour 
{
	public string Short = "SRM-2";
	public string Long = "A PointBlank SRM-2 missile battery that stores up to 2 short-range missiles.";
	public int Capacity = 2;
	public int RateOfFire = 2;
	public List<string> Ammo = new List<string>() {"Shuriken-2 Missile"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM2()
	{
		Energy = new Dictionary<string,int>() {{"fire",2}, {"reload",2}};
		SetMass(1.75f);
	}
}