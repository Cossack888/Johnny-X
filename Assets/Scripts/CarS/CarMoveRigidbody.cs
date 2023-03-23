using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveRigidbody : MonoBehaviour
{
    
   private float moveSpeed ;
    private float MaxSpeed ;
    private float deadzone ;
    public float currentSpeed;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    Vector3 frontOfCar;
    Vector3 endOfCar;
    public bool occupied;
    public bool canGoFront=true;
    public TrafficLights traffic;
    public Animator anim;
    public int StopOrGo=1;
    public float turnLeft = 0;
    public float turn = 0;
    private Vector3 turnLeftDir = new Vector3(-3, 5, 0);


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        traffic = GameObject.Find("TraficLightSwitch").GetComponent<TrafficLights>();
       
        sprite = GetComponent<SpriteRenderer>();
    }


    public void FixedUpdate()
    {
        currentSpeed = moveSpeed;
        sortLayers();

        if (StopOrGo == 1)
            {
                moveSpeed = MaxSpeed;
                anim.SetFloat("Speed", moveSpeed);
            }
            if (StopOrGo == 0)
            {
                moveSpeed = 0;
                anim.SetFloat("Speed", moveSpeed);
            }

        if (turn == 0)
        {
            turnLeft = 0;
        }

       if (turn == 1)
        {
            turnLeft = 5;
        }

        if (turn == 2)
        {
            turnLeft = -5;
        }
        
            Vector2 m_Input = new Vector2(1, turnLeft);

            //Store user input as a movement vector

            //Apply the movement vector to the current position, which is
            //multiplied by deltaTime and speed for a smooth MovePosition
            rb.MovePosition(rb.position + m_Input * Time.deltaTime * moveSpeed);

         
        if (rb.position.x > deadzone)
        {
            Destroy(gameObject);
        }
    }
   
  
    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Car"))
        {
            Debug.Log(collision.gameObject.name);

            if (collision.GetComponent<CarMoveRigidbody>().moveSpeed == 0 && traffic.RedLight==true)
            {
                StopOrGo = 0;
            }
            
            
            
            if (rb.position.x < collision.gameObject.GetComponent<Rigidbody2D>().position.x)

                if (rb.position.y >= -20)
                {
                    moveSpeed = collision.GetComponent<CarMoveRigidbody>().moveSpeed;
                }
                else if (rb.position.y < -20)
                {
                    TurnLeft();
                }
            if (rb.position.x > collision.gameObject.GetComponent<Rigidbody2D>().position.x)
            {

                if (rb.position.y >= -20)
                {
                    TurnRight();
                }
            }
        }
        

            
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {

            Center();


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

    }
   
    public void TurnLeft()
    {
        turn = 1;
    }
    public void Center()
    {
        turn = 0;

    }
    public void TurnRight()
    {
        turn = 2;

    }

    public void sortLayers()
    {
        if (rb.position.y == -20)
        {
            sprite.sortingOrder = 1;
        }
        if (rb.position.y == -25)
        {
            sprite.sortingOrder = 2;
        }
        if (rb.position.y == -30)
        {
            sprite.sortingOrder = 3;
        }
    }

}
