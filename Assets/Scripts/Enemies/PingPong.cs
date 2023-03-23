using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private Vector3[] positions;
    public float speedMove;
    private int index;
    public Animator anim;
    public bool m_FacingRight;
    

    // Update is called once per frame
    void Update()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v2Velocity = rb.velocity;
        
        speedMove = v2Velocity.x;
        anim.SetBool("walking", true);

        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        if (transform.position == positions[index])
        {
            if (index == 0)
            {
                Flip();
                index++;
            }
            //Hitting a right wall
            else if (index == positions.Length - 1)
            {
                Flip();
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }


}