using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Transform Selected;
	public bool androidFire = false;

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
				if(hit.transform.GetComponent<Mech>() != null)
					Selected.GetComponent<Mech>().OrderMove(hit.transform.GetComponent<Mech>().Position);
				else
					Selected.GetComponent<Mech>().OrderMove(hit.transform.GetComponent<Tile>().Position);				
			}
		}

	 	if( Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0) && androidFire))
		{//Right click
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			//if( Physics.Raycast( ray, out hit, 100 ) )
			//	Selected.GetComponent<Mech>().OrderFire(hit.transform);			
		}
	}
}