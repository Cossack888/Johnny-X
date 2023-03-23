using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControls : MonoBehaviour
{

    public float jumpHeight = 5;
    public float jump = 1;
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 currentVelocity;
    [SerializeField]
    private float movementSpeed = 3f;
    private float runSpeed = 1f;
    private Rigidbody2D characterRigidBody;
    private Animator animator;
    private bool m_FacingRight=true;

    public bool isGrounded;

    void Start()
    {
        this.characterRigidBody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
            this.moveHorizontal = Input.GetAxis("Horizontal");
            this.moveVertical = Input.GetAxis("Vertical");
            this.currentVelocity = this.characterRigidBody.velocity;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                runSpeed = 2;
                animator.SetBool("Running", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                runSpeed = 1;
                animator.SetBool("Running", false);
            }
            animator.SetFloat("Speed", moveHorizontal);

        

            if (!m_FacingRight)
            {
                animator.SetBool("FacingLeft", true);
            }
            if (m_FacingRight)
            {
                animator.SetBool("FacingLeft", false);
            }


            if (moveHorizontal > 0 && !m_FacingRight)
            {

                Flip();
            }

            else if (moveHorizontal < 0 && m_FacingRight)
            {
                        Flip();
            }
  
    }
    private void FixedUpdate()
    {
        float move = moveHorizontal * movementSpeed * runSpeed * Time.deltaTime;
        float ymove = this.currentVelocity.y * Time.deltaTime;


  characterRigidBody.MovePosition(characterRigidBody.position + new Vector2(move,ymove) );


        if (Input.GetButton("Jump")&&isGrounded)
        {
            float xForce = move;
                float yForce = ymove*jumpHeight;
            Debug.Log("jump");
            Vector2 force = new Vector2(xForce, yForce);

            characterRigidBody.velocity = new Vector2(0, jumpHeight);
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {

            isGrounded = true;

            animator.SetBool("isJumping", false);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);

        }
    }


    private void Flip()
    {
    m_FacingRight = !m_FacingRight;

    transform.Rotate(0f, 180f, 0f);
    }


   
}