using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDown : MonoBehaviour
{
    public GameObject lift;
    public BoxCollider2D bc;
    public Rigidbody2D rb;
    public BoxCollider2D bc1;


    private void Start()
    {
        bc1 = GetComponent<BoxCollider2D>();
        bc = lift.GetComponent<BoxCollider2D>();
        rb = lift.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bc.enabled = true;
        rb.gravityScale = 10;
        bc1.enabled = false;
    }




}
