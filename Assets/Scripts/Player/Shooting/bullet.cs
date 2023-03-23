using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    public float deadzone = -300;
    public Vector3 target;
    public Vector3 targetChest;
    public float timer;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform.position;

        targetChest = new Vector3(target.x, target.y + 1, 0);


    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
            timer = 0;
        }
       
      
       /*     Vector3 relativePos = target - transform.position;
        if (relativePos != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            rotation.x = transform.rotation.x;
            rotation.y = transform.rotation.y;
            transform.rotation = rotation;
        }*/

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetChest, step);
        if (transform.position == targetChest)
        {
            Destroy(gameObject);
        }

        //transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);


        if (collision.gameObject.CompareTag("Player"))
        {
            Death death = collision.gameObject.GetComponent<Death>();

            if (death != null)
            {
                death.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

       Destroy(gameObject);



    }
}
