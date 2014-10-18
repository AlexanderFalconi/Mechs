using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	public GameObject Selected;
	public bool androidFire = false;
	public int HP = 3;

	void Start () 
	{

	}
	
	public void SimpleAction()
	{
		Selected.GetComponent<Mech>().OrderFire(GameObject.FindWithTag("Player").transform.GetChild(0).gameObject);
		Selected.GetComponent<Mech>().isDone = true;
	}
}