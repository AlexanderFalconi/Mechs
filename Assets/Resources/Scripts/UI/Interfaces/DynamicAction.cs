using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicAction : Interface 
{
	public Text NameLabel;
	public bool Selected;

	public void Set(string name)
	{
		NameLabel.text = name;
	}

	public override void UpdateUI()
	{
		if(Selected)
			NameLabel.fontStyle = FontStyle.Bold;
		else
			NameLabel.fontStyle = FontStyle.Normal;
	}
}