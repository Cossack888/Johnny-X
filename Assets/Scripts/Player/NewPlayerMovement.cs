using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float moveSpeed = 40f;
    public float runSpeed = 1f;
    bool jump = false;
    bool crouch = false;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float m_JumpForce;
    public PhysicsMaterial2D HighFriction;
    public PhysicsMaterial2D LowFriction;
    public bool obstacle;
    public float timer;
    public bool isGrounded;
    public SortingLayer layer ;
   
   

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
       
    }
    void Update()
    {

        if (isGrounded == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed * runSpeed;
            animator.SetFloat("Speed", horizontalMove);

            if (Input.GetButtonDown("Jump") && obstacle == false)
            {
                Jump();
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }




       
        if (Input.GetKey(KeyCode.LeftShift)&&isGrounded==true)
            {
                runSpeed = 2;
                animator.SetBool("Running", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                runSpeed = 1;
                animator.SetBool("Running", false);
            }
        

      /*  if (Input.GetButtonDown("Jump")&& obstacle==false)
        {
           Jump();
            jump = true;
            animator.SetBool("isJumping", true);
        }
        
        if (Input.GetButtonDown("Horizontal") && (Input.GetButtonDown("Jump")) && obstacle == false )

        {
         //   JumpSideWays();
            animator.SetBool("isJumping", true);
            jump = true;
        }
       */ 


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stairs")
        {


            bc.sharedMaterial = HighFriction;
            rb.sharedMaterial = HighFriction;

            if (Input.GetButton("Horizontal"))
            {
                bc.sharedMaterial = LowFriction;
                rb.sharedMaterial = LowFriction;
            }

        }
        //(collision.gameObject.tag == "ground")
        if (collision.gameObject.layer ==3) 
        {

            isGrounded = true;
            
            animator.SetBool("isJumping", false);


        }

        if (collision.gameObject.tag == "obstacle")
        {
            obstacle = true;
        }



        if (collision.gameObject.tag == "obstacle" && Input.GetButton("Jump"))
        {

            BoxCollider2D box = collision.gameObject.GetComponent<BoxCollider2D>();
            Debug.Log(box.size.y);
            
            Vector2 target = new Vector2(collision.gameObject.transform.position.x, box.size.y +2);
            timer = timer + Time.deltaTime;
            animator.SetBool("obstacle", true);

            if (timer > 1)
            {
                // transform.position = Vector2.MoveTowards(transform.position, target, 2);
                transform.position = target;
                animator.SetBool("obstacle", false);
                timer = 0;
            }
           
            




        }



    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            obstacle = false;
            animator.SetBool("obstacle", false);
        }
        if (collision.gameObject.layer ==3 )
        {

            isGrounded = false;
            animator.SetBool("Running", false);
            animator.SetBool("isJumping", true);


        }


    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        controller.m_Grounded = isGrounded;



    }


   private void Jump()
    {
        
        rb.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);

    }
   /* private void JumpSideWays()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
            Debug.Log("running jump");
        }
        else
        {
            rb.AddForce(Vector2.right * horizontalMove, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        }

    }*/
      
    }
   

  

