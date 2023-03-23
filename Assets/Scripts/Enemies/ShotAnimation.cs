using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public Sprite newSprite;
    public Sprite oldSprite;
    public float timer;
    private BoxCollider2D box;
    private Rigidbody2D rb;
    public Animator anim;
    private PingPong pingpong;
    private EnemyFire fire;
    public bool shot;
    public GameObject childObject;
    
    

    void Start()
    {

     /*   if(transform.Find("line of sight").gameObject != null)
        {
            childObject = transform.Find("line of sight").gameObject;
        }*/
        
        
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pingpong = GetComponent<PingPong>();
        fire = GetComponentInChildren<EnemyFire>();
    }
    public void Update()
    {
        if(shot)
        {
            timer += Time.deltaTime;
        }

        if (timer > 1)
        {
            spriteRend.sprite = oldSprite;
            gameObject.layer = 3;
            timer = 0;
            shot = false;
            rb.isKinematic = false;
            
            
            
            
        }
        



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Killed();
           

        }

    }

    public void Killed()
    {
        anim.SetTrigger("isShot");
        if (childObject != null)
        {
            childObject.SetActive(false);
        }



        if (pingpong != null)
        {
            pingpong.enabled = false;
        }



        spriteRend.sprite = newSprite;
        shot = true;
    }

    public void Headshot()
    {
        anim.SetTrigger("headshot");
        if (childObject != null)
        {
            childObject.SetActive(false);
        }



        if (pingpong != null)
        {
            pingpong.enabled = false;
        }



        spriteRend.sprite = newSprite;
        shot = true;
    }
    

}
