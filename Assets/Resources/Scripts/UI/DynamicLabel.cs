using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicLabel : MonoBehaviour {
	public Text DynamicInput;
	void Start () {
		DynamicInput = GetComponent<Text>();
	}

	void Update(){
		DynamicInput.text = GameObject.FindWithTag("Player").GetComponent<Player>().Selected.GetComponent<Mech>().Energy.ToString();
	}
}
