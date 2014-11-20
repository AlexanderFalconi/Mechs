using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public Text EnergyOutput, SpeedOutput;
	public Text PilotOutput;
	public Text MassOutput, RotationOutput, AccuracyOutput, LocomotionOutput, StabilizationOutput, MobilityOutput, BalanceOutput, MomentumOutput, 
	ArmorHOutput, ArmorLAOutput, ArmorRAOutput, ArmorLLOutput, ArmorRLOutput, ArmorLTOutput, ArmorRTOutput, ArmorCTOutput, ArmorHeadOutput, 
	ArmorLeftArmOutput, ArmorRightArmOutput, ArmorLeftLegOutput, ArmorRightLegOutput, ArmorLeftTorsoOutput, ArmorRightTorsoOutput, ArmorCenterTorsoOutput;
	public Inventory PanelInventory;
	public WeaponsArray PanelWeapons;
	public Transform Controlling;
	public bool androidFire = false;

	private void Update () 
	{
		if(Controlling == null || (Camera.main.GetComponent<InteractiveCamera>().touched != ""))
			return;//No control has been bind
		else
		{//Found control

		 	if( Input.GetMouseButtonDown(0)  && !androidFire)
			{//Left click
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
				if( Physics.Raycast( ray, out hit, 100 ) )
					Controlling.GetComponent<Mech>().OrderMove(hit.transform.GetComponent<Entity>().Position);				
			}
		 	if( Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0) && androidFire))
			{//Right click
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
				if( Physics.Raycast( ray, out hit, 100 ) )
					Controlling.GetComponent<Mech>().OrderFire( hit.transform.GetComponent<Entity>());		
			}
		}
	}

	public void EndTurn()
	{
		Controlling.GetComponent<Mech>().isDone = true;
	}

	public void BindControl(Entity entity)
	{
		Controlling = entity.BindController(this);
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

	public void UpdateUIArmor(Dictionary<string,Part> body)
	{
		//Setup quick panel
		ArmorHOutput.text = body["head"].Armors["external"].HP.ToString();
		ArmorLAOutput.text = body["left arm"].Armors["external"].HP.ToString();
		ArmorRAOutput.text = body["right arm"].Armors["external"].HP.ToString();
		ArmorLLOutput.text = body["left leg"].Armors["external"].HP.ToString();
		ArmorRLOutput.text = body["right leg"].Armors["external"].HP.ToString();
		ArmorLTOutput.text = body["left torso"].Armors["external"].HP.ToString();
		ArmorRTOutput.text = body["right torso"].Armors["external"].HP.ToString();
		ArmorCTOutput.text = body["center torso"].Armors["external"].HP.ToString();
		//Setup large panel
		ArmorHeadOutput.text = body["head"].GetUILong();
		ArmorLeftArmOutput.text = body["left arm"].GetUILong();
		ArmorRightArmOutput.text = body["right arm"].GetUILong();
		ArmorLeftLegOutput.text = body["left leg"].GetUILong();
		ArmorRightLegOutput.text = body["right leg"].GetUILong();
		ArmorLeftTorsoOutput.text = body["left torso"].GetUILong();
		ArmorRightTorsoOutput.text = body["right torso"].GetUILong();
		ArmorCenterTorsoOutput.text = body["center torso"].GetUILong();
	}

	public void InitInventory(Dictionary<string,Part> body) 
	{
		foreach(KeyValuePair<string,Part> item in body)
		{
			//PanelArmor.AddArmor(item.Key);//Interface armor line
			foreach(Component component in item.Value.Components)
			{
				PanelInventory.AddItem(component);//Interface item line
				if(component.GetSystem() == "weapon")//Interface weapon button
					PanelWeapons.AddWeapon((Weapon)component);					
			}
		}
	}
}