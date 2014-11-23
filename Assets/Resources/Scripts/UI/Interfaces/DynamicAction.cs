using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicAction : Interface 
{
	public Text NameLabel;
	public string Action;
	public bool Selected = false;

	public void Set(string name)
	{
		Action = name;
		NameLabel.text = name;
	}

	public void Select()
	{
		transform.parent.GetComponent<ActionsArray>().Select(Action);
	}

	public override void UpdateUI()
	{
		if(Selected)
			NameLabel.fontStyle = FontStyle.Bold;
		else
			NameLabel.fontStyle = FontStyle.Normal;
	}
}