using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionsArray : MonoBehaviour 
{
	public List<DynamicAction> Actions = new List<DynamicAction>();
    public GameObject action;//Button prefab
    public DynamicAction Selected;
    public delegate void SimpleAction();
    public delegate void TargetedAction(Transform what);
    public delegate bool CanAction();

    public DynamicAction AddButton()
    {
        GameObject itemUI = Instantiate(action) as GameObject;//Instantiate UI text
        itemUI.name = "Action "+transform.childCount;
        itemUI.transform.parent = gameObject.transform;
        itemUI.transform.localScale = Vector3.one;//For some reason, changing the parent distorts the child and requires this hack.
        itemUI.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);//For some reason, changing the parent distorts the child and requires this hack.
        itemUI.GetComponent<Button>().onClick.AddListener(itemUI.GetComponent<DynamicAction>().Select);//In case the weapon object needs to be selected
        return itemUI.GetComponent<DynamicAction>();
    }

    public Interface AddAction(string label, CanAction conditionHandler, SimpleAction actionHandler)
    {
        DynamicAction itemUI = AddButton();
        itemUI.CanAction = conditionHandler;
        itemUI.SimpleAction = actionHandler;
        itemUI.Action = label;
        Actions.Add(itemUI);
        return itemUI as Interface;
    }

    public Interface AddAction(string label, CanAction conditionHandler, TargetedAction actionHandler)
    {
        DynamicAction itemUI = AddButton();
        itemUI.CanAction = conditionHandler;
        itemUI.TargetedAction = actionHandler;
        itemUI.Action = label;
        Actions.Add(itemUI);
        return itemUI as Interface;
    }

    public void Select(DynamicAction act)
    {
       	foreach(DynamicAction button in Actions)
    	{
    		if(button == act)
            {
                if(button.SimpleAction != null)
                    button.SimpleAction();//Its a simple action, just execute
                else
                {
                    button.Selected = true;//Its a complex action, wait for further input
                    Selected = button;
                }
            }
    		else
    			button.Selected = false;
    		button.UpdateUI();
    	}
    }

    public void Deselect()
    {
        Selected.Deselect();
        Selected = null;
    }
}