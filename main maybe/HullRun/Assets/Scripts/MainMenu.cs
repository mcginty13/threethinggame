using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isStart;
    public bool isQuit;

    private void OnMouseUp()
    {
        if(isStart)
        {
            Application.LoadLevel(1);
            GetComponent<TextMesh>().text = "Start Game";
        }
        if(isQuit)
        {
            Application.Quit();
        }
    }
    

}
