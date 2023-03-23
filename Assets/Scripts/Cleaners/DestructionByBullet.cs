using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionByBullet : MonoBehaviour
{
    public int shots;
    public int durability;

  

    // Update is called once per frame
    void Update()
    {
       if(shots>durability)
        {
            Destroy(gameObject);
        }
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            shots++;
            Destroy(collision);
        }
    }
}
