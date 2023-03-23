using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThrough : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fallingSpot")){
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
