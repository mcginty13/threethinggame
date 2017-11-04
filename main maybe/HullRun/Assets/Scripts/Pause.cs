using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ScanForKeyStroke();
	}
    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape"))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (pausePanel.active)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
