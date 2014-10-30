using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicInput : MonoBehaviour 
{
	public Text Input;
	void Start () 
	{
		Input = GetComponent<Text>();
	}

	public void Set(string setting)
	{
		Input.text = setting;//GameObject.FindWithTag("Player").GetComponent<Player>().Selected.GetComponent<Mech>().Energy.ToString();
	}
}