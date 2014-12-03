using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicWeapon : Interface 
{
	public Text NameLabel;
	public Text LoadOutput;
	public Text AmmoOutput;
	public Text RateOutput;
    public Weapon BoundTo;
    public bool Selected = false;
    public AudioClip[] SoundFX = new AudioClip[2];

	public override void UpdateUI()
	{
		Color statusColor;
		NameLabel.text = BoundTo.GetShort();
		if(BoundTo.Selected)
			NameLabel.fontStyle = FontStyle.Bold;
		else
			NameLabel.fontStyle = FontStyle.Normal;
		switch(BoundTo.Status)
		{
			case 0:
				statusColor = new Color(0.23f, 0.51f, 0.03f, 1.0f); break;
			case 1:
				statusColor = new Color(0.96f, 0.89f, 0.12f, 1.0f); break;
			case 2:
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
		RateOutput.text = "Rate: "+BoundTo.RateOfFire["set"];
	}

	public void Select()
	{
		if(BoundTo.Loaded == null)
			BoundTo.Installed.Master.OrderLoad(this);
		else if(BoundTo.Amount < 1)
			BoundTo.Installed.Master.OrderReload(this);
		else
		{
			if(!Selected)
			{
				Selected = true;
		        audio.PlayOneShot(SoundFX[0]);
			}
			else
			{
		        audio.PlayOneShot(SoundFX[1]);
		        BoundTo.Selected = null;
				Selected = false;
			}
		}
		UpdateUI();
	}
}