using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator car;
    public GameObject YellPrompt;
    public GameObject OutOfScreen;
   


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        { car.SetTrigger("death"); }

        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("YellSpot"))
        { YellPrompt.SetActive(true); }

        if (collision.CompareTag("OutOfScreen"))
        { OutOfScreen.SetActive(true); }
    }

}