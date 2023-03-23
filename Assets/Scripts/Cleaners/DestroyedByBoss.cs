using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedByBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Robot")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 5;
            bc.enabled = false;
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

        }
    }


}
