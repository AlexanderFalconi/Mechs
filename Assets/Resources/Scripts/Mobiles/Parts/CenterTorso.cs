using UnityEngine;
using System.Collections.Generic;
using Config;

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
		Master.EventManeuver(Master.Speed["momentum"] + 2);//Balance after a missed charge
	}

	public override void InitActions()
	{
		BindUI(Master.Controller.PanelActions.AddAction("Move", new CanAction(CanMove), new TargetedAction(AttemptMove)));
		BindUI(Master.Controller.PanelActions.AddAction("Reverse", new CanAction(CanReverse), new TargetedAction(AttemptReverse)));
		BindUI(Master.Controller.PanelActions.AddAction("Crawl", new CanAction(CanCrawl), new TargetedAction(AttemptCrawl)));
		BindUI(Master.Controller.PanelActions.AddAction("Jump", new CanAction(CanJump), new SimpleAction(AttemptJump)));
		BindUI(Master.Controller.PanelActions.AddAction("Prone", new CanAction(CanProne), new SimpleAction(AttemptProne)));
		BindUI(Master.Controller.PanelActions.AddAction("Stand", new CanAction(CanStand), new SimpleAction(AttemptStand)));
		BindUI(Master.Controller.PanelActions.AddAction("Charge", new CanAction(CanCharge), new TargetedAction(AttemptCharge)));
		BindUI(Master.Controller.PanelActions.AddAction("Pounce", new CanAction(CanPounce), new TargetedAction(AttemptPounce)));
		BindUI(Master.Controller.PanelActions.AddAction("Turn", new CanAction(CanTurn), new TargetedAction(AttemptTurn)));
		BindUI(Master.Controller.PanelActions.AddAction("Eject", new CanAction(CanEject), new SimpleAction(AttemptEject)));
		//Master.Controller.PanelActions.AddAction("climb", AttemptClimb);
		base.InitActions();
	}

	public bool CanMove()
	{
		if((Master.Posture == Postures.STAND) && (Master.Speed["walk"] > 0))
			return true;
		else
			return false;
	}

	public void AttemptMove(Transform what)
	{
		Entity location = Master.Environment.GetGridLocation(what.position)[0];
		Vector3 pos = location.Position = new Vector3(0.0f, 1.0f, 0.0f);
		Master.AttemptMove(pos);
	}

	public bool CanReverse()
	{
		if((Master.Posture == Postures.STAND) && (Master.Speed["walk"] > 0))
			return true;
		else
			return false;
	}

	public void AttemptReverse(Transform what)
	{
		Entity location = Master.Environment.GetGridLocation(what.position)[0];
		Vector3 pos = location.Position = new Vector3(0.0f, 1.0f, 0.0f);
		//Master.AttemptReverse(pos);
	}

	public bool CanCrawl()
	{
		if((Master.Posture == Postures.PRONE) && (Master.Speed["walk"] > 0))
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
		if((Master.Posture == Postures.STAND) && (Master.Speed["jump"] > 0))
			return true;
		else
			return false;
	}

	public void AttemptJump()
	{
		//EventJump();
	}

	public bool CanProne()
	{
		if(Master.Posture == Postures.STAND)
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
		if((Master.Posture == Postures.PRONE) && (Master.Locomotion > 0.0f))
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
			//Master.EventCharge(location, target);
			foreach(KeyValuePair<string,Part> limb in Master.Body)
				limb.Value.IsTapped = true;
		}
	}

	public bool CanPounce()
	{
		if(Master.Posture == Postures.JUMP)
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
			//Master.EventPounce(location, target);
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


		if(!IsTapped && (Master != null) && (Master.PilotOb != null) && (Master.PilotOb.Environment.GetStatus() == Statuses.OK))
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
		Master.EventEject();
	}
}