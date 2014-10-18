using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject Selected;
	public bool androidFire = false;
	public int HP = 3;

	void Start () 
	{

	}
	
	void Update () 
	{
	 	if( Input.GetMouseButtonDown(0)  && !androidFire)
		{//Left click
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
	 
			if( Physics.Raycast( ray, out hit, 100 ) )
			{
				Selected.GetComponent<Mech>().OrderMove(hit.transform.gameObject);
			}
		}

	 	if( Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0) && androidFire))
		{//Right click
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
	 
			if( Physics.Raycast( ray, out hit, 100 ) )
			{
				Selected.GetComponent<Mech>().OrderFire(hit.transform.gameObject);
			}
		}
	}
}


     
