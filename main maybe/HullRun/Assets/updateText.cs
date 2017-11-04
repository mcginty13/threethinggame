using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateText : MonoBehaviour {

    public Text scoreText;
	// Use this for initialization
	void Start () {
        SetScoreText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SetScoreText()
    {
        scoreText.text = "Score: " + PersistentClass.getScore().ToString();
    }
}
