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
    private List<float> lanes = new List<float>();
    private int lane;
    private bool laneChanged = false;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float laneChangeSpeed = 1.0f;
    private float startTime;
    private float journeyDistance;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetCountText();

        float x = -7.5f;
        for (var i = 0; i <= 6; i++)
        {
            lanes.Add(x);
            x += 2.5f;
            lane = 4;
        }
        SetYText();

        startTime = Time.time;
        //journeyDistance = Vector3.Distance(startPoint, endPoint);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCollectibles();
        var pos = transform.position;
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyDistance;
        pos.x = Vector3.Lerp(startPoint, endPoint, fractionOfJourney).x;
        transform.position = pos;
    }

    //Called before physics updates
    void FixedUpdate()
    {
        //float moveX = Input.GetAxis("Horizontal");
        float moveZ = 0.5f;
        //Vector3 movement = new Vector3(moveX, 0.0f, 0.0f);


        var pos = transform.position;
        pos.z += moveZ;
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (!laneChanged)
            {
                if (lane > 0)
                {
                    startPoint = new Vector3(lanes[lane], transform.position.y, transform.position.z);
                    lane -= 1;
                    endPoint = new Vector3(lanes[lane], transform.position.y, transform.position.z);


                    //pos.x = lanes[lane];

                    laneChanged = true;
                }
            }
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (!laneChanged)
            {
                if (lane < 6)
                {
                    startPoint = new Vector3(lanes[lane], transform.position.y, transform.position.z);
                    lane++;
                    endPoint = new Vector3(lanes[lane], transform.position.y, transform.position.z);
                    
                    //pos.x = lanes[lane];

                    laneChanged = true;
                }
            }
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            laneChanged = false;
        }
        //transform.position = pos;
        //rb.AddForce(movement * speed);

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
        if (other.gameObject.CompareTag("Collectible"))
        {
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
        yText.text = lanes[4].ToString();
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
