using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumping : MonoBehaviour
{
    public NewMovement movement;
    public CharacterController2D controler;
    
    public LayerMask wall;
    public bool onRightWall;
    public bool onLeftWall;
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    public float collisionRadius;
    public float moveVector=1000;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<NewMovement>();
       controler = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, wall);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, wall);

        if (!controler.m_Grounded)
        {
            if (onRightWall)
            {

                if (Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.D))
                {
                    controler.m_Rigidbody2D.AddForce(new Vector2(-300, controler.m_JumpForce-200 ));
                    movement.fallingtimer = 0;
                    movement.Flip();
                }
            }
            if (onLeftWall)
            {

                if (Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.A))
                {
                    controler.m_Rigidbody2D.AddForce(new Vector2(300, controler.m_JumpForce-200));
                    movement.fallingtimer = 0;
                    movement.Flip();
                }
            }
        }
        

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            controler.m_AirControl = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            controler.m_AirControl = false;
        }
    }


}
