using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUTurn : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject policeCar;
    public float currentSpeed;
    public CarMovement movement;
    public float timer;
    public GameObject line;
    public int lineID = 0;
    public Animator car;


    // Update is called once per frame
    void Update()
    {

        line.GetComponent<BoxCollider2D>().isTrigger = false;
        currentSpeed = 30;
        if (Input.GetKey(KeyCode.Q) && lineID == 0)
        {
            policeCar.GetComponent<CarMovement>().enabled = false;
            policeCar.GetComponent<CarAutoMove>().enabled = false;

            line.GetComponent<BoxCollider2D>().isTrigger = true;
            car.SetBool("flip", true);


            Vector2 m_Input = new Vector2(-1, -1);
            rb.MovePosition(rb.position + m_Input * Time.deltaTime * currentSpeed);



        }
        if (Input.GetKey(KeyCode.E) && lineID == 1)
        {
            policeCar.GetComponent<CarMovement>().enabled = false;
            policeCar.GetComponent<CarAutoMove>().enabled = false;
            line.GetComponent<BoxCollider2D>().isTrigger = true;
            


            Vector2 m_Input = new Vector2(1, 1);
            rb.MovePosition(rb.position + m_Input * Time.deltaTime * currentSpeed);



        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("line1") && lineID == 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = new Vector2(transform.position.x, -21);
                transform.Rotate(0f, 180f, 0f);
                car.SetBool("flip", false);
                lineID = 1;
            }

        }

        if (collision.CompareTag("line1") && lineID == 1)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.position = new Vector2(transform.position.x, -13);
                transform.Rotate(0f, 180f, 0f);
                
                lineID = 0;
            }

        }

      

    }
}

