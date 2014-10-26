using UnityEngine;
using System.Collections;

public class SRM4 : MonoBehaviour 
{
	public string Short = "SRM-2";
	public string Long = "A PointBlank SRM-4 missile battery that stores up to 4 short-range missiles.";
	public int Capacity = 4;
	public int RateOfFire = 4;
	public List<string> Ammo = new List<string>() {"Shuriken-2 Missile"};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public SRM4()
	{
		Energy = new Dictionary<string,int>() {{"fire",4}, {"reload",4}};
		SetMass(1.75f);
	}
}