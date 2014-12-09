using UnityEngine;
using System.Collections.Generic;
using Config;

public class Leg : Part 
{
	public Leg () 
	{
		Proportion["ratio"] = 0.13f;
		Melee.Add("kick");
	}

	public override int GetMeleeDamage()
	{
		return Mathf.FloorToInt(Force/Proportion["mass"] * 10.0f);
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
		BindUI(Master.Controller.PanelActions.AddAction("Kick", new CanAction(CanKick), new TargetedAction(AttemptKick)));
		base.InitActions();
	}

	public bool CanKick()
	{
		if(IsTapped || ((Master.Posture == Postures.PRONE) && (Force >= 0.0f)))
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
				if(limb.Value is Leg)
					limb.Value.IsTapped = true;
			}
		}
		//else invalid target or out of range
	}

	public override void EventDestroyed()
	{
		Master.EventFall(1);
		base.EventDestroyed();
	}
}