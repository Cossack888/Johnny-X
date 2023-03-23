using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    private BoxCollider2D box;
    private Rigidbody2D rb;
    public Sprite newSprite;
    public Sprite oldSprite;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            spriteRend.sprite = newSprite;
            box.enabled = false;
            rb.isKinematic = false;

        }




    }




}
