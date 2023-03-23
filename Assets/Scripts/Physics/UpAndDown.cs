using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    public bool up;
    public float speed = 10f;
    private Rigidbody2D rb;
    public float pos1;
    public float pos2;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
    void Update()
    {

        if (transform.position.y > pos1)
        {
            up = true;
        }
        if (transform.position.y < pos2)
        {
            up = false;
        }

        if (up)
        {
            rb.velocity = new Vector2(0, speed * -1);
        }
        else
        {
            rb.velocity = new Vector2(0, speed * 1);
        }
    }
}
