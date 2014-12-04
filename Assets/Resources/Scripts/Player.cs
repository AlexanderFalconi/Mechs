using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public Text EnergyOutput, SpeedOutput;
	public Text PilotOutput;
	public Text MassOutput, MovedOutput, ThrustOutput, LocomotionOutput, StabilizationOutput, MobilityOutput, BalanceOutput, MomentumOutput, 
	ArmorHOutput, ArmorLAOutput, ArmorRAOutput, ArmorLLOutput, ArmorRLOutput, ArmorLTOutput, ArmorRTOutput, ArmorCTOutput, ArmorHeadOutput, 
	ArmorLeftArmOutput, ArmorRightArmOutput, ArmorLeftLegOutput, ArmorRightLegOutput, ArmorLeftTorsoOutput, ArmorRightTorsoOutput, ArmorCenterTorsoOutput;
	public Inventory PanelInventory;
	public RectTransform PanelSide;
	public WeaponsArray PanelWeapons;
	public ActionsArray PanelActions;
	public Mech Controlling;
	public bool androidFire = false;
	public Camera[] Cameras = new Camera[2];

	private void Setup()
	{
		PanelWeapons.transform.parent.gameObject.SetActive(false);
		PanelActions.transform.parent.gameObject.SetActive(true);
	}

	public void ActivateCamera(int cam)
	{
		for(int i = 0; i < Cameras.Length; i++)
		{
			if(i == cam)
				Cameras[i].enabled = true;
			else
				Cameras[i].enabled = false;
		}
	}

	private void Update () 
	{
		if((Controlling == null) || !Controlling.isReady)// || (Cameras[i].GetComponent<InteractiveCamera>().touched != ""))
			return;//No control has been bound
		else
		{//Found control
			if(Input.GetMouseButtonDown(0))
			{//Left click
				if(!RectTransformUtility.RectangleContainsScreenPoint(PanelSide, Input.mousePosition, Camera.main))
				{
					Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
					RaycastHit hit;
					if( Physics.Raycast( ray, out hit, 100) )
						Order(hit.transform);
				}
			}
		}
	}
	
	public void Order(Transform what)
	{
		switch(Controlling.Environment.Interval["phase"])
		{
			case Engine.PHASE_ACTION:
				if(PanelActions.Selected != null && PanelActions.Selected.TargetedAction != null)
					PanelActions.Selected.TargetedAction(what);
				break;
			case Engine.PHASE_WEAPON:
					PanelWeapons.TargetedAction(what.GetComponent<Entity>()); 
				break;
			default: //PHASE_DEPLOY
				return;
		}
	}

	public void EndTurn()
	{
		Controlling.isDone = true;
	}

	public void BindControl(Mech entity)
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
		SpeedOutput.text = walk.ToString()+"/"+run.ToString()+"/"+jump.ToString();
		MovedOutput.text = moved.ToString();
		MomentumOutput.text = momentum.ToString();
	}

	public void UpdateUIMass(float mass, int size)
	{
		MassOutput.text = mass.ToString("0.00")+" ("+size.ToString()+")";
	}

	public void UpdateUIBalance(float balance)
	{
		BalanceOutput.text = balance.ToString("0.00");
	}

	public void UpdateUIThrust(float thrust)
	{
		ThrustOutput.text = thrust.ToString("0.00");
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

	public void Initialize(Dictionary<string,Part> body) 
	{
		foreach(KeyValuePair<string,Part> item in body)
		{
			//PanelArmor.AddArmor(item.Key);//Interface armor line
			item.Value.InitActions();
			PanelInventory.AddPart(item.Value);
			foreach(Component component in item.Value.Components)
			{
				PanelInventory.AddComponent(component);//Interface item line
				if(component.GetSystem() == "weapon")//Interface weapon button
					PanelWeapons.AddWeapon((Weapon)component);					
			}
			Debug.Log(item.Value.Short+" "+item.Value.Proportion["max mass"]);
		}
	}
}