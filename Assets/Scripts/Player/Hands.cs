using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{

    public GameObject player;
    public NewMovement movement;
    public Rigidbody2D rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<NewMovement>();
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (movement.canHangOnLedge)
        {
            if (collision.gameObject.CompareTag("climbPoint") && Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = 0;
                rb.velocity = Vector3.zero;
                movement.hanging = true;
                anim.SetBool("hanging", true);

            }
        }
    }
    




}
