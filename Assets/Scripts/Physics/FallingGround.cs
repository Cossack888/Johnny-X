using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fallingGround"))
        {




            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;


        }
    }
}
