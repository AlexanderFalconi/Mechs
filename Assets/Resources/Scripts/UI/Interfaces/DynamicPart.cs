using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicPart : Interface 
{
	public Text NameInput;
	public Text MassInput;
    public Part BoundTo;

	public override void UpdateUI()
	{
		NameInput.text = BoundTo.GetShort();
		MassInput.text = BoundTo.GetMass().ToString("0.00M");
	}
}