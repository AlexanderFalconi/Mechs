using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour 
{
	void Start () 
	{

	}
	
	public void SimpleAction()
	{
		//Selected.GetComponent<Mech>().OrderFire(GameObject.FindWithTag("Player").transform.GetChild(0).gameObject);
		GetComponent<Mech>().isDone = true;
	}
}