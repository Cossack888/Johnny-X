using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{

    public Animator enemy;
    public Life life;

    

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Animator>();
        life = GetComponentInParent<Life>();
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.name=="Buckshot")
        {
            enemy.SetBool("headshot",true);
            life.TakeDamage(300);
            
        }

    }

   



}
