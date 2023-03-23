using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private bool m_FacingRight;
    public bool goingUp;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
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
                moveDirection = new Vector2(direction.x, 1);
            }
        }
    }


    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            goingUp = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            goingUp = false;
        }
    }



}
