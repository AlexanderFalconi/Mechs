using UnityEngine;
using System.Collections.Generic;

public class Leg : Part 
{
	public Leg () 
	{
		Proportion["ratio"] = 0.13f;
		Melee.Add("kick");
	}

	public override int GetMeleeDamage()
	{
		return Mathf.FloorToInt(Proportion["mass"] * Force/Master.GetMass());
	}

	public override void EventMeleeBacklash()
	{
		Master.EventManeuver(0);//Balance after a kick
		foreach(Component item in Components)
		{
			if(item.IsMeleeWeapon())
				return;//Found hand actuator or similar, no self damage
		}
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Proportion["mass"])));
	}

	public override void InitActions()
	{
		BindUI(Master.Controller.PanelActions.AddAction("Kick", new ActionsArray.CanAction(CanKick), new ActionsArray.TargetedAction(AttemptKick)));
		base.InitActions();
	}

	public bool CanKick()
	{
		if(IsTapped || ((Master.Posture == Mech.POSTURE_PRONE) && (Force >= 0.0f)))
			return false;
		else
			return true;
	}

	public void AttemptKick(Transform what)
	{
		Mech target = Master.Environment.GetGridLocation(what.position)[0] as Mech;
		if(CanKick() && (target != null) && (Vector3.Distance(Master.Position, target.Position) < 2.0f) && Master.EventDrainEnergy(GetMass()))
		{
			Master.EventMeleeAttack(target, this);
			foreach(KeyValuePair<string,Part> limb in Master.Body)
			{//No other leg can kick 
				if((Leg)limb.Value != null)
					limb.Value.IsTapped = true;
			}
		}
		//else invalid target or out of range
	}

	public override void EventDestroyed()
	{
		Master.EventFall();
		base.EventDestroyed();
	}
}