using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

    public GameObject pausePanel;
    public Button button;
    // Use this for initialization
    void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
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
