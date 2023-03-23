using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChaseAutoMove : MonoBehaviour
{

    public CarChaseSpawner spawner;

    public float MaxSpeed = 30;
    public float deadzone = 800;
    public float deadzone2 = -200;
    public float currentSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public bool occupied;
    public bool canGoFront = true;
    public TrafficLights traffic;
    public Animator anim;
    public int StopOrGo = 1;
    public float turnVector = 0;
    public float turn = 0;
    public bool m_FacingRight = true;
    public float horizontalMove;
    public bool leftLane;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        traffic = GameObject.Find("TraficLightSwitch").GetComponent<TrafficLights>();
        sprite = GetComponent<SpriteRenderer>();
        spawner = GetComponentInParent<CarChaseSpawner>();
    }

    public void Update()
    {
    }
    public void FixedUpdate()
    {

        CheckLane();

        if (!traffic.RedLight && StopOrGo == 0)
        {
            StopOrGo = 1;
        }

        if (horizontalMove > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && m_FacingRight)
        {

            Flip();
        }


        sortLayers();

        if (StopOrGo == 1)
        {
            currentSpeed = MaxSpeed;

        }
        if (StopOrGo == 0)
        {
            currentSpeed = 0;

        }


        Vector2 m_Input = new Vector2(horizontalMove, turnVector);



        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(rb.position + m_Input * Time.deltaTime * currentSpeed);

        if (rb.position.x > deadzone)
        {
            Destroy(gameObject);
        }
        if (rb.position.x < deadzone2)
        {
            Destroy(gameObject);
        }
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") || collision.CompareTag("PoliceCar"))
        {
            if (traffic.RedLight == true)
            {
                StopOrGo = 0;
            }

        }
        if (collision.CompareTag("Stop") && traffic.RedLight == false)
        {
            AdjustLane();
        }



    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Car") || collision.CompareTag("PoliceCar"))
        {
            turnVector = 0;
        }


        if (collision.CompareTag("Lane") )
        {
           leftLane = false;
            AdjustLane();
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Stop") && traffic.RedLight == true)
        {
            StopOrGo = 0;
        }
        if (collision.CompareTag("Stop") && traffic.RedLight == false)
        {
            StopOrGo = 1;
        }

        if (collision.CompareTag("Lane")&spawner.movingRight && rb.position.y>-15)
        {
            leftLane = true;
        }

        if (collision.CompareTag("Lane") & !spawner.movingRight && rb.position.y < -1)
        {
            leftLane = true;
        }

        if (collision.CompareTag("Car") || collision.CompareTag("PoliceCar"))
        {
            if (currentSpeed > collision.gameObject.GetComponent<CarChaseAutoMove>().currentSpeed)
            {
                if (spawner.movingRight)
                {
                    turnVector = 1;
                }
                if (!spawner.movingRight)
                {
                    turnVector = -1;
                }

            }

            if ( leftLane && currentSpeed > collision.gameObject.GetComponent<CarChaseAutoMove>().currentSpeed)
            {
                collision.gameObject.GetComponent<CarChaseAutoMove>().turnVector = -1;
            }

            if (leftLane && currentSpeed > collision.gameObject.GetComponent<CarChaseAutoMove>().currentSpeed)
            {
                collision.gameObject.GetComponent<CarChaseAutoMove>().turnVector = 1;
            }
        }



    }

    public void sortLayers()

    {


        sprite.sortingOrder = Mathf.Abs((int)Mathf.Floor(rb.position.y) + 1);
       

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }


    private void CheckLane()
    {
        if (!spawner.movingRight)
        {
            horizontalMove = -1;

        }

        if (spawner.movingRight)
        {
            horizontalMove = 1;

        }

    }


    public void AdjustLane()
    {
        if(rb.position.y<spawner.lane1+2 && rb.position.y > spawner.lane1 - 2)
        {
            transform.position = new Vector2(transform.position.x, spawner.lane1);
        }
        if (rb.position.y < spawner.lane2 + 2 && rb.position.y > spawner.lane2 - 2)
        {
            transform.position = new Vector2(transform.position.x, spawner.lane2);
        }
        if (rb.position.y < spawner.lane3 + 2 && rb.position.y > spawner.lane3 - 2)
        {
            transform.position = new Vector2(transform.position.x, spawner.lane3);
        }


    }

}
