using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseOver()
    {
        GetComponent<Transform> ().localScale = new Vector3(1.2f, 1.2f, 1);
        GetComponent<TextMesh>().color = new Color(1, 0, 0, 1);
    }

    void OnMouseExit()
    {
        GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        GetComponent<TextMesh>().color = new Color(0, 0, 0, 1);
    }


    public bool isStart;
    public bool isQuit;
    void OnMouseDown()
    {
        if(isStart)
        {
            GetComponent<TextMesh>().text = "Replace with loading level";
        }
        if (isQuit)
        {
            return;
        }
        
    }

}
