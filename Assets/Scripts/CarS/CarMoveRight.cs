using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveRight : MonoBehaviour
{
    public float moveSpeed = 5;
    public float oldMoveSpeed =5 ;
    public float deadzone = 300;
    public TrafficLights trafficLightRed;
    public Animator anim;
    public Rigidbody2D rb;
    public GameObject thisObject;
    public SpriteRenderer sprite;
    public int order;
    public bool occupied=false;
    public bool cantGoFront=false;
    Vector3 endOfCar;
    Vector3 frontOfCar;
    //public GameObject doNotStop;


    void Update()
    {
        sprite = GetComponent<SpriteRenderer>();
        trafficLightRed = GameObject.Find("TraficLightSwitch").GetComponent<TrafficLights>();
        if (thisObject.transform.position.y == -18)
        {
            sprite.sortingOrder = 1;
        }
        if (thisObject.transform.position.y == -23)
        {
            sprite.sortingOrder = 2;
        }
        if (thisObject.transform.position.y == -28)
        {
            sprite.sortingOrder = 3;
        }

        anim.SetFloat("Speed", moveSpeed);

        if (trafficLightRed.RedLight == false && cantGoFront==false)
        {
            moveSpeed = oldMoveSpeed;
            rb.bodyType = RigidbodyType2D.Dynamic;
           // transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
                    anim.SetFloat("Speed", moveSpeed);
        }


      

        if (trafficLightRed.RedLight == false && cantGoFront == true)
        {
            moveSpeed = 0;
           

            anim.SetFloat("Speed", moveSpeed);
        }


        if (transform.position.x > deadzone)
        {
            Destroy(gameObject);
        }


    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
     //  rb.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
        
        frontOfCar = new Vector3(thisObject.transform.position.x + 3, thisObject.transform.position.y, 0);
        endOfCar = new Vector3(thisObject.transform.position.y - 3, thisObject.transform.position.y, 0);
        Vector3 up = transform.TransformDirection(Vector3.up);
        Vector3 front = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(thisObject.transform.position, up, 3)&& Physics.Raycast(endOfCar, up, 3) && Physics.Raycast(frontOfCar, up, 3))
        {
            occupied = true;
        }
            
        if (Physics.Raycast(frontOfCar, front, 2))
        {
            cantGoFront = true;
        }
        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            /*  if ((thisObject.transform.position.x < collision.transform.position.x)&& trafficLightRed == true)
              {
                  if (this.thisObject.transform.position.y < -18 && occupied == false)
                  {
                      this.thisObject.transform.position = transform.position + new Vector3(0, 5, 0);
                  }
                  else
                  {
                      moveSpeed = collision.gameObject.GetComponent<CarMoveRight>().moveSpeed;
                  }


              }
            */
            if (trafficLightRed==true && thisObject.transform.position.y >= -18)
                {
                if (thisObject.transform.position.x < collision.transform.position.x )
                {
                    moveSpeed = 0;
                    //moveSpeed = collision.gameObject.GetComponent<CarMoveRight>().moveSpeed;
                    //this.thisObject.transform.position = transform.position + new Vector3(-3, 0, 0);
                    //this.thisObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    Debug.Log("nowhere to go");
                }
            }
            
           

            if (thisObject.transform.position.x < collision.transform.position.x)
            {
                if (this.thisObject.transform.position.y < -18 && occupied == false)
                {
                    this.thisObject.transform.position = transform.position + new Vector3(-3, 5, 0);
                }
                else
                {
                    moveSpeed = collision.gameObject.GetComponent<CarMoveRight>().moveSpeed;
                }


            }
        }
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
      /*  if (trafficLightRed.RedLight == false)
        {
           // transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
          //  anim.SetFloat("Speed", moveSpeed);
        }*/
       
        if (collision.CompareTag("Stop")&&trafficLightRed.RedLight==true)
        {
            moveSpeed = 0;
            transform.position = transform.position;
          anim.SetFloat("Speed", moveSpeed);
        }


      


        else if (collision.CompareTag("Move") && trafficLightRed.RedLight == true && cantGoFront==false)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
          //  anim.SetFloat("Speed", moveSpeed);
        }



    }


}
