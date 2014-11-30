﻿using UnityEngine;
using System.Collections;

public class Arm : Part
{
	public Arm () 
	{
		Proportion["ratio"] = 0.13f;
		Melee.Add("punch");
		Melee.Add("push");
	}

	public override float GetAccuracy()
	{
		float accuracy = 0.0f;
		//foreach(Component item in Components)
		//	accuracy += item.GetAccuracy();
		return Mathf.Floor(accuracy/Master.GetMass());
	}

	public override int GetMeleeCR()
	{
		return 1;//Punch push
	}

	public override int GetMeleeDamage()
	{
		return Mathf.FloorToInt(Proportion["mass"] * Force/Master.GetMass());
	}

	public override void EventMeleeBacklash()
	{
		foreach(Component item in Components)
		{
			if(item.IsMeleeWeapon())
				return;//Found hand actuator or similar, no self damage
		}
		EventDamage(new Bludgeoning(Mathf.FloorToInt(Proportion["mass"])));
	}

	public override void InitActions()
	{
		BindUI(Master.Controller.PanelActions.AddAction("Punch", new ActionsArray.CanAction(CanPunch), new ActionsArray.TargetedAction(AttemptPunch)));
		//Master.Controller.AddAction("push", TargetedAction(AttemptPush)); 
		//Master.Controller.AddAction("grab", TargetedAction(AttemptGrab));
		base.InitActions();
	}

	public bool CanPunch()
	{
		if(IsTapped || ((Master.Posture == Mech.POSTURE_PRONE) && (Force >= 0.0f)))
			return false;
		else
			return true;
	}

	public void AttemptPunch(Transform what)
	{
		Mech target = Master.Environment.GetGridLocation(what.position)[0] as Mech;
		if(CanPunch() && (target != null) && (Vector3.Distance(Master.Position, target.Position) < 2.0f) && Master.EventDrainEnergy(GetMass()))
		{
			Master.EventMeleeAttack(target, this);
			IsTapped = true;
		}
		//else invalid target or out of range
	}
}