using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAutoMove : MonoBehaviour
{

    
    
   public float MaxSpeed = 30;
    public float deadzone = 550;
    public float deadzone2 = -70;
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
    public bool m_FacingRight=true;
    public float horizontalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        traffic = GameObject.Find("TraficLightSwitch").GetComponent<TrafficLights>();
        sprite = GetComponent<SpriteRenderer>();
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
    /*
  public void OnCollisionEnter2D(Collision2D collision)
  {
      if (collision.gameObject.CompareTag("line1"))
        {
            if (m_FacingRight)
            {
                turnVector = -2;
            }

            else
            {
                turnVector = 2;
            }

        }
        if (collision.gameObject.CompareTag("line2"))
        {
            turnVector = -2;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("line1"))
        {
            turnVector = 0;
        }
        if (collision.gameObject.CompareTag("line2"))
        {
            turnVector = 0;
        }
    }
       */

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car")|| collision.CompareTag("PoliceCar"))
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
      /*  if (collision.CompareTag("UpperLane") && !m_FacingRight)
        {
            turnVector = -1;
        }
        if (collision.CompareTag("LowerLane") && m_FacingRight)
        {
            turnVector = 1;
        }*/



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.CompareTag("UpperLane") && m_FacingRight )
        {
            transform.position = new Vector2(transform.position.x, -21);
        }
        if (collision.CompareTag("LowerLane") && !m_FacingRight)
        {
            transform.position = new Vector2(transform.position.x, -13);
        }
       */
        if (collision.CompareTag("Stop") && traffic.RedLight == true)
        {
            StopOrGo = 0;
        }
        if (collision.CompareTag("Stop") && traffic.RedLight == false)
        {
            StopOrGo = 1;
        }

        if (collision.CompareTag("Car") || collision.CompareTag("PoliceCar"))
        {
            if (currentSpeed > collision.gameObject.GetComponent<CarAutoMove>().currentSpeed)
            {
                if (rb.position.y <= -6 && rb.position.y > -17)
                {
                    turnVector = -1;
                    
                }
                if (rb.position.y <= -17 && rb.position.y > -28)
                {
                    turnVector = 1;
                    
                }



            }

            if (rb.position.y > -22 && rb.position.y <= -20 && currentSpeed > collision.gameObject.GetComponent<CarAutoMove>().currentSpeed)
            {
                collision.gameObject.GetComponent<CarAutoMove>().turnVector = -1;
            }
        }



    }

    public void sortLayers()

        




    {


        sprite.sortingOrder = Mathf.Abs((int)Mathf.Floor(rb.position.y)+1);
        /*if (rb.position.y <= -19 && rb.position.y > -20 )
        {
            sprite.sortingOrder = 1;
        }
        if (rb.position.y <=-20 && rb.position.y > - 22)
        {
            sprite.sortingOrder = 2;
        }
        if (rb.position.y <=-22 && rb.position.y > - 24)
        {
            sprite.sortingOrder = 3;
        }
        if (rb.position.y <= -24 && rb.position.y > -27)
        {
            sprite.sortingOrder = 4;
        }

        if (rb.position.y <= -6 && rb.position.y > -8)
        {
            sprite.sortingOrder = 1;
        }
        if (rb.position.y <= -8 && rb.position.y > -10)
        {
            sprite.sortingOrder = 2;
        }
        if (rb.position.y <= -10 && rb.position.y > -12)
        {
            sprite.sortingOrder = 3;
        }
        if (rb.position.y <= -12 && rb.position.y > -15)
        {
            sprite.sortingOrder = 4;
        }
        */

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }


    private void CheckLane()
    {
            if(rb.position.y<=-6 && rb.position.y > -17)
        {
            horizontalMove = -1;
          
        }

        if (rb.position.y <= -17 && rb.position.y > -28)
        {
            horizontalMove = 1;
           
        }

    }


    public void AdjustLane()
    {
     
        if (rb.position.y <= -6 && rb.position.y > -17)
        {
            if (rb.position.y <= -6 && rb.position.y > -9)
            {
                transform.position = new Vector2(transform.position.x, -7);
            }
            if (rb.position.y <= -9 && rb.position.y > -12)
            {
                transform.position = new Vector2(transform.position.x, -10);
            }
            if (rb.position.y <= -12 && rb.position.y > -17)
            {
                transform.position = new Vector2(transform.position.x, -13);
            }

        }

        if (rb.position.y <= -20 && rb.position.y > -28)
        {
            if (rb.position.y <= -20 && rb.position.y > -23)
            {
                transform.position = new Vector2(transform.position.x, -21);
            }
            if (rb.position.y <= -23 && rb.position.y > -25)
            {
                transform.position = new Vector2(transform.position.x, -24);
            }
            if (rb.position.y <= -25 && rb.position.y > -27)
            {
                transform.position = new Vector2(transform.position.x, -28);
            }

        }


    }

}
