using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public Text EnergyOutput;
	public Text SpeedOutput;
	public Text MassOutput;
	public Text RotationOutput;
	public Text AccuracyOutput;
	public Text LocomotionOutput;
	public Text StabilizationOutput;
	public Text MobilityOutput;
	public Text BalanceOutput;
	public Text MomentumOutput;
	public Text PilotOutput;
	public Transform Controlling;
	public bool androidFire = false;

	private void Update () 
	{
		if(Controlling == null)
			return;//No control has been bind
		else
		{//Found control
		 	if( Input.GetMouseButtonDown(0)  && !androidFire)
			{//Left click
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
		 
				if( Physics.Raycast( ray, out hit, 100 ) )
				{
					if(hit.transform.GetComponent<Mech>() != null)
						Controlling.GetComponent<Mech>().OrderMove(hit.transform.GetComponent<Mech>().Position);
					else
						Controlling.GetComponent<Mech>().OrderMove(hit.transform.GetComponent<Tile>().Position);				
				}
			}
		 	if( Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0) && androidFire))
			{//Right click
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
				//if( Physics.Raycast( ray, out hit, 100 ) )
				//	Controlling.GetComponent<Mech>().OrderFire(hit.transform);			
			}
		}
	}

	public void EndTurn()
	{
		Controlling.GetComponent<Mech>().isDone = true;
	}

	public void BindControl(Transform entity)
	{
		Controlling = entity.GetComponent<Mech>().BindController(this);
	}

	//UI Interface Functions
	public void UpdateUIEnergy(float energy)
	{
		EnergyOutput.text = energy.ToString("0.00");
	}

	public void UpdateUISpeed(float walk, float run, float jump, int momentum, int moved)
	{
		SpeedOutput.text = walk.ToString()+"/"+run.ToString()+"/"+jump.ToString()+":"+moved+"."+momentum;
	}

	public void UpdateUIMass(float mass, int size)
	{
		MassOutput.text = mass.ToString("0.00")+" ("+size.ToString()+")";
	}

	public void UpdateUIRotation(float rotation)
	{
		RotationOutput.text = rotation.ToString("0.00");
	}

	public void UpdateUIBalance(float balance)
	{
		BalanceOutput.text = balance.ToString("0.00");
	}

	public void UpdateUIAccuracy(float accuracy)
	{
		AccuracyOutput.text = accuracy.ToString("0.00");
	}

	public void UpdateUILocomotion(float locomotion)
	{
		LocomotionOutput.text = locomotion.ToString("0.00");
	}

	public void UpdateUIStabilization(float stabilization)
	{
		StabilizationOutput.text = stabilization.ToString("0.00");
	}

	public void UpdateUIMobility(float mobility)
	{
		MobilityOutput.text = mobility.ToString("0.00");
	}

	public void UpdateUIMomentum(int momentum)
	{
		MomentumOutput.text = momentum.ToString();
	}

	public void UpdateUIPilot(Pilot pilot)
	{
		if(pilot == null)
			PilotOutput.text = "None";
		else
			PilotOutput.text = pilot.UIReport();
	}

	public void UpdateUIArmor(Pilot pilot)
	{

	}

	public void UpdateUIWeapons()
	{

	}

	public void SelectWeapon(int weapon)
	{
		
	}
}