using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicAction : Interface 
{
	public Text NameLabel;
	public string Action;
	public bool Selected = false;
    public ActionsArray.CanAction CanAction;
    public ActionsArray.SimpleAction SimpleAction;
    public ActionsArray.TargetedAction TargetedAction;
    public AudioClip[] SoundFX = new AudioClip[2];

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
		gameObject.SetActive(CanAction());
		NameLabel.text = Action;
		if(Selected)
			NameLabel.fontStyle = FontStyle.Bold;
		else
			NameLabel.fontStyle = FontStyle.Normal;
	}
}