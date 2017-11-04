using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateMainMenuScore : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        SetText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SetText()
    {
        text.text = "Last Score: " + PersistentClass.getScore().ToString() + " " +
            "\nHigh Score: " + PersistentClass.getHighScore().ToString();
    }
}
