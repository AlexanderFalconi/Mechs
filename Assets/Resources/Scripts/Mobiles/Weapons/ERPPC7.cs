using UnityEngine;
using System.Collections;

public class ERPPC7 : Weapon 
{
	public string Short = "ERPPC-7";
	public string Long = "An extended range particle projection cannon.";
	public int Capacity = 1;
	public int RateOfFire = 1;
	public List<string> Ammo = new List<string>() {};
	public string[] Compatibility = new string[] {"head", "left arm", "right arm", "left leg", "right leg", "left torso", "right torso", "center torso"};
	public ERPPC7()
	{
		Energy = new Dictionary<string,int>() {{"fire",80}};
		SetMass(8.0f);
	}
}
