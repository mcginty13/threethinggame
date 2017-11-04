using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignmaterial : MonoBehaviour {

    public Texture2D[] myTextures;
    
	// Use this for initialization
	void Start () {
        string lr = gameObject.name;
        myTextures = Resources.LoadAll<Texture2D>("textures\\"+lr);
        
        GetComponent<Renderer>().material.SetTexture("_MainTex", myTextures[Random.Range(0, myTextures.Length)]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
