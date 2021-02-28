using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class BallController : MonoBehaviour
{
    public GameObject particle;
    //For speed
    [SerializeField]
    private float Speed = 7;
    bool started;
    bool gameOver;

    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(Speed, 0, 0);
                started = true;
                GameManager.instance.StartGame(); 
            }
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (!Physics.Raycast(transform.position, Vector3.down, 3f))
        {
            gameOver = true;
            rb.velocity = new Vector3 (0, -25f, 0);
            Camera.main.GetComponent<cameraFollow>().gameOver = true;
            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            ChangeDirection();
        }

     //   SpeedIncrease();
    }

    void ChangeDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(Speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, Speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
           
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(part,1f);
        }
    }
/*
    void SpeedIncrease()
    {
       if( ScoreManager.instance.Score % 50 == 0)
        {
            Speed = Speed + 1;
        }
    }
    */
}
