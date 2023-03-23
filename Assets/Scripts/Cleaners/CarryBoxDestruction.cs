using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBoxDestruction : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    private BoxCollider2D box;
    private Rigidbody2D rb;
    public float timer;
    public NewMovement movement;
    public Animator anim;
    public bool boxHit;
    public int durability;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<NewMovement>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            durability++;
            if (durability > 4)
            {
                boxHit = true;
               /* spriteRend.enabled = false;
                box.enabled = false;
                movement.weaponDrawn = false;
                anim.SetBool("WeaponDrawn", false);*/
                durability = 0;
            }
            
        }




    }




}
