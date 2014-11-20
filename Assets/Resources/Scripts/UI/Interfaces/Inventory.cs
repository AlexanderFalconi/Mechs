using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
	public GameObject item;//Item list prefab

	public void AddItem(Component which)
	{
                GameObject itemUI = Instantiate(item) as GameObject;//Instantiate UI text
                itemUI.transform.parent = gameObject.transform;
                itemUI.transform.localScale = Vector3.one;//For some reason, changing the parent distorts the child and requires this hack.
                itemUI.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);//For some reason, changing the parent distorts the child and requires this hack.
                which.BindUI(itemUI.GetComponent<Interface>());//In case the button needs to be modified
                itemUI.GetComponent<DynamicItem>().BoundTo = which;
                which.UpdateUI();//Initialize the button
        }
}