using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int maxJumps;
    public Text scoreText;
    public Text yText;

    private bool inAir = false;
    private int jumps;
    private Rigidbody rb;
    private int score;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetCountText();
        SetYText();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCollectibles();
    }

    //Called before physics updates
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = 0.5f;
        Vector3 movement = new Vector3(moveX, 0.0f, 0.0f);

        var pos = transform.position;
        pos.z += moveZ;
        transform.position = pos;
        rb.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump") && (inAir == false || jumps < maxJumps))
        {
            float jump = 15.0f;
            Vector3 jumpMovement = new Vector3(0.0f, jump, 0.0f);
            rb.AddForce(jumpMovement * speed);
            jumps++;
            inAir = true;
        }
        if (inAir == true && rb.velocity.y < 1)
        {
            inAir = false;
            jumps = 0;
        }
        SetYText();
    }

    //Runs when object collides with a trigger collider
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible")){
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            score++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetYText()
    {
        yText.text = rb.velocity.y.ToString();
    }

    void SpawnCollectibles()
    {
        //Random rand = new Random();
        //float randX = rand.Next(1, 10);
        //float randZ = rand.Next(1, 10);

        //Vector3 position = new Vector3(randX, 1.0f, randZ);
        //Quaternion rotation = Quaternion.identity;
        //GameObject collectible = (GameObject)Instantiate(Resources.Load("Chip Spice"), position, rotation);
    }
}
