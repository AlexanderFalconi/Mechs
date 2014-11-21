using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionsArray : MonoBehaviour 
{
    public GameObject action;//Button prefab

    public void AddAction(string which)
    {
        GameObject itemUI = Instantiate(action) as GameObject;//Instantiate UI text
        itemUI.name = "Action "+transform.childCount;
        itemUI.transform.parent = gameObject.transform;
        itemUI.transform.localScale = Vector3.one;//For some reason, changing the parent distorts the child and requires this hack.
        itemUI.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);//For some reason, changing the parent distorts the child and requires this hack.
        itemUI.GetComponent<DynamicAction>().Set(which);
        //itemUI.GetComponent<Button>().onClick.AddListener(which.Select);//In case the weapon object needs to be selected
    }

    public void ClearActions()
    {
		while(transform.childCount>0)
			GameObject.Destroy(transform.GetChild(0));
    }
}