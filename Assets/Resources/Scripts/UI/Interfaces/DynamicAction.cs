using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Config;

public class DynamicAction : Interface 
{
	public Text NameLabel;
	public string Action;
	public bool Selected = false;
    public AudioClip[] SoundFX = new AudioClip[2];
    public TargetedAction TargetedActionHandler;
    public SimpleAction SimpleActionHandler;
    public CanAction CanActionHandler;

	public void Select()
	{
		if(!Selected)
		{
	        audio.PlayOneShot(SoundFX[0]);
	        transform.parent.GetComponent<ActionsArray>().Select(this);
		}
		else
		{
	        audio.PlayOneShot(SoundFX[1]);
	        transform.parent.GetComponent<ActionsArray>().Deselect();
		}
	}

	public override void UpdateUI()
	{
		gameObject.SetActive(CanActionHandler());
		NameLabel.text = Action;
		if(Selected)
			NameLabel.fontStyle = FontStyle.Bold;
		else
			NameLabel.fontStyle = FontStyle.Normal;
	}

	public void Deselect()
	{
	    Selected = false;
	    UpdateUI();
	}
}