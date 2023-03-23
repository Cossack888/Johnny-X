using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    public float moveSpeed;
    public float horizontalMove;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    Vector2 movement;
    public float runSpeed = 1;
    public Animator player;

    private void Update()
    {
        if (GroundCheck())
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = rb.velocity.y;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 2;
            player.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed = 1;
            player.SetBool("Running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)&&GroundCheck())
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;



    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * runSpeed * Time.deltaTime);

        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }
  

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }
    private bool GroundCheck()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}