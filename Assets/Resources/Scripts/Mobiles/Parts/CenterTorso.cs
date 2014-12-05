using UnityEngine;
using System.Collections.Generic;

public class CenterTorso : Part 
{
	public CenterTorso () 
	{
		Short = "Center Torso";
		HitTable = new Dictionary<string,int>() {{"front", 7}, {"left", 5}, {"right", 5}};
		Proportion["ratio"] = 0.16f;	
		Melee.Add("charge");
		Melee.Add("pounce");
	}
	
	public override float[] GetFiringArc()
	{
		float[] arc = new float[] {322.5f, 37.5f};
		return arc;
	}

	public override int GetMeleeCR()
	{
		return 2;//Used for charge, pounce
	}

	public override int GetMeleeDamage()
	{
		return Mathf.FloorToInt(Master.GetMass() / 10.0f) * Master.Speed["momentum"];
	}

	public override void EventMeleeBacklash()
	{
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Master.GetMass() / 10.0f) * Master.Speed["momentum"]));
	}

	public override void InitActions()
	{
		BindUI(Master.Controller.PanelActions.AddAction("Move", new ActionsArray.CanAction(CanMove), new ActionsArray.TargetedAction(AttemptMove)));
		BindUI(Master.Controller.PanelActions.AddAction("Crawl", new ActionsArray.CanAction(CanCrawl), new ActionsArray.TargetedAction(AttemptCrawl)));
		BindUI(Master.Controller.PanelActions.AddAction("Jump", new ActionsArray.CanAction(CanJump), new ActionsArray.TargetedAction(AttemptJump)));
		BindUI(Master.Controller.PanelActions.AddAction("Prone", new ActionsArray.CanAction(CanProne), new ActionsArray.SimpleAction(AttemptProne)));
		BindUI(Master.Controller.PanelActions.AddAction("Stand", new ActionsArray.CanAction(CanStand), new ActionsArray.SimpleAction(AttemptStand)));
		BindUI(Master.Controller.PanelActions.AddAction("Charge", new ActionsArray.CanAction(CanCharge), new ActionsArray.TargetedAction(AttemptCharge)));
		BindUI(Master.Controller.PanelActions.AddAction("Pounce", new ActionsArray.CanAction(CanPounce), new ActionsArray.TargetedAction(AttemptPounce)));
		BindUI(Master.Controller.PanelActions.AddAction("Turn", new ActionsArray.CanAction(CanTurn), new ActionsArray.TargetedAction(AttemptTurn)));
		BindUI(Master.Controller.PanelActions.AddAction("Eject", new ActionsArray.CanAction(CanEject), new ActionsArray.SimpleAction(AttemptEject)));
		//Master.Controller.PanelActions.AddAction("climb", AttemptClimb);
		base.InitActions();
	}

	public bool CanMove()
	{
		if((Master.Posture == Mech.POSTURE_STAND) && (Master.Speed["walk"] > 0))
			return true;
		else
			return false;
	}

	public void AttemptMove(Transform what)
	{
		Entity location = Master.Environment.GetGridLocation(what.position)[0];
		Vector3 pos = location.Position;
		pos.y += 1;
		Master.AttemptMove(pos);
	}

	public bool CanCrawl()
	{
		return false;//TEMPORARY
		if((Master.Posture == Mech.POSTURE_PRONE) && (Master.Speed["walk"] > 0))
			return true;
		else
			return false;
	}

	public void AttemptCrawl(Transform what)
	{
		Entity location = Master.Environment.GetGridLocation(what.position)[0];
		Vector3 pos = location.Position;
		pos.y += 1;
		Master.AttemptMove(pos);
	}

	public bool CanJump()
	{
		return false;//TEMPORARY
		if((Master.Posture == Mech.POSTURE_STAND) && (Master.Speed["jump"] > 0))
			return true;
		else
			return false;
	}

	public void AttemptJump(Transform what)
	{
		Entity location = Master.Environment.GetGridLocation(what.position)[0];
		Vector3 pos = location.Position;
		pos.y += 1;
		Master.AttemptMove(pos);
	}

	public bool CanProne()
	{
		return false;//TEMPORARY
		if(Master.Posture == Mech.POSTURE_STAND)
			return true;
		else
			return false;
	}

	public void AttemptProne()
	{
		Master.EventProne();
	}

	public bool CanStand()
	{
		if((Master.Posture == Mech.POSTURE_PRONE) && (Master.Locomotion > 0.0f))
			return true;
		else
			return false;
	}

	public void AttemptStand()
	{
		Master.EventStand();
	}

	public bool CanCharge()
	{
		return false;//TEMPORARY
		if(CanMove())
			return true;
		else
			return false;
	}

	public void AttemptCharge(Transform what)
	{
		Mech target = Master.Environment.GetGridLocation(what.position)[0] as Mech;
		Vector3 location = target.Position - new Vector3(0.0f, 1.0f, 0.0f);
		if(CanCharge() && (target != null))
		{
			Master.EventCharge(location, target);
			foreach(KeyValuePair<string,Part> limb in Master.Body)
				limb.Value.IsTapped = true;
		}

	}

	public bool CanPounce()
	{
		return false;//TEMPORARY
		if(CanJump())
			return true;
		else
			return false;
	}

	public void AttemptPounce(Transform what)
	{
		Mech target = Master.Environment.GetGridLocation(what.position)[0] as Mech;
		Vector3 location = target.Position - new Vector3(0.0f, 1.0f, 0.0f);
		if(CanPounce() && (target != null))
		{
			Master.EventPounce(location, target);
			foreach(KeyValuePair<string,Part> limb in Master.Body)
				limb.Value.IsTapped = true;
		}
	}

	public bool CanTurn()
	{
		return true;
	}

	public void AttemptTurn(Transform what)
	{
		//Entity location = PointOutLocation(what);
		//Controlling.EventTurn(location, target);
	}

	public bool CanEject()
	{


		if(!IsTapped && (Master != null) && (Master.PilotOb != null) && (Master.PilotOb.Environment.GetStatus() == Component.STATUS_OK))
		{
			Debug.Log(Master.PilotOb.Environment);
			if(Master.PilotOb.Environment != null)
				Debug.Log(Master.PilotOb.Environment.GetStatus());
			return true;
		}
		else
			return false;
	}

	public void AttemptEject()
	{
		Debug.Log("EJECTED");
		Master.PilotOb.Environment.RemovePersonell();
		Master.EventEject();
	}
}