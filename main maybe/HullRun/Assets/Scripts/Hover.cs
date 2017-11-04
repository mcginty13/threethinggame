using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private float amplitude = 0.2f;
    private float frequency = 1.0f;

    Vector3 offset;
    Vector3 tempPos;

    // Use this for initialization
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        tempPos = offset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
