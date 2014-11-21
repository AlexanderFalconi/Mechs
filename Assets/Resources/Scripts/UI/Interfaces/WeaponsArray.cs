using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponsArray : MonoBehaviour
{
        public GameObject weapon;//Button prefab

        public void AddWeapon(Weapon which)
        {
                GameObject itemUI = Instantiate(weapon) as GameObject;//Instantiate UI text
                itemUI.name = "Weapon "+transform.childCount;
                itemUI.transform.parent = gameObject.transform;
                itemUI.transform.localScale = Vector3.one;//For some reason, changing the parent distorts the child and requires this hack.
                itemUI.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);//For some reason, changing the parent distorts the child and requires this hack.
                which.BindUI(itemUI.GetComponent<Interface>());//In case the button needs to be modified
                itemUI.GetComponent<DynamicWeapon>().BoundTo = which;
                itemUI.GetComponent<Button>().onClick.AddListener(which.Select);//In case the weapon object needs to be selected
                which.UpdateUI();//Initialize the button
        }
}