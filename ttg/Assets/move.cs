using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pos = transform.position;
       
        
        pos.z += 0.5f;
        transform.position = pos;
    }
}
