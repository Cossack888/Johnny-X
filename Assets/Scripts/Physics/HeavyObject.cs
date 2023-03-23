using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyObject : MonoBehaviour
{
    private BoxCollider2D box;
    public float height;


    private void Start()
    {
        box = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        if (transform.position.y < height)
        {
            box.enabled = false;
            box.tag = ("ground");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "head" )
        {
            Life life = collision.gameObject.GetComponentInParent<Life>();
            Animator anim = collision.gameObject.GetComponentInParent<Animator>();
            if (life != null)
            {
                
                life.ZappDamage(3000);
            }
            box.enabled = false;


        }



    }

}
