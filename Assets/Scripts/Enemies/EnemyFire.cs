using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public PingPong script;
    public float spawnRate = 4;
    private float timer = 0;
    public GameObject firepoint;
    public bool bossEnemy;
    public GameObject child;
    public Trap trigger;
    public int bullets;

    public void Start()
    {
        if (bossEnemy)
        {
            script = GetComponentInParent<PingPong>();
            script.enabled = false;
            script.anim.SetBool("machineGun", true);
            trigger = child.GetComponent<Trap>();
            

        }
    }

    private void Update()
    {
        if (bossEnemy)
        {
            if (trigger.trap)
            {
                script = GetComponentInParent<PingPong>();
                script.enabled = true;
                script.speed = 5;
                script.anim.SetBool("walking", true);
                script.anim.SetBool("shootingUp", false);

            }
        }
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!bossEnemy)
        {
            script = GetComponentInParent<PingPong>();
            if (collision.CompareTag("Player"))
            {
                script.speed = 0;
                script.anim.SetBool("walking", false);
                script.anim.SetBool("shootingMid", true);
            }
        }

        if (bossEnemy)
        {
            script = GetComponentInParent<PingPong>();
            if (collision.CompareTag("Player"))
            {
                script.speed = 0;
                script.anim.SetBool("walking", false);
                script.anim.SetBool("machineGun", true);
            }
        }




    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        


        if (collision.CompareTag("Player"))
        {

            if (bullets != 20)
            {
                if (timer < spawnRate)
                {
                    timer = timer + Time.deltaTime;

                }
                else
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
                    bullets++;
                    timer = 0;
                }
            }

            else
            {
                timer = timer + Time.deltaTime;

                if (timer > 7)
                {
                    timer = 0;
                    bullets = 0;
                }
            }

            



        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (bossEnemy)
        {
           
        }
        else
        {
            script = GetComponentInParent<PingPong>();
            if (collision.CompareTag("Player"))
            {
                script.speed = 5;
                script.anim.SetBool("walking", true);
                script.anim.SetBool("shootingUp", false);
            }
        }
        
    }



}
