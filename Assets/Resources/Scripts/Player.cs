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
	public WeaponsArray PanelWeapons;
	public ActionsArray PanelActions;
	public Mech Controlling;
	public bool androidFire = false;

	private void Setup()
	{
		PanelWeapons.transform.parent.gameObject.SetActive(false);
		PanelActions.transform.parent.gameObject.SetActive(true);
	}

	private void Update () 
	{
		if((Controlling == null) || !Controlling.isReady || (Camera.main.GetComponent<InteractiveCamera>().touched != ""))
			return;//No control has been bound
		else
		{//Found control
		 	if( Input.GetMouseButtonDown(0)  && (Controlling.Environment.Interval["phase"] == Engine.PHASE_ACTION))
			{//Left click
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
				if( Physics.Raycast( ray, out hit, 100 ) )
					Order(hit.transform);				
			}
		 	if( Input.GetMouseButtonDown(0) && (Controlling.Environment.Interval["phase"] == Engine.PHASE_WEAPON))
			{//Left click
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
				if( Physics.Raycast( ray, out hit, 100 ) )
					OrderFire( hit.transform);		
			}
		}
	}
	
	public void Order(Transform what)
	{
		switch(PanelActions.Selected)
		{
			case "move":
				OrderMove(what); break;
			case "crawl":
				OrderCrawl(what); break;
			case "turn":
				OrderTurn(what); break;
			case "prone":
				OrderProne(what); break;
			case "stand":
				OrderStand(what); break;
			case "punch":
				OrderPunch(what); break;
			case "kick":
				OrderKick(what); break;
			case "charge":
				OrderCharge(what); break;
			case "pounce":
				OrderPounce(what); break;
			case "jump":
				OrderJump(what);
		}
	}

	public Entity PointOutLocation(Transform what)
	{
		Entity location = what.GetComponent<Entity>();
		while(location.GetEntityType() != "tile")//Keep searching till terrain is found
			location = Controlling.Environment.Grid[(int)Controlling.Position.x][((int)Controlling.Position.y)-1][(int)Controlling.Position.z][0];
		return location;
	}

	public Entity PointOutTarget(Transform what)
	{
		Entity target = what.GetComponent<Entity>();
		if(target.GetEntityType() != "mech")
			return null;
		else
			return target;
	}

	public void OrderFire(Transform what)
	{//TEMP: This eventually needs to be the painting of targets
		Entity target = PointOutTarget(what);
		if(target != null)
			Controlling.OrderFire(target);		
	}

	public void OrderMove(Transform what)
	{
		Entity location = PointOutLocation(what);
		Controlling.EventMove(location.GetComponent<Entity>().Position);
	}

	public void OrderCrawl(Transform what)
	{
		Entity location = PointOutLocation(what);
		Controlling.EventMove(location.GetComponent<Entity>().Position);
	}

	public void OrderJump(Transform what)
	{
		Entity location = PointOutLocation(what);
		Controlling.EventMove(location.GetComponent<Entity>().Position);
	}

	public void OrderProne()
	{
		Controlling.EventProne()
	}

	public void OrderStand()
	{
		Controlling.EventStand()
	}

	public void OrderMelee(Transform what)
	{
		Entity target = PointOutTarget(what);
		if(target != null)
			Controlling.EventMeleeAttack(target, Selected.Limb)
		//Else no target
	}

	public void OrderCharge(Transform what)
	{
		Entity target = PointOutTarget(what);
		Entity location = PointOutLocation(what);
		if((target != null) && (location != null))
			Controlling.EventCharge(location, target);
	}

	public void OrderPounce(Transform what)
	{
		Entity target = PointOutTarget(what);
		Entity location = PointOutLocation(what);
		if((target != null) && (location != null))
			Controlling.EventPounce(location, target);
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