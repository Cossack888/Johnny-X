using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerBullet : MonoBehaviour
{
    public Shooting shooting;
    public CinemachineVirtualCamera main;
    public Rigidbody2D rb;
    public float speed;
   private Vector3 MousePos;
    private float timer;
    public float delay;
    public int damage = 50;
    public int ZappPower = 100;

    private void Start()
    {
        
        
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = MousePos - transform.position;
        Vector3 rotation = transform.position -  MousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void Update()
    {
       // shooting = GetComponentInParent<Shooting>();



       
       // float v =   speed * Time.deltaTime;

      
        //Vector3 FORWARD = transform.TransformDirection(Vector3.forward);
       // transform.position = transform.position + FORWARD * v;

       // float step = speed * Time.deltaTime;
        //
        //transform.position = Vector3.MoveTowards(transform.position, MousePos, step);
      //  transform.position= transform.TransformDirection(Vector3.forward)*step;
        //transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);

       // transform.position = transform.position + transform.TransformDirection(Vector3.forward) * step;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);


        if (collision.gameObject.name == "head" && damage>50)
        {
            Life life = collision.gameObject.GetComponentInParent<Life>();
            Animator anim = collision.gameObject.GetComponentInParent<Animator>();
            if (life != null)
            {
                life.TakeDamage(damage*2);
                life.ZappDamage(ZappPower);
            }
            if (anim != null)
            {
                anim.SetBool("headshot", true);
                anim.SetBool("isShot", false);
            }



            Destroy(gameObject);
        }

        if (collision.gameObject.name == "head" && ZappPower>damage)
        {
            Life life = collision.gameObject.GetComponentInParent<Life>();
            Animator anim = collision.gameObject.GetComponentInParent<Animator>();
            if (life != null)
            {
                life.TakeDamage(damage);
                life.ZappDamage(ZappPower*2);


            }

            Destroy(gameObject);
        }


        if (collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Trap"))
        {
            Life life = collision.gameObject.GetComponent<Life>();

            if (life != null)
            {
                life.TakeDamage(damage);
                life.ZappDamage(ZappPower);


            }

            Destroy(gameObject);
        }

        
        
        
        
        
        
        Destroy(gameObject);



    }
}

