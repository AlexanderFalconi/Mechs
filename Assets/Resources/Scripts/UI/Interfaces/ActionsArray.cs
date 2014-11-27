using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionsArray : MonoBehaviour 
{
	public Dictionary<string,GameObject> Actions = new Dictionary<string,GameObject>();
    public GameObject action;//Button prefab
    public string Selected;

    public void AddActions(Dictionary<string,bool> actions)
    {
		foreach(KeyValuePair<string,bool> which in actions)
		{
	        GameObject itemUI = Instantiate(action) as GameObject;//Instantiate UI text
	        itemUI.name = "Action "+transform.childCount;
	        itemUI.transform.parent = gameObject.transform;
	        itemUI.transform.localScale = Vector3.one;//For some reason, changing the parent distorts the child and requires this hack.
	        itemUI.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);//For some reason, changing the parent distorts the child and requires this hack.
	        itemUI.GetComponent<DynamicAction>().Set(which.Key);
	        itemUI.SetActive(which.Value);
	        itemUI.GetComponent<Button>().onClick.AddListener(itemUI.GetComponent<DynamicAction>().Select);//In case the weapon object needs to be selected
	        Actions[which.Key] = itemUI;
		}
    }

    public void UpdateUI(Dictionary<string,bool> actions)
    {
    	foreach(KeyValuePair<string,GameObject> action in Actions)
    		action.Value.SetActive(actions[action.Key]);
    }

    public void Select(string action)
    {
       	foreach(KeyValuePair<string,GameObject> button in Actions)
    	{
    		DynamicAction ob = button.Value.GetComponent<DynamicAction>();
    		if(button.Key == action)
            {
                ob.Selected = true;
                Selected = action;
            }
    		else
    			ob.Selected = false;
    		ob.UpdateUI();
    	}
    }
}