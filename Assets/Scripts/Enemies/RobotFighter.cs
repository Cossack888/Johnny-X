using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFighter : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    Death death;
    Transform target;
    Vector2 moveDirection;
   public  Vector2 Offset;
    public Vector2 Offset2;
    public LayerMask Ground;
    public LayerMask Wall;
    
    public float collisionRadius;
   
    private bool m_FacingRight;
    public bool goingUp;
    public bool goingDown;
    public bool onGround;
    public bool Gap;
    public bool jumping;
    public bool touchingWall;
    public Animator anim;
    public GameObject player;
    public float timer;
    public float delay=1f;
    public bool dmgDealt=false;
    
    
  


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        death = player.GetComponent<Death>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!touchingWall)
        {
            onGround = Physics2D.OverlapCircle((Vector2)transform.position + Offset, collisionRadius, Ground);
        }
        Gap = Physics2D.OverlapCircle((Vector2)transform.position + Offset2, collisionRadius, Wall);


        /* goingDown = !onGround;
         if (goingDown)
         {
             anim.SetBool("flying", true);
         }
        */
        if (Gap)
        {
            anim.SetBool("flying", true);
        }

        if (onGround)
        {
            anim.SetBool("flying", false);
        }

        if (dmgDealt == true)
        {
            timer += Time.deltaTime;
        }

        if (timer > delay + 1)
        {
            timer = 0;
        }

        if (target)
        {

            if (rb.velocity.x != 0&&!Gap)
            {
                anim.SetBool("walking", true);
                anim.SetBool("attackLow", false);
            }
            else
            {
                anim.SetBool("walking", false);
            }

            if (!goingUp)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //  rb.rotation = angle;
                moveDirection = direction;
                if (target.position.x > transform.position.x && m_FacingRight)
                {

                    Flip();
                   
                }

                if (target.position.x < transform.position.x && !m_FacingRight)
                {
                    Flip();
                    
                }
            }
            if (goingUp)
            {
                
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = new Vector2(direction.x*1.5f, direction.y+5);
                anim.SetBool("flying", true);
            }
        }
    }


    private void FixedUpdate()
    {
        if (target)
        {
            
                if (dmgDealt == false)
                {

                    rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
                }

                else if (dmgDealt == true & timer > delay)
                {
                    rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
            

          
            
           
           

        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "jumpForRobot")
        {

            transform.Translate(5, 5, 0);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
      {
          if ( collision.gameObject.CompareTag("Trap")){

            collision.gameObject.GetComponent<Life>().TakeDamage(200);
            

          }

        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Death>().TakeDamage(25);


        }

       

    }

   

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("wall") || (collision.gameObject.CompareTag("Trap")
                    || collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ledge")
            || collision.gameObject.CompareTag("fallingSpot"))) { 





            anim.SetBool("flying", true);
            anim.SetBool("walking", false);
            goingUp = true;
                goingDown = false;
                onGround = true;
                touchingWall = true;


        }
     




    }
    private void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("wall") || (collision.gameObject.CompareTag("Trap")
            || collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ledge")
            || collision.gameObject.CompareTag("fallingSpot"))) {

            
            
                goingUp = false;
                anim.SetBool("flying", false);
                anim.SetBool("walking", true);
                touchingWall = false;
            
        }

       


        /* if (collision.gameObject.CompareTag("Player"))
         {


             anim.SetBool("attackLow", false);
             anim.SetBool("walking", true);
             dmgDealt = false;

         }*/



    }
    public void  DealDamage()
    {
       
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetBool("attackLow", true);
            death.TakeDamage(25);
            dmgDealt = true;
    

        
        
        
    }
}
