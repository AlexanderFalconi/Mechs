using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Config;

public class DynamicWeapon : Interface 
{
	public Text NameLabel;
	public Text LoadOutput;
	public Text AmmoOutput;
	public Text RateOutput;
    public Weapon BoundTo;
    public bool Selected = false;
    public AudioClip[] SoundFX = new AudioClip[4];

	public override void UpdateUI()
	{
		Color statusColor;
		NameLabel.text = BoundTo.GetShort();
		if(Selected)
			NameLabel.fontStyle = FontStyle.Bold;
		else
			NameLabel.fontStyle = FontStyle.Normal;
		switch(BoundTo.Status)
		{
			case Statuses.OK:
				statusColor = new Color(0.23f, 0.51f, 0.03f, 1.0f); break;
			case Statuses.STUN:
				statusColor = new Color(0.96f, 0.89f, 0.12f, 1.0f); break;
			case Statuses.DAMAGE:
				statusColor = new Color(1.0f, 0.0f, 0.0f, 1.0f); break;
			default://Destroyed
				statusColor = new Color(0.58f, 0.04f, 0.04f, 1.0f); break;
		}
		if(BoundTo.Loaded != null)
			LoadOutput.text = BoundTo.Loaded.Short;
		if(BoundTo.Reload["waiting"] > 0)
			AmmoOutput.text = "Reloading ("+BoundTo.Reload["waiting"]+")";
		else
			AmmoOutput.text = "Ammo: "+BoundTo.GetAmmoReport();
		if(BoundTo.Selected != null)
			RateOutput.text = "Target: "+BoundTo.Selected.Short;
		else
			RateOutput.text = "Rate: "+BoundTo.RateOfFire["set"];
	}

	public void Select()
	{
		if(BoundTo.Loaded == null)
		{
	        audio.PlayOneShot(SoundFX[0]);
			BoundTo.Installed.Master.AttemptLoad(BoundTo);
		}
		else if(BoundTo.Amount < 1)
		{
			if(BoundTo.Loaded.DamageType != "energy")
	        	audio.PlayOneShot(SoundFX[0]);
	        else
	        	audio.PlayOneShot(SoundFX[1]);
			BoundTo.Installed.Master.AttemptReload(BoundTo);
		}
		else if(BoundTo.Reload["waiting"] > 0)
			audio.PlayOneShot(SoundFX[2]);
		else
		{
			if(!Selected)
			{
				Selected = true;
		        audio.PlayOneShot(SoundFX[3]);
			}
			else
			{
		        audio.PlayOneShot(SoundFX[4]);
				Selected = false;
			}
		}
		UpdateUI();
	}
}