using UnityEngine;
using System.Collections;

public class GUIButtons : MonoBehaviour {

    void OnGUI () {
        // Make a background box
        GUI.Box(new Rect(10,10,100,140), "Mechs v0.1");
    
        if(GUI.Button(new Rect(20,40,80,20), "End Turn")) {
            GameObject tmp = GameObject.FindWithTag("Interactive");
            tmp.GetComponent<Mech>().isDone = true;
        }

        if(GUI.Button(new Rect(20,80,80,20), "Move")) {
            GameObject tmp = GameObject.FindWithTag("Player");
            tmp.GetComponent<Player>().androidFire = false;
        }

        if(GUI.Button(new Rect(20,120,80,20), "Fire")) {
            GameObject tmp = GameObject.FindWithTag("Player");
            tmp.GetComponent<Player>().androidFire = true;
        }
    }
}