using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingWall : MonoBehaviour
{

   public GameObject[] ledge;
    public LayerMask ground;
    public LayerMask LeftLedge;
    public LayerMask RightLedge;
    public float oldGravity;
    public bool underTheLeftLedge;
    public bool underTheRightLedge;
    public bool UnderLedge;
    public bool onTheWall;
    public bool onRightWall;
    public bool onLeftWall;
    public bool underTheWall;
    public float collisionRadius;
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    public Vector2 topOffset;
    public float timer;
    public float delay=1.5f;
    private Rigidbody2D rb;
    public int side;
    public float ledgeDistance;
    private Vector2 shape;
    public Vector3 shape2;
    public Vector2 target;
    public Vector2 target2;
    public Vector2 Newtarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //underTheLeftLedge = Physics2D.OverlapCircle((Vector2)transform.position + topOffset, collisionRadius, LeftLedge);
      // underTheRightLedge= Physics2D.OverlapCircle((Vector2)transform.position + topOffset, collisionRadius, RightLedge);


        
        onTheWall =  Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, ground) ||
            Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, ground);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, ground);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, ground);

        side = onRightWall ? 1 : -1;







      /*  if (onTheWall == true)
        {
            timer += Time.deltaTime;
        }*/
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

       
       


      /*      target2 = new Vector2(transform.position.x + 1, shape2.y + 2);
        shape = collision.gameObject.GetComponent<BoxCollider2D>().size;
        target = new Vector2(transform.position.x+1,shape.y+2);
        Newtarget = new Vector2(transform.position.x + 15, shape.y + 10);


        if (collision.gameObject.tag == "leftledge")
        {
            underTheLeftLedge = true;
            UnderLedge = true;
        }
        if (collision.gameObject.tag == "rightledge")
        {
            underTheRightLedge = true;
            UnderLedge = true;
        }
      */
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftledge")
        {
            underTheLeftLedge = false;
            UnderLedge = false;
        }
        if (collision.gameObject.tag == "rightledge")
        {
            underTheRightLedge = false;
            UnderLedge = false;
        }

    }



    /* private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Player")){
            rb = collision.GetComponent<Rigidbody2D>();
            oldGravity = rb.gravityScale;
            onTheWall = true;
            if (Input.GetButton("Jump"))
            {
                rb.gravityScale = 0;
            }
            

            
        }
    }*/

    /*  private void OnTriggerStay2D(Collider2D collision)
      {
          if (timer > delay|| (Input.GetButtonUp("Jump")))
          {
              rb.gravityScale = oldGravity;
              timer = 0;
              onTheWall = false;
          }



      }

      */
}
