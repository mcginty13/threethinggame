using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public Button button;

    // Use this for initialization
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        int i = Application.loadedLevel;
        Application.LoadLevel(i + 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
