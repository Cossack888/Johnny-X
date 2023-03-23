using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingDown : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public CapsuleCollider2D cc;
    
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fallingSpot"))
        {
            
            
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 5;
            bc.enabled = false;
            cc.enabled = false;
            rb.velocity = new Vector2(0, -10);
            gameObject.tag = "PlayerDead";
            foreach (Transform child in transform)
            {

                MonoBehaviour[] childscripts = child.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in childscripts)
                {
                    script.enabled = false;
                }
              
            }
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }

        }
    }
}
