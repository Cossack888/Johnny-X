using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{
    public Death death;
    public SpriteRenderer sprite;
    
    
    
 
    void Start()
    {
        death = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            death.health = death.MaxHealth;
            death.healthBar.SetHealth(death.health);
            sprite.enabled = false;
        }
    }


}
